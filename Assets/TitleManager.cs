using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadGameScene : MonoBehaviour
{
    // UIボタンをInspectorで設定できるようにする
    public Button NomalButton;
    public Button PracticeButton;
    public Button HeardButton;

    void Start()
    {
        // NomalButtonでGameSceneを読み込む
        NomalButton.onClick.AddListener(LoadNomalGameScene);

        // PracticeButtonでPracticeSceneを読み込む
        PracticeButton.onClick.AddListener(LoadPracticeScene); // 新しいリスナーを追加

        // PracticeButtonでPracticeSceneを読み込む
        HeardButton.onClick.AddListener(LoadHeardScene); // 新しいリスナーを追加
    }

    // GameSceneを読み込むメソッド
    void LoadNomalGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    // PracticeSceneを読み込むメソッド
    void LoadPracticeScene()
    {
        SceneManager.LoadScene("PracticeScene");
    }

    //HardSceneを読み込むメソッド
    void LoadHeardScene()
    {
        SceneManager.LoadScene("HeardScene");
    }
}
