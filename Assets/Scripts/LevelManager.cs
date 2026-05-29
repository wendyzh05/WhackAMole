using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private GameObject levelEventSystem;
    
    private void Start()
    {
        levelEventSystem = GameObject.Find("EventSystem");
    }
    
    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            // Disable the Level scene's EventSystem
            if (levelEventSystem != null)
                levelEventSystem.SetActive(false);
            
            SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive);
            Time.timeScale = 0f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
    
    public void EnableEventSystem()
    {
        if (levelEventSystem != null)
            levelEventSystem.SetActive(true);
    }
}
