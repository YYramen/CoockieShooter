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
        public GameObject Prefab;
    }
    [SerializeField] List<WeponSetting> _weponSettings;

    List<WeponData> _wepons = new List<WeponData>();

    int _createdCount = 0;

    private void Awake()
    {
        GameManager.Instance.SetWeponManager(this);
    }

    public void SetUp(List<WeponData> savedata)
    {
        _wepons = savedata;

        foreach(var w in _wepons)
        {
            for(int i = 0; i < w.Level; i++)
            {
                Buy(w.Id, true);
            }
        }
    }

    public void Buy(int Id, bool isInit = false)
    {
        var prefab = _weponSettings.Where(x => x.Id == Id).Select(s => s.Prefab).Single();
        var obj = Instantiate(prefab, this.transform);

        if (!isInit)
        {
            bool isFind = false;

            for (int i= 0; i < _wepons.Count; i++)
            {
                if(_wepons[i].Id != Id)
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
        _createdCount++;
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
