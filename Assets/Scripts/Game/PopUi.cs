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
    public int _id = 0;

    private void Start()
    {
        _uiPanel.SetActive(false);
    }

    private void Update()
    {
        if (_uiPanel.activeSelf)
        {
            if (_id == 0)
            {
                _DpsUi.text = $"���݂̍U���́F{GameManager.Instance.WeponManager.CurrentDPS[_id]}";
            }
            else if (_id == 1)
            {
                _DpsUi.text = $"���݂̏e�̔��ˑ��x�F{GameManager.Instance.PlayerController.Interval}";
            }
            else
            {
                _damageUi.text = $"���܂ŗ^�����_���[�W�F{GameManager.Instance.WeponManager.DamageLog[_id]}";
                _DpsUi.text = $"���݂̍U���́F{GameManager.Instance.WeponManager.CurrentDPS[_id]}";
            }
            //_damageUi.text = $"���܂ŗ^�����_���[�W�F{GameManager.Instance.WeponManager.DamageLog[_id]}";
            //_DpsUi.text = $"���݂̍U���́F{GameManager.Instance.WeponManager.CurrentDPS[_id]}";
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _uiPanel.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _uiPanel.SetActive(false);
    }
}
