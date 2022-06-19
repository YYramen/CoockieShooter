using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// オートアタックのクラス。
/// </summary>
public class AutoAttackMachine : MonoBehaviour
{
    [SerializeField] float _attackInterval = 1.2f;
    [SerializeField] int _attack = 1;

    private void Start()
    {
        StartCoroutine(AutoAttack());
    }

    IEnumerator AutoAttack()
    {
        while (true)
        {
            if (_attackInterval <= 0f) break;

            yield return new WaitForSeconds(_attackInterval);
            GameManager.Instance.EnemyController.Hit(_attack);
        }
    }
}
