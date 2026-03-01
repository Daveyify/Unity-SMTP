using UnityEngine;

public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameObject.CompareTag("Cube"))
            {
                GameManager.Instance.AddCube();
            }
            else if (gameObject.CompareTag("Ball"))
            {
                GameManager.Instance.AddSphere();
            }

            Destroy(gameObject);
        }
    }
}