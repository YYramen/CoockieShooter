using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Gun�̊��N���X�AOverride���Ďg��
/// </summary>
public class GunBase : MonoBehaviour
{
    [SerializeField] protected int _atk = 1;
    [SerializeField] LayerMask _layerMask;

    /// <summary>
    /// ���N���b�N����Gun�̏���
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
            Debug.Log($"{hit}�ɓ�������");
        }
        else
        {
            Debug.Log("���ɂ�������Ȃ�����");
        }

        OnShot();
    }

    protected virtual void OnShot()
    {

    }

    /// <summary>
    /// �E�N���b�N����Gun�̏���
    /// </summary>
    public virtual void AltShot(GameManager coinManager)
    {
        
    }
}
