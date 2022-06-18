using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// �A�^�b�`�����g�̊��N���X�B
/// </summary>
public class AttatchmentBase : MonoBehaviour
{

    public void Execute(int Id)
    {
        GameManager.Instance.Inventory.ActiveItem(Id - 1);
        OnExecute();
    }

    public virtual void OnExecute()
    {

    }
}
