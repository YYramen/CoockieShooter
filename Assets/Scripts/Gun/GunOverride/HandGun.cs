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
            Debug.Log($"{hit}‚É“–‚½‚Á‚½");
            GameObject.Find("GameManager").GetComponent<GameManager>().AddCoin(hit.collider.gameObject.GetComponent<EnemyController>().Hit());
            // ªâ‘Î‘‚«’¼‚µ‚Ä“KØ‚ÈŒ`‚É‚·‚é‚±‚ÆB
        }
        else
        {
            Debug.Log("‰½‚É‚à“–‚½‚ç‚È‚©‚Á‚½");
        }
    }

    protected override void AltShot()
    {
        
    }
}
