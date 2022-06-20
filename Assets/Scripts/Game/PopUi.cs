using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PopUi : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] GameObject _uiPanel;
    [SerializeField] Text _damageUi;
    [SerializeField] Text _DpsUi;
    Vector2 _offset = new Vector2(0, 10);
    public int _id = 0;

    private void Update()
    {
        if (_uiPanel.activeSelf)
        {
            _damageUi.text = $"���܂ŗ^�����_���[�W�F{GameManager.Instance.WeponManager.DamageLog[_id]}";
            _DpsUi.text = $"���݂̈�񂲂Ƃ̍U����{GameManager.Instance.WeponManager.CurrentDPS[_id]}";
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _uiPanel.transform.position = eventData.position + _offset;
        _uiPanel.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _uiPanel.SetActive(false);
    }
}