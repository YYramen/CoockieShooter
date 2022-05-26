using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �n���h�K��(��������)�̃X�N���v�g�AGunBase ���p�����Ă���B
/// </summary>
public class HandGun : GunBase
{
    protected override void Shot()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f, LayerMask.GetMask("Enemy")))
        {
            Debug.Log($"{hit}�ɓ�������");
            GameManager.Instance.Shot();
        }
        else
        {
            Debug.Log("���ɂ�������Ȃ�����");
        }
    }

    protected override void AltShot()
    {
        
    }
}
