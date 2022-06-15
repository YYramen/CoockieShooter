using System;
using System.Collections.Generic;


/// <summary>
/// ゲームに使うデータのクラス。保存用ではない。
/// </summary>
public enum ItemType
{
    Wepon,
    Upgrade
}

public enum WeponType
{
    Gun,
    Turret
}

[Serializable]
public class ItemTable
{
    public ItemType Type;
    public string Name;
    public int price;
    public int targetId;
}

public class GameData
{
    static public List<ItemTable> ItemTable = new List<ItemTable>()
    {
        new ItemTable(){ Type = ItemType.Wepon, Name = "ハンドガン", price = 10, targetId = 1},
        new ItemTable(){ Type = ItemType.Wepon, Name = "マシンピストル", price = 100, targetId = 2},
        new ItemTable(){ Type = ItemType.Wepon, Name = "ショットガン", price = 1000, targetId = 3},
        new ItemTable(){ Type = ItemType.Wepon, Name = "アサルトライフル", price = 10000, targetId = 4},
        new ItemTable(){ Type = ItemType.Wepon, Name = "タレット", price = 1000, targetId = 5},
        new ItemTable(){ Type = ItemType.Wepon, Name = "ドローン", price = 10000, targetId = 6},
        new ItemTable(){ Type = ItemType.Upgrade, Name = "ハンドガンの威力2倍", price = 10, targetId = 1},
        new ItemTable(){ Type = ItemType.Upgrade, Name = "マシンピストルの威力2倍", price = 1000, targetId = 2},
        new ItemTable(){ Type = ItemType.Upgrade, Name = "ショットガンの威力2倍", price = 1000, targetId =3},
        new ItemTable(){ Type = ItemType.Upgrade, Name = "アサルトライフルの威力2倍", price = 10000, targetId = 4},
        new ItemTable(){ Type = ItemType.Upgrade, Name = "タレットの威力2倍", price = 1000, targetId = 5},
        new ItemTable(){ Type = ItemType.Upgrade, Name = "ドローンの威力2倍", price = 10000, targetId = 6},
        new ItemTable(){ Type = ItemType.Upgrade, Name = "全ての武器の威力2倍", price = 25000, targetId = 6}
    };
}
