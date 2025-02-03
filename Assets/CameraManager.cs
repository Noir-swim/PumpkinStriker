using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera camera1;
    public Camera camera2;
    private Camera activeCamera;

    void Start()
    {
        // 最初に使用するカメラを指定（例えば、Camera1）
        activeCamera = camera1;
        camera1.enabled = true;
        camera2.enabled = false;
    }

    // ボタンのOnClickイベントに紐付ける関数
    public void SwitchCamera()
    {
        if (activeCamera == camera1)
        {
            camera1.enabled = false;
            camera2.enabled = true;
            activeCamera = camera2;
        }
        else
        {
            camera2.enabled = false;
            camera1.enabled = true;
            activeCamera = camera1;
        }
    }
}
