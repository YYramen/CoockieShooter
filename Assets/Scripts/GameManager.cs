using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Player のコインを管理するクラス。管理している物がコインなのでそのうちGameManagerになりそう。
/// </summary>
public class GameManager : SingletonMonoBehaviour<GameManager>
{
    [Header("現在所持しているコインの数"), SerializeField] public long _currentCoins = 0;
    [SerializeField, Tooltip("コイン数を表示させるテキスト")] Text _coinText;
    WeponManager _weponManager;
    public WeponManager Wepon => GameManager.Instance._weponManager;
    public void SetWeponManager(WeponManager wepon) { _weponManager = wepon; }

    public long Currentcoins => _currentCoins;


    /// <summary>
    /// コインが増えるときに呼ばれる関数、取得したコインをTextに表示する
    /// </summary>
    /// <param name="coin"></param>
    public void AddCoin(long coin)  //敵を倒した時、ダメージを与えたときにコインをプレイヤーに与える
    {
       _currentCoins += coin;
        _coinText.text = _currentCoins.ToString();
    }

    /// <summary>
    /// アイテムを購入する処理
    /// </summary>
    /// <param name="item"></param>
    /// <param name="cost"></param>
    public void Buy(ItemTable item, int cost)
    {
        _currentCoins -= cost;
        switch (item.Type)
        {
            //case ItemType.Wepon:  //TODO アイテムを買う処理を作れ。

        }
    }
}
