using UnityEngine;
using UnityEngine.UI;

public class RespawnController : MonoBehaviour
{
    public Button respawnButton; // UIのRespawnボタン
    public SphereController sphereController; // SphereControllerの参照

    void Start()
    {
        if (respawnButton != null && sphereController != null)
        {
            // ボタンにリスナーを追加して、ボタンがクリックされたときにRespawnメソッドを呼び出す
            respawnButton.onClick.AddListener(OnRespawnButtonClicked);
        }
        else
        {
            Debug.LogError("RespawnButton or SphereController is not assigned.");
        }
    }

    void OnRespawnButtonClicked()
    {
        // SphereControllerのRespawnメソッドを呼び出す
        sphereController.Respawn();
    }
}
