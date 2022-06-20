using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    string _sDataFilePath;
    SaveData _sData;

    private void Awake()
    {
        _sDataFilePath = Application.dataPath + "/savedata.json"; 
        _sData = new SaveData();
        _sData.CookieNum = GameManager.Instance.Currentcoins;
    }

    public void Save()
    {
        StreamWriter writer;
        _sData.CookieNum = GameManager.Instance.Currentcoins;
        string jsonstr = JsonUtility.ToJson(_sData);
        //writer = new StreamWriter(Application.dataPath + "/savedata.json", false);
        using (writer = new StreamWriter(_sDataFilePath, false))
        {
            writer.Write(jsonstr);
            writer.Flush();

            Debug.Log("セーブ完了");
        }
    }

    public void Load()
    {
        string datastr = "";
        StreamReader reader;
        reader = new StreamReader(_sDataFilePath);
        datastr = reader.ReadToEnd();
        reader.Close();
        _sData = JsonUtility.FromJson<SaveData>(datastr);
        GameManager.Instance.WeponManager.SetUp(_sData.Wepon);
        GameManager.Instance._currentCoins = _sData.CookieNum;
        GameManager.Instance.UpdateCoin();
        Debug.Log("ロード完了");
    }
}
