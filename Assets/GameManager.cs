using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CubeManager : MonoBehaviour
{
    public List<GameObject> cubes;
    public GameObject GameOverUI;
    public GameObject ShootUI;

    void Start()
    {
        cubes = new List<GameObject>(GameObject.FindGameObjectsWithTag("Cube"));
        Debug.Log("初期のCubeの数: " + cubes.Count);
    }

    void Update()
    {
        CheckCubesStatus();
    }

    void CheckCubesStatus()
    {
        cubes.RemoveAll(cube => !cube.activeSelf);

        if (cubes.Count == 0)
        {
            Debug.Log("すべてのCubeが破壊されました！");
            ShootUI.SetActive(false);

            // 2秒後にIllustSceneに遷移
            Invoke("LoadIllustScene", 1f);
        }
    }

    void LoadIllustScene()
    {
        SceneManager.LoadScene("IllustScene");
    }

    public void GameRetry()
    {
        SceneManager.LoadScene("HeardScene");
    }
}
