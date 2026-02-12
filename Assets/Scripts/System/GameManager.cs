using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int blockCount;
    [SerializeField] private GameObject retryButton;
    [SerializeField] private GameObject titleButton;
    [SerializeField] private GameObject gameclearText;
    [SerializeField] private GameObject gameoverText;
    [SerializeField] private GameObject startButton;

    private enum GameResult { Clear,Over }

    private void Start()
    {
        startButton.SetActive(true);
        blockCount = CountTagObject("Block");
        Time.timeScale = 0f;
    }

    /// <summary>
    /// タグがついたオブジェクトを数える
    /// </summary>
    private int CountTagObject(string tagname)
    {
        return GameObject.FindGameObjectsWithTag(tagname).Length;
    }

    /// <summary>
    /// ブロックの数を減らす
    /// </summary>
    public void UnregisterBlock()
    {
        blockCount--;
        if (blockCount <= 0)
        {
            GameClear();
        }
    }

    /// <summary>
    /// ゲームクリア処理
    /// </summary>
    public void GameClear()
    {
        Time.timeScale = 0f;
        ShowUI(GameResult.Clear);
    }


     /// <summary>
     /// ゲームオーバー処理
     /// </summary>
    public void GameOver()
    {
        Time.timeScale = 0f;
        ShowUI(GameResult.Over);
    }

    /// <summary>
    /// UIを表示する
    /// </summary>
    void ShowUI(GameResult result)
    {
        retryButton.SetActive(true);
        titleButton.SetActive(true);

        switch(result)
        {
            case GameResult.Clear:
                gameclearText.SetActive(true);
                break;
            case GameResult.Over:
                gameoverText.SetActive(true);
                break;
        }
    }

    /// <summary>
    /// UIを非表示にする
    /// </summary>
    void HideUI()
    {
        retryButton.SetActive(false);
        titleButton.SetActive(false);
        gameclearText.SetActive(false);
        gameoverText.SetActive(false);
        startButton.SetActive(false);
    }
    /// <summary>
    /// ゲームを開始する
    /// </summary>
    public void GameStart()
    {
        HideUI();
        Time.timeScale = 1f;
    }
}
