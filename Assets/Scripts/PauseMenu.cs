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
        
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    
    public void ResumeGame()
    {
        if (audioSource != null && closePanelSound != null)
            audioSource.PlayOneShot(closePanelSound);
        
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
        SceneManager.UnloadSceneAsync("PauseMenu");
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
        if (audioSource != null && quitGameSound != null)
            audioSource.PlayOneShot(quitGameSound);
        
        Time.timeScale = 1f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        
        SceneManager.UnloadSceneAsync("PauseMenu");
        SceneManager.LoadScene("StartMenu");
    }
}
