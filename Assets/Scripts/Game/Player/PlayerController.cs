using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �v���C���[�̓����𐧌䂷��R���|�[�l���g(�e�Ƃ��Ə��Ƃ�)
/// </summary>
public class PlayerController : MonoBehaviour
{
    [Header("�}�E�X�J�[�\�����Q�[�����ɏ������ǂ����̐ݒ�")]
    [SerializeField] bool _hideSystemMouseCursor = false;

    [Header("�Ə��֌W")]
    [SerializeField, Tooltip("�Ə���UI")] Image _crosshairImage;
    [SerializeField, Tooltip("�e�̃I�u�W�F�N�g")] GameObject _gunObject;
    [SerializeField, Tooltip("�e�����΂����Ray�̋���")] float _rayRange = 100f;

    [Header("���ݑ������̕���")]
    [Tooltip("�e�̔z��"), SerializeField] GunBase[] _guns;
    [Tooltip("���ݑ������̕���")] GunBase _currentWepon = default;

    CoinManager _coinManager;

    /// <summary>
    /// �Q�[���X�^�[�g���ɌĂ΂��
    /// </summary>
    void StartGame()
    {
        _coinManager = CoinManager.Instance;
        Cursor.visible = _hideSystemMouseCursor;

        if (_hideSystemMouseCursor)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        _currentWepon = _guns[0];
    }

    private void Start()
    {
        StartGame();
    }

    private void Update()
    {
        Crosshair();
    }

    void Crosshair()
    {
        // �Ə��̏���
        _crosshairImage.rectTransform.position = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // �e�̌���������ς���
        _gunObject.transform.rotation = Quaternion.LookRotation(ray.direction);

        if (Physics.Raycast(ray, out hit, 1f, LayerMask.GetMask("Gun")))
        {
            Cursor.visible = false;
        }
        else
        {
            Cursor.visible = true;
        }

        // ���N���b�N(Shot)��������
        if (Input.GetButtonDown("Fire1"))
        {
            _currentWepon.Shot();
        }

        //�E�N���b�N(AltShot)��������
        if (Input.GetButtonDown("Fire2"))
        {
            //AltShot();
        }
    }
}
