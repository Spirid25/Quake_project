using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalToHell : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        SceneManager.LoadScene("m3");
    }
}