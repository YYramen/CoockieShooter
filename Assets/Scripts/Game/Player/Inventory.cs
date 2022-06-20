using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// インベントリに今プレイヤーが持っているアイテムを表示するコンポーネント
/// </summary>
public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject _itemPrefab = default;
    List<GameObject> _items = new List<GameObject>();

    private void Start()
    {
        GameManager.Instance.SetInventory(this);

        for (int i = 0; i < GameData.ItemTable.Count; i++)
        {
            var go = Instantiate(_itemPrefab, Vector3.zero , Quaternion.identity , this.transform);
            go.GetComponent<PopUi>()._id = i;
            go.SetActive(false);
            _items.Add(go);
        }
    }

    public void ActiveItem(int itemindex)
    {
        _items[itemindex].SetActive(true);
        UpdateItem(itemindex);
    }

    public void UpdateItem(int itemindex)
    {
        _items[itemindex].GetComponent<Item>().SetItem(GameData.ItemTable[itemindex].Name, GameManager.Instance.WeponManager.GetLevel(itemindex + 1) + 1);
    }
}
