using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// ShopのOnOffを切り替えるクラス
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
