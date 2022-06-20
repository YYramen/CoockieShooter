using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;


/// <summary>
/// プレイヤーのWeponを管理するコンポーネント
/// </summary>
public class WeponManager : MonoBehaviour
{
    [Serializable]
    class WeponSetting
    {
        public int Id;
        //public Material Material;
        public AttatchmentBase Attatchment;
    }
    [SerializeField] List<WeponSetting> _weponSettings;

    List<WeponData> _wepons = new List<WeponData>();

    int[] _damageLog;
    public int[] DamageLog => _damageLog;

    int[] _currentDPS;
    public int[] CurrentDPS => _currentDPS;

    private void Awake()
    {
        GameManager.Instance.SetWeponManager(this);

        _damageLog = new int[GameData.ItemTable.Count];
        _currentDPS = new int[GameData.ItemTable.Count];
    }

    public void SetUp(List<WeponData> savedata)
    {
        _wepons = savedata;

        foreach (var w in _wepons)
        {
            for (int i = 0; i < w.Level; i++)
            {
                Buy(w.Id, true);
            }
        }
    }

    /// <summary>
    /// 今まで与えたダメージの更新
    /// </summary>
    /// <param name="index"></param>
    /// <param name="value"></param>
    public void ChangePreviewDamageLog(int index, int value)
    {
        _damageLog[index] += value * GameManager.Instance.EnemyController.DamageScale;
    }

    /// <summary>
    /// 現在のDPSの更新
    /// </summary>
    /// <param name="index"></param>
    /// <param name="value"></param>
    public void ChangePreviewCounts(int index, int value)
    {
        _currentDPS[index] += value * GameManager.Instance.EnemyController.DamageScale;
    }

    public void ChangeDPSScale()
    {
        for (int i = 0; i < _currentDPS.Length; i++)
        {
            _currentDPS[i] *= GameManager.Instance.EnemyController.DamageScale;
        }
    }

    public void Buy(int Id, bool isInit = false)
    {
        ////var prefab = _weponSettings.Where(x => x.Id == Id).Select(s => s.Prefab).Single();
        //var material = _weponSettings.Where(x => x.Id == Id).Select(s => s.Material).Single();
        //GameManager.Instance.PlayerController.GunObject.GetComponent<MeshRenderer>().material = material;

        var w = _weponSettings.Where(x => x.Id == Id).Single();
        w.Attatchment.Execute(Id);


        if (!isInit)
        {
            bool isFind = false;

            for (int i = 0; i < _wepons.Count; i++)
            {
                if (_wepons[i].Id != Id)
                {
                    continue;
                }

                isFind = true;
                _wepons[i].Level++;
                break;
            }
            if (!isFind)
            {
                _wepons.Add(new WeponData() { Id = Id, Level = 1 });
            }
        }
    }

    public int GetLevel(int id)
    {
        var data = _wepons.Where(x => x.Id == id);

        if (data.Count() > 0)
        {
            return data.Single().Level;
        }
        else
        {
            return 0;
        }
    }
}
