using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool GamePaused = false;
    public int scoreCubes = 0;
    public int scoreSpheres = 0;

    public string playerEmail;

    public bool sentCubes = false;
    public bool sentSpheres = false;
    public bool sentWin = false;

    private SimpleEmailSender emailSender;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            emailSender = new SimpleEmailSender();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddCube()
    {
        scoreCubes++;
        CheckEmailEvents();
    }

    public void AddSphere()
    {
        scoreSpheres++;
        CheckEmailEvents();
    }

    void CheckEmailEvents()
    {
        if (string.IsNullOrEmpty(playerEmail))
        {
            Debug.Log("No mail registered.");
            return;
        }

        if (scoreCubes >= 10 && !sentCubes)
        {
            sentCubes = true;
            emailSender.SendEmail(
                "Evento 10 Cubos",
                "Has alcanzado 10 cubos en el juego."
            );
        }

        if (scoreSpheres >= 10 && !sentSpheres)
        {
            sentSpheres = true;
            emailSender.SendEmail(
                "Evento 10 Esferas",
                "Has alcanzado 10 esferas en el juego."
            );
        }

        if (scoreCubes >= 10 && scoreSpheres >= 10 && !sentWin)
        {
            ChangeScene("Win");
            sentWin = true;
            emailSender.SendEmail(
                "¡Ganaste!",
                "Has completado 10 cubos y 10 esferas. ¡Felicidades!"
            );
        }
    }

    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void Exit()
    {
        Application.Quit();
    }
}