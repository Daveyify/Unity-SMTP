using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreCubesText;
    public TextMeshProUGUI scoreSpheresText;

    public TMP_InputField emailInput;

    void Update()
    {
        if (GameManager.Instance == null) return;

        scoreCubesText.text = "Cubes: " + GameManager.Instance.scoreCubes;
        scoreSpheresText.text = "Spheres: " + GameManager.Instance.scoreSpheres;
    }
    public void SaveEmail()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.playerEmail = emailInput.text;
            Debug.Log("Correo guardado: " + emailInput.text);
        }
    }
}