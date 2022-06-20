using System;
using System.Collections.Generic;


/// <summary>
/// ゲームに使うデータのクラス。保存用ではない。
/// </summary>

[Serializable]
public class ItemTable
{
    public string Name;
    public int price;
    public int targetId;
}

public class GameData
{
    static public List<ItemTable> ItemTable = new List<ItemTable>()
    {
        new ItemTable(){ Name = "マズル", price = 10, targetId = 1},
        new ItemTable(){ Name = "トリガー", price = 100, targetId = 2},
        new ItemTable(){ Name = "傭兵", price = 1000, targetId = 3},
        new ItemTable(){ Name = "隊長", price = 10000, targetId = 4},
        new ItemTable(){ Name = "タレット", price = 1000, targetId = 5},
        new ItemTable(){ Name = "ドローン", price = 10000, targetId = 6},        
        new ItemTable(){ Name = "武器の威力2倍", price = 1000, targetId = 7},
        new ItemTable(){ Name = "全ての武器の威力2倍", price = 50000, targetId = 8}
    };
}
