using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool IsPaused = false;
    public static event Action OnPauseKeyPressed;

    public static GameManager instance;

    private void Update()
    {
        // Detecta tecla ESC y lanza el evento
        if (Input.GetKeyDown(KeyCode.Escape))
            OnPauseKeyPressed?.Invoke();
    }

    public static void CursorVisible(bool state)
    {
        Cursor.visible = state;
        Cursor.lockState = state ? CursorLockMode.None : CursorLockMode.Locked;
    }

    public static void GamePause(bool state)
    {
        IsPaused = state;
        Time.timeScale = state ? 0 : 1;
    }

    public static void LoadScene(string sceneName)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }

    public static void RestartScene()
    {
        Time.timeScale = 1;
        string currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
    }

    public static void QuitGame()
    {
        Application.Quit();
    }
}
