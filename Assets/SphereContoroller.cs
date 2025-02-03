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
    private List<Vector3> positions = new List<Vector3>(); // 軌道の点を記録するリスト

    public GameObject spherePrefab; // ボールのプレハブ
    private Vector3 initialPosition; // ボールの初期位置
    private float screenBoundary = 30f; // 画面外とみなす距離の閾値

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

            // Rigidbodyを一時的に停止
            rb.isKinematic = true;

            // 初期位置を保存
            initialPosition = transform.position;

            // ボタンにリスナーを追加
            shootButton.onClick.AddListener(OnShootButtonClicked);
            respawnButton.onClick.AddListener(Respawn); // Respawnボタンにリスナーを追加
        }
    }

    void OnShootButtonClicked()
    {
        float x = float.Parse(inputX.text);
        float y = float.Parse(inputY.text);
        float z = float.Parse(inputZ.text);

        Vector3 direction = new Vector3(x, y, z);

        // Rigidbodyを再度アクティブにして物理演算を有効化
        rb.isKinematic = false;

        Shoot(direction);
    }

    public void Shoot(Vector3 dir)
    {
        if (rb != null)
        {
            // 質量に応じて一瞬で力を与える運動
            rb.AddForce(dir * rb.mass, ForceMode.Impulse);
            positions.Clear(); // 軌道の記録をクリア
            lineRenderer.positionCount = 0; // LineRendererの点の数をリセット
        }
        else
        {
            Debug.LogError("Rigidbody component is missing from the Sphere object.");
        }
    }

    void Update()
    {
        // 軌道を描く処理
        if (rb != null && rb.velocity.magnitude > 0.01f)
        {
            positions.Add(transform.position); // 現在位置をリストに追加
            lineRenderer.positionCount = positions.Count;
            lineRenderer.SetPositions(positions.ToArray());
        }

        // 画面外チェック
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

        // 新しいボールを生成
        GameObject newBall = Instantiate(spherePrefab, initialPosition, Quaternion.identity);
        Debug.Log("New ball created at position: " + newBall.transform.position);

        // 新しいボールに制御スクリプトを追加し、初期化
        newBall.GetComponent<SphereController>().inputX = inputX;
        newBall.GetComponent<SphereController>().inputY = inputY;
        newBall.GetComponent<SphereController>().inputZ = inputZ;
        newBall.GetComponent<SphereController>().shootButton = shootButton;
        newBall.GetComponent<SphereController>().respawnButton = respawnButton;

        // 現在のボールが破棄される前に適切に処理
        Destroy(gameObject);
    }
}
