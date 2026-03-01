using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int scoreCubes = 0;
    public int scoreSpheres = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddCube()
    {
        scoreCubes++;
    }

    public void AddSphere()
    {
        scoreSpheres++;
    }

    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}