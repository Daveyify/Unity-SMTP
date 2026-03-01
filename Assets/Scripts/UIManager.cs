using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreCubesText;
    public TextMeshProUGUI scoreSpheresText;

    void Update()
    {
        if (GameManager.Instance == null) return;

        scoreCubesText.text = "Cubes: " + GameManager.Instance.scoreCubes;
        scoreSpheresText.text = "Spheres: " + GameManager.Instance.scoreSpheres;
    }
}