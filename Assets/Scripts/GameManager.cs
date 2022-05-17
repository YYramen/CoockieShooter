using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// ゲームを管理するスクリプト、適当なオブジェクトにアタッチして設定すれば動く
/// </summary>
public class GameManager : MonoBehaviour
{
    /// <summary>照準のUI(Image)</summary>
    [SerializeField] Image _crosshairImage;
    /// <summary>銃のオブジェクト</summary>
    [SerializeField] GameObject _gunObject;
    /// <summary> 銃から飛ばされるRayの距離 </summary>
    [SerializeField] float _rayRange = 100f;
    /// <summary>ゲームスタート時に呼び出す処理</summary>
    [SerializeField] UnityEngine.Events.UnityEvent _onGameStart = null;

    public void StartGame() //ゲームプレイを初期化する
    {


    }

    void Start()
    {
        
    }

    void Update()
    {
        // 照準の処理
        _crosshairImage.rectTransform.position = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _rayRange))
        {
            _gunObject.transform.LookAt(hit.point);    // 銃の方向を変えている
        }
    }

    void AddCoin()  //敵を倒した時にコインをプレイヤーに与える
    {

    }

    private void OnApplicationQuit()
    {
        
    }
}
