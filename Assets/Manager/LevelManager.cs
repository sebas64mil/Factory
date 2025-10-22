using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject PauseMenu;

    private void Start()
    {
        PauseMenu.SetActive(false);
        GameManager.GamePause(false);
        GameManager.CursorVisible(false);
    }

    public void PauseMenuVisible(bool state)
    {
        PauseMenu.SetActive(state);
        GameManager.GamePause(state);
        GameManager.CursorVisible(state);
    }
}
