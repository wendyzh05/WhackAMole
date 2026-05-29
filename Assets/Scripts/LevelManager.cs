using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static string currentLevel;
    
    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            // Save which level we're in
            currentLevel = SceneManager.GetActiveScene().name;
            
            // Load the pause menu
            SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive);
            
            // Pause the game
            Time.timeScale = 0f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            AudioListener.pause = true;
        }
    }
    
    public static string GetCurrentLevel()
    {
        return currentLevel;
    }
}
