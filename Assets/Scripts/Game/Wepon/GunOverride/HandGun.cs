using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ハンドガン(初期装備)のクラス、GunBase を継承している。
/// </summary>
public class HandGun : GunBase
{
    public override void Shot()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f, LayerMask.GetMask("Enemy")))
        {
            EnemyController ec = hit.collider.GetComponent<EnemyController>();
            if (ec)
            {
                ec.Hit(_atk);
            }
            Debug.Log($"{hit}に当たった");
        }

        else
        {
            Debug.Log("何にも当たらなかった");
        }
        Debug.DrawRay(ray.origin, ray.direction, Color.red, 1f) ;
    }
}
