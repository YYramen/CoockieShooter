using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpAll : AttatchmentBase
{
    [SerializeField] int _powerValue = 2;

    public override void OnExecute()
    {
        GameManager.Instance.EnemyController.ChangeDefence(_powerValue);
    }
}
