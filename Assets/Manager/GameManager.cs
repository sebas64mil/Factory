using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool IsPaused = false;
    public static event Action OnPauseKeyPressed;

    [Header("Transici�n entre escenas")]
    [SerializeField] private Animator transitionAnimator;
    [SerializeField] private float transitionTime = 1f;

    public static GameManager instance;

    private bool isTransitioning = false;
    private float timer = 0f;
    private string nextScene = "";

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            OnPauseKeyPressed?.Invoke();

        // Si hay transici�n en curso, avanza el temporizador
        if (isTransitioning)
        {
            timer += Time.unscaledDeltaTime; // usa tiempo real, no afectado por Time.timeScale

            if (timer >= transitionTime)
            {
                SceneManager.LoadScene(nextScene);
                isTransitioning = false;
                timer = 0f;
            }
        }
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

    // ---------------- TRANSICI�N ----------------
    public static void LoadScene(string sceneName)
    {
        if (instance == null) return;

        instance.StartTransition(sceneName);
    }

    public static void RestartScene()
    {
        if (instance == null) return;

        string currentScene = SceneManager.GetActiveScene().name;
        instance.StartTransition(currentScene);
    }

    private void StartTransition(string sceneName)
    {
        Time.timeScale = 1;
        nextScene = sceneName;

        if (transitionAnimator != null)
            transitionAnimator.SetTrigger("StartTransition");

        isTransitioning = true;
        timer = 0f;
    }

    public static void QuitGame()
    {
        Application.Quit();
    }
}
