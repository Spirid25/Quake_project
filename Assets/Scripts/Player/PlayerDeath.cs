using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public GameObject deathUI;
    Health health;
    bool alreadyDied = false;
    void Start()
    {
        health = GetComponent<Health>();
        if (health != null) {
            health.onDeath += OnDeath;
            Debug.Log("SUBSCRIBED");
        } else {
            Debug.LogError("NO HEALTH");
        }
        if (deathUI == null)
        {
            Debug.LogError("NO UI");
        }
    }

    void OnDeath()
    {
        if (alreadyDied) return;
        alreadyDied = true;
        Debug.Log("PLAYER DIE");
        deathUI.SetActive(true);

        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;

        GetComponent<PlayerMovement>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        //GetComponent<MouseMovement>().enabled = false;
    }
}