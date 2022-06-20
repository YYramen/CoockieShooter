using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : AttatchmentBase
{
    [SerializeField] float _interval = 0.02f;
    [SerializeField] int _id = 1;

    public override void OnExecute()
    {
        GameManager.Instance.PlayerController.ChangeInterval(_interval);
    }
}
