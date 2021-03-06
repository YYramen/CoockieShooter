using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SampleClass : MonoBehaviour
{
    SampleSaveData _saveData = new SampleSaveData();
    SampleSaveData _loadData = new SampleSaveData();

    private void Start()
    {
        //_saveData.num = 100;
        //string jsonstr = JsonUtility.ToJson(_saveData);
        //Debug.Log(jsonstr);

        //SaveData player2 = JsonUtility.FromJson<SaveData>(jsonstr);

        //Debug.Log(player2.num);

        Debug.Log(_saveData.num);
        _saveData.num = 100;
        SavePlayerData(_saveData);
        _loadData = LoadPlayerData();
        Debug.Log(_loadData.num);
    }

    public void SavePlayerData(SampleSaveData player)
    {
        StreamWriter writer;

        string jsonstr = JsonUtility.ToJson(player);

        //writer = new StreamWriter(Application.dataPath + "/savedata.json", false);
        using (writer = new StreamWriter(Application.dataPath + "/savedata.json", false))
        {
            writer.Write(jsonstr);
            writer.Flush();
        }
    }

    public SampleSaveData LoadPlayerData()
    {
        string datastr = "";
        StreamReader reader;
        reader = new StreamReader(Application.dataPath + "/savedata.json");
        datastr = reader.ReadToEnd();
        reader.Close();

        return JsonUtility.FromJson<SampleSaveData>(datastr);
    }
}
