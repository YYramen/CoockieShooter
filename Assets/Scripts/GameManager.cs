using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.IO;


/// <summary>
/// Player のコインを管理するクラス。管理している物がコインなのでそのうちGameManagerになりそう。
/// </summary>
public class GameManager : SingletonMonoBehaviour<GameManager>
{
    [Header("現在所持しているコインの数"), SerializeField] public long _currentCoins = 0;
    [SerializeField, Tooltip("コイン数を表示させるテキスト")] Text _coinText;
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
    /// コインが増えるときに呼ばれる関数、取得したコインをTextに表示する
    /// </summary>
    /// <param name="coin"></param>
    public void AddCoin(long coin)  //敵を倒した時、ダメージを与えたときにコインをプレイヤーに与える
    {
        _currentCoins += coin;
        _coinText.text = _currentCoins.ToString();
    }

    public void UpdateCoin()
    {
        _coinText.text = _currentCoins.ToString();
    }

    /// <summary>
    /// アイテムを購入する処理
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
            Debug.Log("セーブ完了");
        }
    }

    public SaveData LoadSaveData()
    {
        string datastr = "";
        StreamReader reader;
        reader = new StreamReader(Application.dataPath + "/savedata.json");
        datastr = reader.ReadToEnd();
        reader.Close();

        Debug.Log("ロード完了");
        return JsonUtility.FromJson<SaveData>(datastr);
    }
}
