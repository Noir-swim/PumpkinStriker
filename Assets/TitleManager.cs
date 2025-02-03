using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadGameScene : MonoBehaviour
{
    // UI�{�^����Inspector�Őݒ�ł���悤�ɂ���
    public Button NomalButton;
    public Button PracticeButton;
    public Button HeardButton;

    void Start()
    {
        // NomalButton��GameScene��ǂݍ���
        NomalButton.onClick.AddListener(LoadNomalGameScene);

        // PracticeButton��PracticeScene��ǂݍ���
        PracticeButton.onClick.AddListener(LoadPracticeScene); // �V�������X�i�[��ǉ�

        // PracticeButton��PracticeScene��ǂݍ���
        HeardButton.onClick.AddListener(LoadHeardScene); // �V�������X�i�[��ǉ�
    }

    // GameScene��ǂݍ��ރ��\�b�h
    void LoadNomalGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    // PracticeScene��ǂݍ��ރ��\�b�h
    void LoadPracticeScene()
    {
        SceneManager.LoadScene("PracticeScene");
    }

    //HardScene��ǂݍ��ރ��\�b�h
    void LoadHeardScene()
    {
        SceneManager.LoadScene("HeardScene");
    }
}
