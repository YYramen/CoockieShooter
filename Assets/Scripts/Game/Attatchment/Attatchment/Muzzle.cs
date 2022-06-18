using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muzzle : AttatchmentBase
{
    [SerializeField] int _atk = 1;
    public override void OnExecute()
    {
        GameManager.Instance.PlayerController.ChangeAttack(_atk);
    }
}
