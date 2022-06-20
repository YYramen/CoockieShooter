using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.IO;


/// <summary>
/// Player �̃R�C�����Ǘ�����N���X�B�Ǘ����Ă��镨���R�C���Ȃ̂ł��̂���GameManager�ɂȂ肻���B
/// </summary>
public class GameManager : SingletonMonoBehaviour<GameManager>
{
    [Header("���ݏ������Ă���R�C���̐�"), SerializeField] public long _currentCoins = 0;
    [SerializeField, Tooltip("�R�C������\��������e�L�X�g")] Text _coinText;
    SaveData _saveData = new SaveData();
    SaveData _loadSaveData = new SaveData();

    //---WeponManager---
    WeponManager _weponManager;
    public WeponManager WeponManager => _weponManager;
    public void SetWeponManager(WeponManager wepon) { _weponManager = wepon; }

    //---PlayerController---
    PlayerController _playerController;
    public PlayerController PlayerController => _playerController;
    public void SetPlayerController(PlayerController playerController) { _playerController = playerController; }

    //---Inventory---
    Inventory _inventory;
    public Inventory Inventory => _inventory;
    public void SetInventory(Inventory inventory) { _inventory = inventory; }

    //---Enemy---
    EnemyController _enemy;
    public EnemyController EnemyController => _enemy;
    public void SetEnemyController(EnemyController enemy) { _enemy = enemy; }

    //---CurrentCoins---
    public long Currentcoins => _currentCoins;


    /// <summary>
    /// �R�C����������Ƃ��ɌĂ΂��֐��A�擾�����R�C����Text�ɕ\������
    /// </summary>
    /// <param name="coin"></param>
    public void AddCoin(long coin)  //�G��|�������A�_���[�W��^�����Ƃ��ɃR�C�����v���C���[�ɗ^����
    {
        _currentCoins += coin;
        _coinText.text = _currentCoins.ToString();
    }

    public void UpdateCoin()
    {
        _coinText.text = _currentCoins.ToString();
    }

    /// <summary>
    /// �A�C�e�����w�����鏈��
    /// </summary>
    /// <param name="item"></param>
    /// <param name="cost"></param>
    public void BuySelect(ItemTable item, int cost)
    {
        _currentCoins -= cost;
        Instance.WeponManager.Buy(item.targetId);
        _coinText.text = _currentCoins.ToString();
    }

    public void Save(SaveData data)
    {
        _saveData.CookieNum = _currentCoins;
        _weponManager.Save(data);
        StreamWriter sw;

        string jsonstr = JsonUtility.ToJson(data);

        //writer = new StreamWriter(Application.dataPath + "/savedata.json", false);
        using (sw = new StreamWriter(Application.dataPath + "/savedata.json", false))
        {
            sw.Write(jsonstr);
            sw.Flush();
            Debug.Log("�Z�[�u����");
        }
    }

    public SaveData LoadSaveData()
    {
        string datastr = "";
        StreamReader reader;
        reader = new StreamReader(Application.dataPath + "/savedata.json");
        datastr = reader.ReadToEnd();
        reader.Close();

        Debug.Log("���[�h����");
        return JsonUtility.FromJson<SaveData>(datastr);
    }
}
