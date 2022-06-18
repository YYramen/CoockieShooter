using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// アタッチメントの基底クラス。
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
