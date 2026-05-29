using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject menuCanvas;
    public GameObject scoreCanvas;
    public GameObject menuPanel;
    public GameObject volumePanel;
    public GameObject creditsPanel;
    
    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip menuOpenSound;
    public AudioClip buttonClickSound;
    
    private bool isPaused = false;
    
    private void Start()
    {
        menuCanvas.SetActive(false);
        scoreCanvas.SetActive(true);
        menuPanel.SetActive(true);
        volumePanel.SetActive(false);
        creditsPanel.SetActive(false);
        
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame && !isPaused)
        {
            PauseGame();
        }
    }
    
    public void PauseGame()
    {
        if (isPaused) return;
        
        isPaused = true;
        
        menuCanvas.SetActive(true);
        scoreCanvas.SetActive(false);
        menuPanel.SetActive(true);
        volumePanel.SetActive(false);
        creditsPanel.SetActive(false);
        
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        
        if (audioSource != null && menuOpenSound != null)
            audioSource.PlayOneShot(menuOpenSound);
        
        AudioListener.pause = true;
    }
    
    public void ResumeGame()
    {
        if (!isPaused) return;
        
        if (audioSource != null && buttonClickSound != null)
            audioSource.PlayOneShot(buttonClickSound);
        
        isPaused = false;
        
        menuCanvas.SetActive(false);
        scoreCanvas.SetActive(true);
        
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        AudioListener.pause = false;
    }
    
    public void OpenVolumePanel()
    {
        if (audioSource != null && buttonClickSound != null)
            audioSource.PlayOneShot(buttonClickSound);
        
        menuPanel.SetActive(false);
        volumePanel.SetActive(true);
        creditsPanel.SetActive(false);
    }
    
    public void OpenCreditsPanel()
    {
        if (audioSource != null && buttonClickSound != null)
            audioSource.PlayOneShot(buttonClickSound);
        
        menuPanel.SetActive(false);
        volumePanel.SetActive(false);
        creditsPanel.SetActive(true);
    }
    
    public void CloseVolumePanel()
    {
        if (audioSource != null && buttonClickSound != null)
            audioSource.PlayOneShot(buttonClickSound);
        
        menuPanel.SetActive(true);
        volumePanel.SetActive(false);
    }
    
    public void CloseCreditsPanel()
    {
        if (audioSource != null && buttonClickSound != null)
            audioSource.PlayOneShot(buttonClickSound);
        
        menuPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }
    
    public void ExitToMainMenu()
    {
        if (audioSource != null && buttonClickSound != null)
            audioSource.PlayOneShot(buttonClickSound);
        
        Time.timeScale = 1f;
        AudioListener.pause = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        
        SceneManager.LoadScene("StartMenu");
    }
}
