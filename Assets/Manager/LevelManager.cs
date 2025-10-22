using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject PauseMenu;
    private bool isMenuOpen = false;

    private void OnEnable()
    {
        GameManager.OnPauseKeyPressed += TogglePauseMenu;
    }

    private void OnDisable()
    {
        GameManager.OnPauseKeyPressed -= TogglePauseMenu;
    }

    private void Start()
    {
        PauseMenu.SetActive(false);
        GameManager.GamePause(false);
        GameManager.CursorVisible(false);
    }

    private void TogglePauseMenu()
    {
        isMenuOpen = !isMenuOpen;
        PauseMenuVisible(isMenuOpen);
    }

    public void PauseMenuVisible(bool state)
    {
        PauseMenu.SetActive(state);
        GameManager.GamePause(state);
        GameManager.CursorVisible(state);
    }
}
