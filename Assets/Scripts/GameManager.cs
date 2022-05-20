using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// �Q�[�����Ǘ�����X�N���v�g�A�K���ȃI�u�W�F�N�g�ɃA�^�b�`���Đݒ肷��Γ���
/// </summary>
public class GameManager : MonoBehaviour
{
    [Header("�}�E�X�J�[�\�����Q�[�����ɏ������ǂ����̐ݒ�")]
    [SerializeField] bool _hideSystemMouseCursor = false;
    [Header("�G�֘A")]
    [SerializeField, Tooltip("�G�����郌�C���[")] LayerMask _enemyLayer = default;
    [Tooltip("���ݏƏ��ő_���Ă���G")] EnemyController _currentTarget;
    [Header("�X�R�A(�R�C���֌W)")]
    [SerializeField, Tooltip("�R�C������\��������e�L�X�g")] Text _coinText;
    [Tooltip("�������Ă��鑍�R�C����")] long _coin = 0;
    [Header("�Ə��֌W")]
    [SerializeField, Tooltip("�Ə���UI")] Image _crosshairImage;
    [SerializeField, Tooltip("�e�̃I�u�W�F�N�g")] GameObject _gunObject;
    [SerializeField, Tooltip("�e�����΂����Ray�̋���")] float _rayRange = 100f;
    [Header("�Q�[���X�^�[�g���ɌĂ΂��")]
    [SerializeField, Tooltip("�Q�[���X�^�[�g���ɌĂяo������")] UnityEngine.Events.UnityEvent _onGameStart = null;

    public void StartGame() //�Q�[���v���C������������
    {
        Cursor.visible = !_hideSystemMouseCursor;
    }

    void Start()
    {
        StartGame();
    }

    void Update()
    {
        // �Ə��̏���
        _crosshairImage.rectTransform.position = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        //// �Ə��ɓG�����邩�ǂ����𒲂ׂ�
        //bool isEnemyTargeted = Physics.Raycast(ray, out hit, _rayRange, _enemyLayer);
        //_currentTarget = isEnemyTargeted ? hit.collider.gameObject.GetComponent<EnemyController>() : null;

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

        // ���N���b�N(�ˌ�)���������ɉ��ɓ����������ŏ�����ς���
        if (Input.GetMouseButtonDown(0) || Input.GetButtonDown("AltFire"))
        {
            Shot();
        }
    }

    void Shot()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f, LayerMask.GetMask("Enemy")))
        {
            Debug.Log($"{hit}�ɓ�������");
            AddCoin(hit.collider.gameObject.GetComponent<EnemyController>().Hit());
        }
        else
        {
            Debug.Log("���ɂ�������Ȃ�����");
        }
    }


    /// <summary>
    /// �R�C����������Ƃ��ɌĂ΂��֐��A�擾�����R�C����Text�ɕ\������
    /// </summary>
    /// <param name="coin"></param>
    void AddCoin(long coin)  //�G��|�������A�_���[�W��^�����Ƃ��ɃR�C�����v���C���[�ɗ^����
    {
        _coin += coin;
        _coinText.text = _coin.ToString();

    }

    private void OnApplicationQuit()
    {

    }
}
