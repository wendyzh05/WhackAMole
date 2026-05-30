using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuUI : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject menuPanel;
    public GameObject volumePanel;
    public GameObject creditsPanel;
    
    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip openPanelSound;
    public AudioClip closePanelSound;
    
    private LevelManager levelManager;
    
    private void Start()
    {
        menuPanel.SetActive(true);
        volumePanel.SetActive(false);
        creditsPanel.SetActive(false);
        
        levelManager = FindAnyObjectByType<LevelManager>();
        if (levelManager == null)
        {
            Debug.LogError("LevelManager not found!");
        }
    }
    
    public void ResumeGame()
    {
        if (audioSource != null && closePanelSound != null)
            audioSource.PlayOneShot(closePanelSound);
        
        if (levelManager != null)
        {
            levelManager.ResumeGame();
        }
        else
        {
            Time.timeScale = 1f;
            AudioListener.pause = false;
            Destroy(gameObject);
        }
    }
    
    public void OpenVolumePanel()
    {
        if (audioSource != null && openPanelSound != null)
            audioSource.PlayOneShot(openPanelSound);
        
        menuPanel.SetActive(false);
        volumePanel.SetActive(true);
        creditsPanel.SetActive(false);
    }
    
    public void OpenCreditsPanel()
    {
        if (audioSource != null && openPanelSound != null)
            audioSource.PlayOneShot(openPanelSound);
        
        menuPanel.SetActive(false);
        volumePanel.SetActive(false);
        creditsPanel.SetActive(true);
    }
    
    public void CloseVolumePanel()
    {
        if (audioSource != null && closePanelSound != null)
            audioSource.PlayOneShot(closePanelSound);
        
        menuPanel.SetActive(true);
        volumePanel.SetActive(false);
    }
    
    public void CloseCreditsPanel()
    {
        if (audioSource != null && closePanelSound != null)
            audioSource.PlayOneShot(closePanelSound);
        
        menuPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }
    
    public void ExitToMainMenu()
    {
        if (audioSource != null && closePanelSound != null)
            audioSource.PlayOneShot(closePanelSound);
        
        if (levelManager != null)
        {
            levelManager.ExitToMainMenu();
        }
        else
        {
            Time.timeScale = 1f;
            AudioListener.pause = false;
            SceneManager.LoadScene("StartMenu");
        }
    }
}
