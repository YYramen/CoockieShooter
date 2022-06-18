using System;
using System.Collections.Generic;


/// <summary>
/// �Q�[���Ɏg���f�[�^�̃N���X�B�ۑ��p�ł͂Ȃ��B
/// </summary>
public enum ItemType
{
    Wepon,
    AutoWepon,
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
        new ItemTable(){ Type = ItemType.Wepon, Name = "�n���h�K��", price = 10, targetId = 1},
        new ItemTable(){ Type = ItemType.Wepon, Name = "�}�V���s�X�g��", price = 100, targetId = 2},
        new ItemTable(){ Type = ItemType.Wepon, Name = "�V���b�g�K��", price = 1000, targetId = 3},
        new ItemTable(){ Type = ItemType.Wepon, Name = "�A�T���g���C�t��", price = 10000, targetId = 4},
        new ItemTable(){ Type = ItemType.AutoWepon, Name = "�^���b�g", price = 1000, targetId = 5},
        new ItemTable(){ Type = ItemType.AutoWepon, Name = "�h���[��", price = 10000, targetId = 6},        
        new ItemTable(){ Type = ItemType.Upgrade, Name = "����̈З�2�{", price = 1000, targetId = 2},
        new ItemTable(){ Type = ItemType.Upgrade, Name = "�^���b�g�̈З�2�{", price = 1000, targetId = 5},
        new ItemTable(){ Type = ItemType.Upgrade, Name = "�h���[���̈З�2�{", price = 10000, targetId = 6},
        new ItemTable(){ Type = ItemType.Upgrade, Name = "�S�Ă̕���̈З�2�{", price = 25000, targetId = 6}
    };
}
