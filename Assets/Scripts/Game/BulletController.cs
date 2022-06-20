using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BulletController : MonoBehaviour
{
    [SerializeField] Vector3 _enemyPos;
    float _time = 1f;

    private void Start()
    {
        this.transform.DOMove(_enemyPos, _time).SetLoops(-1);
    }
}
