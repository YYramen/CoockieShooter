using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Gunの基底クラス
/// </summary>
public class GunBase : MonoBehaviour
{
    /// <summary>
    /// 左クリック時のGunの処理
    /// </summary>
    protected virtual void Shot()
    {

    }

    /// <summary>
    /// 右クリック時のGunの処理
    /// </summary>
    protected virtual void AltShot()
    {
        
    }
}
