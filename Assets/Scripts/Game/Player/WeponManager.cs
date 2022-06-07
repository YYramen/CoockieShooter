using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class WeponManager : MonoBehaviour
{
    [Serializable]
    class WeponSetting 
    {
        public int Id;
        public GameObject Prefab;
    }
    List<WeponType> _weponTypes = new List<WeponType>();

    float _rad = 0f;
    int _createCount = 0;
}
