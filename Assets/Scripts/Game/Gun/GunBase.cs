using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Gunの基底クラス、Overrideして使う
/// </summary>
public class GunBase : MonoBehaviour
{
    [SerializeField] protected int _atk = 1;
    [SerializeField] LayerMask _layerMask;

    /// <summary>
    /// 左クリック時のGunの処理
    /// </summary>
    public void Shot()   
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

        OnShot();
    }

    protected virtual void OnShot()
    {

    }

    /// <summary>
    /// 右クリック時のGunの処理
    /// </summary>
    public virtual void AltShot(GameManager coinManager)
    {
        
    }
}
