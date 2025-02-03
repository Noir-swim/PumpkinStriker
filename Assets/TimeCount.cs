using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    public int countdownMinutes = 3;
    private float countdownSeconds;

    // Countdown�̎��Ԃ�\������Text
    public Text timeText;

    // Game Over���b�Z�[�W��\������Text
    public GameObject GameOverUI;

    private bool isTimeUp = false;

    private void Start()
    {
        // �J�E���g�_�E���̏����ݒ�
        countdownSeconds = countdownMinutes * 60;

        // Game Over�e�L�X�g��������ԂŔ�\���ɂ���
        //if (gameOverText != null)
        //{
            //gameOverText.gameObject.SetActive(false);
        //}
    }

    void Update()
    {
        // �J�E���g�_�E����0���傫���ꍇ�A���Ԃ����炵�ĕ\�����X�V
        if (countdownSeconds > 0)
        {
            countdownSeconds -= Time.deltaTime;
            if (countdownSeconds < 0) countdownSeconds = 0; // 0�b�ȉ��ɂȂ�Ȃ��悤�ɐ���
        }

        // �J�E���g�_�E�����Ԃ�mm:ss�̃t�H�[�}�b�g�ŕ\��
        var span = new TimeSpan(0, 0, (int)countdownSeconds);
        if (timeText != null)
        {
            timeText.text = span.ToString(@"mm\:ss");
        }

        // �J�E���g�_�E�����I�������ꍇ�̏���
        if (countdownSeconds == 0 && !isTimeUp)
        {
            isTimeUp = true;
            Debug.Log("Time's up!");

            // Game Over�e�L�X�g��\��
            if (GameOverUI != null)
            {
                GameOverUI.gameObject.SetActive(true);
            }
        }
    }
}