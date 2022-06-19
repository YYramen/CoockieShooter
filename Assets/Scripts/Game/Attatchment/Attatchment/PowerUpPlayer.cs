using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPlayer : AttatchmentBase
{
    int _powerAtk = 2;
    public override void OnExecute()
    {
        GameManager.Instance.PlayerController.ChangeAttack(_powerAtk);
    }
}
