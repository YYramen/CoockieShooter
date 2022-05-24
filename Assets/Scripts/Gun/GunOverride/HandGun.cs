using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGun : GunBase
{
    protected override void Shot()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f, LayerMask.GetMask("Enemy")))
        {
            Debug.Log($"{hit}�ɓ�������");
            GameObject.Find("GameManager").GetComponent<GameManager>().AddCoin(hit.collider.gameObject.GetComponent<EnemyController>().Hit());
            // ����Ώ��������ēK�؂Ȍ`�ɂ��邱�ƁB
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
