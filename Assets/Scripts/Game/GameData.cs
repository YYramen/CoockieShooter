using System;
using System.Collections.Generic;


/// <summary>
/// �Q�[���Ɏg���f�[�^�̃N���X�B�ۑ��p�ł͂Ȃ��B
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
        new ItemTable(){ Name = "�}�Y��", price = 10, targetId = 1},
        new ItemTable(){ Name = "�g���K�[", price = 100, targetId = 2},
        new ItemTable(){ Name = "�b��", price = 1000, targetId = 3},
        new ItemTable(){ Name = "����", price = 10000, targetId = 4},
        new ItemTable(){ Name = "�^���b�g", price = 1000, targetId = 5},
        new ItemTable(){ Name = "�h���[��", price = 10000, targetId = 6},        
        new ItemTable(){ Name = "����̈З�2�{", price = 1000, targetId = 7},
        new ItemTable(){ Name = "�S�Ă̕���̈З�2�{", price = 50000, targetId = 8}
    };
}
