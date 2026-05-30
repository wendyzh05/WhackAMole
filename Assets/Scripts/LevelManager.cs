using UnityEngine;
using UnityEngine.InputSystem;

public class LevelManager : MonoBehaviour
{
    public GameObject pauseMenuPrefab;
    private GameObject activePauseMenu;
    private bool isPaused = false;
    
    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (!isPaused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }
    
    public void PauseGame()
    {
        if (isPaused) return;
        
        isPaused = true;
        activePauseMenu = Instantiate(pauseMenuPrefab);
        Time.timeScale = 0f;
        AudioListener.pause = true;  // Pause all audio
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    
    public void ResumeGame()
    {
        if (!isPaused) return;
        
        isPaused = false;
        Time.timeScale = 1f;
        AudioListener.pause = false;  // Resume all audio
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
        // Destroy the pause menu
        if (activePauseMenu != null)
        {
            Destroy(activePauseMenu);
            activePauseMenu = null;
        }
    }
    
    public void ExitToMainMenu()
    {
        // Clean up
        if (activePauseMenu != null)
        {
            Destroy(activePauseMenu);
            activePauseMenu = null;
        }
        
        Time.timeScale = 1f;
        AudioListener.pause = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        UnityEngine.SceneManagement.SceneManager.LoadScene("StartMenu");
    }
}
