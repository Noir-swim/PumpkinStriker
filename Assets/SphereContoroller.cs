using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SphereController : MonoBehaviour
{
    private Rigidbody rb;

    public InputField inputX;
    public InputField inputY;
    public InputField inputZ;
    public Button shootButton;
    public Button respawnButton;

    private LineRenderer lineRenderer;
    private List<Vector3> positions = new List<Vector3>(); // �O���̓_���L�^���郊�X�g

    public GameObject spherePrefab; // �{�[���̃v���n�u
    private Vector3 initialPosition; // �{�[���̏����ʒu
    private float screenBoundary = 30f; // ��ʊO�Ƃ݂Ȃ�������臒l

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        lineRenderer = GetComponent<LineRenderer>();

        if (rb == null)
        {
            Debug.LogError("Rigidbody component is missing from the Sphere object.");
        }
        else
        {
            Application.targetFrameRate = 60;

            // Rigidbody���ꎞ�I�ɒ�~
            rb.isKinematic = true;

            // �����ʒu��ۑ�
            initialPosition = transform.position;

            // �{�^���Ƀ��X�i�[��ǉ�
            shootButton.onClick.AddListener(OnShootButtonClicked);
            respawnButton.onClick.AddListener(Respawn); // Respawn�{�^���Ƀ��X�i�[��ǉ�
        }
    }

    void OnShootButtonClicked()
    {
        float x = float.Parse(inputX.text);
        float y = float.Parse(inputY.text);
        float z = float.Parse(inputZ.text);

        Vector3 direction = new Vector3(x, y, z);

        // Rigidbody���ēx�A�N�e�B�u�ɂ��ĕ������Z��L����
        rb.isKinematic = false;

        Shoot(direction);
    }

    public void Shoot(Vector3 dir)
    {
        if (rb != null)
        {
            // ���ʂɉ����Ĉ�u�ŗ͂�^����^��
            rb.AddForce(dir * rb.mass, ForceMode.Impulse);
            positions.Clear(); // �O���̋L�^���N���A
            lineRenderer.positionCount = 0; // LineRenderer�̓_�̐������Z�b�g
        }
        else
        {
            Debug.LogError("Rigidbody component is missing from the Sphere object.");
        }
    }

    void Update()
    {
        // �O����`������
        if (rb != null && rb.velocity.magnitude > 0.01f)
        {
            positions.Add(transform.position); // ���݈ʒu�����X�g�ɒǉ�
            lineRenderer.positionCount = positions.Count;
            lineRenderer.SetPositions(positions.ToArray());
        }

        // ��ʊO�`�F�b�N
        if (Mathf.Abs(transform.position.x) > screenBoundary ||
            Mathf.Abs(transform.position.y) > screenBoundary ||
            Mathf.Abs(transform.position.z) > screenBoundary)
        {
            Respawn();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cube"))
        {
            Respawn();
        }
    }

    public void Respawn()
    {
        Debug.Log("Respawn called. Creating new Sphere at position: " + initialPosition);

        // �V�����{�[���𐶐�
        GameObject newBall = Instantiate(spherePrefab, initialPosition, Quaternion.identity);
        Debug.Log("New ball created at position: " + newBall.transform.position);

        // �V�����{�[���ɐ���X�N���v�g��ǉ����A������
        newBall.GetComponent<SphereController>().inputX = inputX;
        newBall.GetComponent<SphereController>().inputY = inputY;
        newBall.GetComponent<SphereController>().inputZ = inputZ;
        newBall.GetComponent<SphereController>().shootButton = shootButton;
        newBall.GetComponent<SphereController>().respawnButton = respawnButton;

        // ���݂̃{�[�����j�������O�ɓK�؂ɏ���
        Destroy(gameObject);
    }
}
