using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ハンドガン(初期装備)のスクリプト、GunBase を継承している。
/// </summary>
public class HandGun : GunBase
{
    protected override void Shot()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f, LayerMask.GetMask("Enemy")))
        {
            Debug.Log($"{hit}に当たった");
            GameManager.Instance.Shot();
        }
        else
        {
            Debug.Log("何にも当たらなかった");
        }
    }

    protected override void AltShot()
    {
        
    }
}
