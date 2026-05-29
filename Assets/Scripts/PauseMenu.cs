using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject menuPanel;
    public GameObject volumePanel;
    public GameObject creditsPanel;
    
    private void Start()
    {
        menuPanel.SetActive(true);
        volumePanel.SetActive(false);
        creditsPanel.SetActive(false);
    }
    
    public void ResumeGame()
    {
        // Get the level name we saved
        string levelName = LevelManager.GetCurrentLevel();
        
        // Unpause everything
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        AudioListener.pause = false;
        
        // Unload the pause menu
        SceneManager.UnloadSceneAsync("PauseMenu");
    }
    
    public void OpenVolumePanel()
    {
        menuPanel.SetActive(false);
        volumePanel.SetActive(true);
        creditsPanel.SetActive(false);
    }
    
    public void OpenCreditsPanel()
    {
        menuPanel.SetActive(false);
        volumePanel.SetActive(false);
        creditsPanel.SetActive(true);
    }
    
    public void CloseVolumePanel()
    {
        menuPanel.SetActive(true);
        volumePanel.SetActive(false);
    }
    
    public void CloseCreditsPanel()
    {
        menuPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }
    
    public void ExitToMainMenu()
    {
        // Unpause everything
        Time.timeScale = 1f;
        AudioListener.pause = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        
        // Unload pause menu
        SceneManager.UnloadSceneAsync("PauseMenu");
        
        // Load start menu
        SceneManager.LoadScene("StartMenu");
    }
}
