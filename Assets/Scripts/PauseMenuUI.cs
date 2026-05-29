using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject menuPanel;
    public GameObject volumePanel;
    public GameObject creditsPanel;
    
    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip openPanelSound;
    public AudioClip closePanelSound;
    public AudioClip quitGameSound;
    
    private void Start()
    {
        menuPanel.SetActive(true);
        volumePanel.SetActive(false);
        creditsPanel.SetActive(false);
        
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    
    public void ResumeGame()
    {
        audioSource.PlayOneShot(closePanelSound);
        
        string levelToLoad = LevelManager.GetLastLevel();
        
        if (!string.IsNullOrEmpty(levelToLoad))
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }
    
    public void OpenVolumePanel()
    {
        audioSource.PlayOneShot(openPanelSound);
        
        menuPanel.SetActive(false);
        volumePanel.SetActive(true);
        creditsPanel.SetActive(false);
    }
    
    public void OpenCreditsPanel()
    {
        audioSource.PlayOneShot(openPanelSound);
        
        menuPanel.SetActive(false);
        volumePanel.SetActive(false);
        creditsPanel.SetActive(true);
    }
    
    public void CloseVolumePanel()
    {
        audioSource.PlayOneShot(closePanelSound);
        
        menuPanel.SetActive(true);
        volumePanel.SetActive(false);
    }
    
    public void CloseCreditsPanel()
    {
        audioSource.PlayOneShot(closePanelSound);
        
        menuPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }
    
    public void ExitToMainMenu()
    {
        audioSource.PlayOneShot(quitGameSound);
        
        SceneManager.LoadScene("StartMenu");
    }
}
