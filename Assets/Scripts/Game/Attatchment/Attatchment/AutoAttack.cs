using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAttack : AttatchmentBase
{
    [SerializeField] GameObject _prefab;
    [SerializeField] Vector3 _pos;
    Vector3 _offset = Vector3.zero;
    [SerializeField] float _offsetX = 0.1f;
    [SerializeField] float _offsetY = 0.1f;
    int _count = 0;
    public override void OnExecute()
    {
        Instantiate(_prefab, _pos + _offset, Quaternion.identity);
        _count++;

        if( _count % 10 == 0)
        {
            _offset.x = 0f;
            _offset.y += _offsetY;
        }
        else
        {
            _offset.x += _offsetX;
        }
    }
}
