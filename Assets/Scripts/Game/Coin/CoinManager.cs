using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Player のコインを管理する
/// </summary>
public class CoinManager : SingletonMonoBehaviour<CoinManager>
{
    [Header("現在所持しているコインの数"), SerializeField]  long _currentCoins = 0;
    [SerializeField, Tooltip("コイン数を表示させるテキスト")] Text _coinText;

    /// <summary>
    /// コインが増えるときに呼ばれる関数、取得したコインをTextに表示する
    /// </summary>
    /// <param name="coin"></param>
    public void AddCoin(long coin)  //敵を倒した時、ダメージを与えたときにコインをプレイヤーに与える
    {
        _currentCoins += coin;
        _coinText.text = _currentCoins.ToString();
    }
}
