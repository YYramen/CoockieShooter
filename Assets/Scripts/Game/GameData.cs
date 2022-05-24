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
        new ItemTable(){ Type = ItemType.Gun, Name = "�n���h�K��", value = 10, targetId = 1},
        new ItemTable(){ Type = ItemType.Gun, Name = "�}�V���s�X�g��", value = 100, targetId = 2},
        new ItemTable(){ Type = ItemType.Gun, Name = "�V���b�g�K��", value = 1000, targetId = 3},
        new ItemTable(){ Type = ItemType.Gun, Name = "�A�T���g���C�t��", value = 10000, targetId = 4},
        new ItemTable(){ Type = ItemType.Upgrade, Name = "�n���h�K���̈З�2�{", value = 100, targetId = 1},
        new ItemTable(){ Type = ItemType.Upgrade, Name = "�}�V���s�X�g���̈З�2�{", value = 1000, targetId = 2},
        new ItemTable(){ Type = ItemType.Upgrade, Name = "�V���b�g�K���̈З�2�{", value = 1000, targetId =3},
        new ItemTable(){ Type = ItemType.Upgrade, Name = "�A�T���g���C�t���̈З�2�{", value = 10000, targetId = 4},
        new ItemTable(){ Type = ItemType.Upgrade, Name = "�S�Ă̕���̈З�2�{", value = 50000, targetId = 5}
    };
}
