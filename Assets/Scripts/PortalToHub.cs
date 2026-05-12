using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalToHub : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

            SceneManager.LoadScene("Level_test");
    }
}