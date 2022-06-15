using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Gunの基底クラス、Overrideして使う
/// </summary>
public class GunBase : MonoBehaviour
{
    [SerializeField] protected int _atk = 1;

    /// <summary>
    /// 左クリック時のGunの処理
    /// </summary>
    public virtual void Shot()   
    {
        
    }

    /// <summary>
    /// 右クリック時のGunの処理
    /// </summary>
    public virtual void AltShot()
    {
        
    }
}
