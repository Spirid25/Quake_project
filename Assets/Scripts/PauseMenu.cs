
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Assets.Scripts
{
    internal class PauseMenu : MonoBehaviour
    {
        public GameObject pauseMenuUI;
        public static bool isGamePaused = false;
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (isGamePaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }
        public void Resume()
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            isGamePaused = false;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        public void Pause()
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            isGamePaused = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        public void LoadMenu()
        {
            Debug.Log("Loading menu...");
            SceneManager.LoadScene("Menu");
        }
        public void QuitGame()
        {
            Debug.Log("Quitting game...");
            Application.Quit();
        }
    }
}
