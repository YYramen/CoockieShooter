using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �v���C���[�̓����𐧌䂷��N���X(�e�Ƃ��Ə��Ƃ�)
/// </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField, Tooltip("�U����")] int _atk = 1;
    [SerializeField, Tooltip("�U���Ԋu")] float _interval = 1.5f;
    float _timer = 1.5f;

    [Header("�}�E�X�J�[�\�����Q�[�����ɏ������ǂ����̐ݒ�")]
    [SerializeField] public bool _hideSystemMouseCursor = false;

    [Header("�Ə��֌W")]
    [SerializeField, Tooltip("�Ə���UI")] Image _crosshairImage;
    [SerializeField, Tooltip("�e�̃I�u�W�F�N�g")] GameObject _gunObject;
    public GameObject GunObject => _gunObject;

    [SerializeField, Tooltip("�e�����΂����Ray�̋���")] float _rayRange = 100f;

    //[Header("���ݑ������̕���")]
    //[Tooltip("�e�̔z��"), SerializeField] Base[] _guns;
    //[Tooltip("���ݑ������̕���")] GunBase _currentWepon = default;

    GameManager _coinManager;

    /// <summary>
    /// �Q�[���X�^�[�g���ɌĂ΂��
    /// </summary>
    void StartGame()
    {
        _coinManager = GameManager.Instance;

        Cursor.visible = _hideSystemMouseCursor;

        //_currentWepon = _guns[0];

        GameManager.Instance.SetPlayerController(this);
    }

    private void Start()
    {
        StartGame();
    }

    private void Update()
    {
        _timer += Time.deltaTime;
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
        if (Input.GetButton("Fire1") && _interval < _timer)
        {
            Shot();
        }
    }

    private void Shot()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f, LayerMask.GetMask("Enemy")))
        {
            EnemyController ec = hit.collider.GetComponent<EnemyController>();
            if (ec)
            {
                ec.Hit(_atk);
            }
            Debug.Log($"{this}��{hit}�ɓ�������");
        }

        else
        {
            Debug.Log("���ɂ�������Ȃ�����");
        }
        Debug.DrawRay(ray.origin, ray.direction, Color.red, 1f);

        _timer = 0f;
    }

    public void ChangeAttack(int value)
    {
        _atk += value;
        Debug.Log($"���݂̍U���͂�{_atk}");
    }

    public void ChangeInterval(float value)
    {
        _interval -= value;
        if (_interval < 0.2f)
        {
            _interval = 0.2f;
            return;
        }
    }
}
