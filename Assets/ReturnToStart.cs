using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToStart : MonoBehaviour
{
    // �ŏ��̃V�[���ɖ߂�
    public void LoadStartScene()
    {
        SceneManager.LoadScene(0); // �V�[���ԍ�0�i�r���h�ݒ�̈�ԏ�̃V�[���j�����[�h
    }
}

