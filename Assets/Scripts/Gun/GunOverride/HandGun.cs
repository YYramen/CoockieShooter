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
            Debug.Log($"{hit}に当たった");
            GameObject.Find("GameManager").GetComponent<GameManager>().AddCoin(hit.collider.gameObject.GetComponent<EnemyController>().Hit());
            // ↑絶対書き直して適切な形にすること。
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
