using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// インベントリに今プレイヤーが持っているアイテムを表示するコンポーネント
/// </summary>
public class Inventory : MonoBehaviour
{
    [SerializeField] RectTransform _itemSpace = default;
    [SerializeField] GameObject _itemPrefab = default;

    private void Start()
    {
        
    }
}
