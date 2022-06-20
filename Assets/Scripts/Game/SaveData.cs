using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;


/// <summary>
/// セーブデータ。
/// </summary>
[Serializable]
public class WeponData
{
    public int Id;
    public int Level;
}

//[Serializable]
//public class UpgradeData
//{
//    public int Id;
//}

[Serializable]
public class SaveData 
{
    public long CookieNum = 0;
    public List<WeponData> Wepon = new List<WeponData>();
    //public List<UpgradeData> Upgrade = new List<UpgradeData>();
}
