using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �v���C���[�̓����𐧌䂷��N���X(�e�Ƃ��Ə��Ƃ�)
/// </summary>
public class PlayerController : MonoBehaviour
{
    [Header("�}�E�X�J�[�\�����Q�[�����ɏ������ǂ����̐ݒ�")]
    [SerializeField] public bool _hideSystemMouseCursor = false;

    [Header("�Ə��֌W")]
    [SerializeField, Tooltip("�Ə���UI")] Image _crosshairImage;
    [SerializeField, Tooltip("�e�̃I�u�W�F�N�g")] GameObject _gunObject;
    [SerializeField, Tooltip("�e�����΂����Ray�̋���")] float _rayRange = 100f;

    [Header("���ݑ������̕���")]
    [Tooltip("�e�̔z��"), SerializeField] GunBase[] _guns;
    [Tooltip("���ݑ������̕���")] GunBase _currentWepon = default;

    GameManager _coinManager;

    /// <summary>
    /// �Q�[���X�^�[�g���ɌĂ΂��
    /// </summary>
    void StartGame()
    {
        _coinManager = GameManager.Instance;

        Cursor.visible = _hideSystemMouseCursor;

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


        // �e�̌���������ς���
        _gunObject.transform.rotation = Quaternion.LookRotation(ray.direction);

        // ���N���b�N(Shot)��������
        if (Input.GetButtonDown("Fire1"))
        {
            _currentWepon.Shot();
        }

        //�E�N���b�N(AltShot)��������
        if (Input.GetButtonDown("Fire2"))
        {
            _currentWepon.AltShot();
        }
    }
}
