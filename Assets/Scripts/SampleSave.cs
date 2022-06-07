using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SampleSave
{
    public void SavePlayerData(SampleSaveData player)
    {
        StreamWriter writer;

        string jsonstr = JsonUtility.ToJson(player);

        //writer = new StreamWriter(Application.dataPath + "/savedata.json", false);
        using(writer = new StreamWriter(Application.dataPath + "/savedata.json", false))
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
