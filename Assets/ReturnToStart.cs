using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToStart : MonoBehaviour
{
    // 最初のシーンに戻る
    public void LoadStartScene()
    {
        SceneManager.LoadScene(0); // シーン番号0（ビルド設定の一番上のシーン）をロード
    }
}

