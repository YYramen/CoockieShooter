using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muzzle : AttatchmentBase
{
    [SerializeField] int _atk = 1;
    [SerializeField] int _id = 1;
    public override void OnExecute()
    {
        GameManager.Instance.PlayerController.ChangeAttack(_atk);
        GameManager.Instance.WeponManager.ChangePreviewCounts(_id, _atk);
    }
}
