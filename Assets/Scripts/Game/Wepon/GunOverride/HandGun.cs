using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �n���h�K��(��������)�̃N���X�AGunBase ���p�����Ă���B
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
            Debug.Log($"{hit}�ɓ�������");
        }

        else
        {
            Debug.Log("���ɂ�������Ȃ�����");
        }
        Debug.DrawRay(ray.origin, ray.direction, Color.red, 1f) ;
    }
}
