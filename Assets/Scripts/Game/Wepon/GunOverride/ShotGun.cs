using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : GunBase
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
               for (int i = 0; i < 5; i++)
                {
                    ec.Hit(_atk);
                }
            }
            Debug.Log($"{this}‚ª{hit}‚É“–‚½‚Á‚½");
        }

        else
        {
            Debug.Log("‰½‚É‚à“–‚½‚ç‚È‚©‚Á‚½");
        }
        Debug.DrawRay(ray.origin, ray.direction, Color.red, 1f);
    }
}
