using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Shop��OnOff��؂�ւ���N���X
/// </summary>
public class ShopToggle : MonoBehaviour
{
    [SerializeField] GameObject _shopPanel = default;

    bool _isEnable;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            _isEnable = !_isEnable;
            _shopPanel.SetActive(_isEnable);
        }
    }
}
