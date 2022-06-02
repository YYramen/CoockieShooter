using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// ゲームを管理するスクリプト、適当なオブジェクトにアタッチして設定すれば動く
/// </summary>
public class GameManager : SingletonMonoBehaviour<GameManager>
{
    //[Header("マウスカーソルをゲーム中に消すかどうかの設定")]
    //[SerializeField] bool _hideSystemMouseCursor = false;

    [Header("敵関連")]
    [SerializeField, Tooltip("敵がいるレイヤー")] LayerMask _enemyLayer = default;
    [Tooltip("現在照準で狙われている敵")] EnemyController _currentTarget;

    [Header("スコア(コイン関係)")]
    [SerializeField, Tooltip("コイン数を表示させるテキスト")] Text _coinText;
    [Tooltip("所持している総コイン数")] [SerializeField] long _coin = 0;

    [Header("ゲームスタート時に呼ばれる")]
    [SerializeField, Tooltip("ゲームスタート時に呼び出す処理")] UnityEngine.Events.UnityEvent _onGameStart = null;

    

    void Start()
    {
        
    }

    /// <summary>
    /// コインが増えるときに呼ばれる関数、取得したコインをTextに表示する
    /// </summary>
    /// <param name="coin"></param>
    public void AddCoin(long coin)  //敵を倒した時、ダメージを与えたときにコインをプレイヤーに与える
    {
        _coin += coin;
        _coinText.text = _coin.ToString();
    }

    private void OnApplicationQuit()
    {

    }
}
