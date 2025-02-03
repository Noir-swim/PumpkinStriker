using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera camera1;
    public Camera camera2;
    private Camera activeCamera;

    void Start()
    {
        // �ŏ��Ɏg�p����J�������w��i�Ⴆ�΁ACamera1�j
        activeCamera = camera1;
        camera1.enabled = true;
        camera2.enabled = false;
    }

    // �{�^����OnClick�C�x���g�ɕR�t����֐�
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
