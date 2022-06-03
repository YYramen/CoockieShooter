using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SampleClass : MonoBehaviour
{
    SaveData _saveData = new SaveData();
    SaveData _loadData = new SaveData();

    private void Start()
    {
        //_saveData.num = 100;
        //string jsonstr = JsonUtility.ToJson(_saveData);
        //Debug.Log(jsonstr);

        //SaveData player2 = JsonUtility.FromJson<SaveData>(jsonstr);

        //Debug.Log(player2.num);

        Debug.Log(_saveData.num);
        _saveData.num = 100;
        savePlayerData(_saveData);
        _loadData = loadPlayerData();
        Debug.Log(_loadData.num);
    }

    public void savePlayerData(SaveData player)
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

    public SaveData loadPlayerData()
    {
        string datastr = "";
        StreamReader reader;
        reader = new StreamReader(Application.dataPath + "/savedata.json");
        datastr = reader.ReadToEnd();
        reader.Close();

        return JsonUtility.FromJson<SaveData>(datastr);
    }
}
