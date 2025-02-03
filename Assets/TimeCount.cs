using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    public int countdownMinutes = 3;
    private float countdownSeconds;

    // Countdownの時間を表示するText
    public Text timeText;

    // Game Overメッセージを表示するText
    public GameObject GameOverUI;

    private bool isTimeUp = false;

    private void Start()
    {
        // カウントダウンの初期設定
        countdownSeconds = countdownMinutes * 60;

        // Game Overテキストを初期状態で非表示にする
        //if (gameOverText != null)
        //{
            //gameOverText.gameObject.SetActive(false);
        //}
    }

    void Update()
    {
        // カウントダウンが0より大きい場合、時間を減らして表示を更新
        if (countdownSeconds > 0)
        {
            countdownSeconds -= Time.deltaTime;
            if (countdownSeconds < 0) countdownSeconds = 0; // 0秒以下にならないように制御
        }

        // カウントダウン時間をmm:ssのフォーマットで表示
        var span = new TimeSpan(0, 0, (int)countdownSeconds);
        if (timeText != null)
        {
            timeText.text = span.ToString(@"mm\:ss");
        }

        // カウントダウンが終了した場合の処理
        if (countdownSeconds == 0 && !isTimeUp)
        {
            isTimeUp = true;
            Debug.Log("Time's up!");

            // Game Overテキストを表示
            if (GameOverUI != null)
            {
                GameOverUI.gameObject.SetActive(true);
            }
        }
    }
}