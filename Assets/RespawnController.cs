using UnityEngine;
using UnityEngine.UI;

public class RespawnController : MonoBehaviour
{
    public Button respawnButton; // UI��Respawn�{�^��
    public SphereController sphereController; // SphereController�̎Q��

    void Start()
    {
        if (respawnButton != null && sphereController != null)
        {
            // �{�^���Ƀ��X�i�[��ǉ����āA�{�^�����N���b�N���ꂽ�Ƃ���Respawn���\�b�h���Ăяo��
            respawnButton.onClick.AddListener(OnRespawnButtonClicked);
        }
        else
        {
            Debug.LogError("RespawnButton or SphereController is not assigned.");
        }
    }

    void OnRespawnButtonClicked()
    {
        // SphereController��Respawn���\�b�h���Ăяo��
        sphereController.Respawn();
    }
}
