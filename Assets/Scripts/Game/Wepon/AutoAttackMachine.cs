using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// タレットとドローンにアタッチして使う、オートアタックのクラス。
/// </summary>
public class AutoAttackMachine : MonoBehaviour
{
    [SerializeField] int _id = 0;
    [SerializeField] WeponType _weponType;
    [SerializeField] float _attackInterval = 1.2f;
    [SerializeField] int _attackNum = 1;

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
            GameManager.Instance.AddCoin(_weponType, _attackNum);
        }
    }
}
