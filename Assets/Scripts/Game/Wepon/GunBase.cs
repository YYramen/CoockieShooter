using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Gun�̊��N���X�AOverride���Ďg��
/// </summary>
public class GunBase : MonoBehaviour
{
    [SerializeField, Tooltip("�З�")] protected int _atk = 1;

    /// <summary>
    /// ���N���b�N����Gun�̏���
    /// </summary>
    public virtual void Shot()   
    {
        
    }
}
