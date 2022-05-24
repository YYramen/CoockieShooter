using System;
using System.Collections.Generic;

public enum ItemType
{
    Gun,
    Upgrade
}

public enum GunType
{
    HandGun,
    MachinePistol,
    ShotGun,
    AssaultRifle
}

[Serializable]
public class ItemTable
{
    public ItemType Type;
    public string Name;
    public int value;
    public int targetId;
}

public class GameData
{
    static public List<ItemTable> data = new List<ItemTable>()
    {
        new ItemTable(){ Type = ItemType.Gun, Name = "ハンドガン", value = 10, targetId = 1},
        new ItemTable(){ Type = ItemType.Gun, Name = "マシンピストル", value = 100, targetId = 2},
        new ItemTable(){ Type = ItemType.Gun, Name = "ショットガン", value = 1000, targetId = 3},
        new ItemTable(){ Type = ItemType.Gun, Name = "アサルトライフル", value = 10000, targetId = 4},
        new ItemTable(){ Type = ItemType.Upgrade, Name = "ハンドガンの威力2倍", value = 100, targetId = 1},
        new ItemTable(){ Type = ItemType.Upgrade, Name = "マシンピストルの威力2倍", value = 1000, targetId = 2},
        new ItemTable(){ Type = ItemType.Upgrade, Name = "ショットガンの威力2倍", value = 1000, targetId =3},
        new ItemTable(){ Type = ItemType.Upgrade, Name = "アサルトライフルの威力2倍", value = 10000, targetId = 4},
        new ItemTable(){ Type = ItemType.Upgrade, Name = "全ての武器の威力2倍", value = 50000, targetId = 5}
    };
}
