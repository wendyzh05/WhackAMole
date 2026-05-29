using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static string lastLevel;
    
    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            // Save which level we're in
            lastLevel = SceneManager.GetActiveScene().name;
            
            // Load the pause menu
            SceneManager.LoadScene("PauseMenu");
        }
    }
    
    public static string GetLastLevel()
    {
        return lastLevel;
    }
}
