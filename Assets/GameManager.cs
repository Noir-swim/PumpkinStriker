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
        Debug.Log("‰Šú‚ÌCube‚Ì”: " + cubes.Count);
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
            Debug.Log("‚·‚×‚Ä‚ÌCube‚ª”j‰ó‚³‚ê‚Ü‚µ‚½I");
            ShootUI.SetActive(false);

            // 2•bŒã‚ÉIllustScene‚É‘JˆÚ
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
