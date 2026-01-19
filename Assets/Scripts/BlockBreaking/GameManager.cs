using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int blockCount;

    private void Start()
    {
        blockCount = CountTagObject("Block");
        Debug.Log(blockCount);
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

    void GameClear()
    {
        Debug.Log("GameClear!!");
        Time.timeScale = 0f;
    }


     /// <summary>
     /// ゲームオーバー処理
     /// </summary>
    public void GameOver()
    {
        Debug.Log("GameOver...");
        Time.timeScale = 0f;
    }
}
