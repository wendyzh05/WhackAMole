using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

// press escape to open menu (play open menu sound) (also pauses the game)
// press resume game button to close menu (play a sound) (unpauses the game)
// press quit button to exit game (play a sound)
// press volume button to open volume panel (play a sound)
// press credits button to open credits panel (play a sound)

public class PauseManager : MonoBehaviour
{
    [Header("UI Panels")]
    [SerializeField] private GameObject menuCanvas;
    [SerializeField] private GameObject scoreCanvas;
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject volumePanel;
    [SerializeField] private GameObject creditsPanel;
    
    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip menuOpenSound;
    [SerializeField] private AudioClip buttonClickSound;
    
    private bool isPaused = false;
    
    private void Start()
    {
        if (menuCanvas != null)
            menuCanvas.SetActive(false);
        
        if (scoreCanvas != null)
            scoreCanvas.SetActive(true);
        
        if (menuPanel != null)
            menuPanel.SetActive(true);
        if (volumePanel != null)
            volumePanel.SetActive(false);
        if (creditsPanel != null)
            creditsPanel.SetActive(false);
        
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
    }
    
    private void Update()
    {
        if (Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (!isPaused)
            {
                PauseGame();
            }
        }
    }
    
    public void PauseGame()
    {
        if (isPaused) return;
        
        isPaused = true;
        
        if (menuCanvas != null)
            menuCanvas.SetActive(true);
        if (scoreCanvas != null)
            scoreCanvas.SetActive(false);
        
        if (menuPanel != null)
            menuPanel.SetActive(true);
        if (volumePanel != null)
            volumePanel.SetActive(false);
        if (creditsPanel != null)
            creditsPanel.SetActive(false);
        
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        
        if (menuOpenSound != null && audioSource != null)
            audioSource.PlayOneShot(menuOpenSound);
        
        AudioListener.pause = true;
    }
    
    public void ResumeGame()
    {
        if (!isPaused) return;
        
        if (buttonClickSound != null && audioSource != null)
            audioSource.PlayOneShot(buttonClickSound);
        
        isPaused = false;
        
        if (menuCanvas != null)
            menuCanvas.SetActive(false);
        if (scoreCanvas != null)
            scoreCanvas.SetActive(true);
        
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        AudioListener.pause = false;
    }
    
    public void OpenVolumePanel()
    {
        if (buttonClickSound != null && audioSource != null)
            audioSource.PlayOneShot(buttonClickSound);
        
        if (menuPanel != null)
            menuPanel.SetActive(false);
        if (volumePanel != null)
            volumePanel.SetActive(true);
        if (creditsPanel != null)
            creditsPanel.SetActive(false);
    }
    
    public void OpenCreditsPanel()
    {
        if (buttonClickSound != null && audioSource != null)
            audioSource.PlayOneShot(buttonClickSound);
        
        if (menuPanel != null)
            menuPanel.SetActive(false);
        if (volumePanel != null)
            volumePanel.SetActive(false);
        if (creditsPanel != null)
            creditsPanel.SetActive(true);
    }
    
    public void CloseVolumePanel()
    {
        if (buttonClickSound != null && audioSource != null)
            audioSource.PlayOneShot(buttonClickSound);
        
        if (menuPanel != null)
            menuPanel.SetActive(true);
        if (volumePanel != null)
            volumePanel.SetActive(false);
    }
    
    public void CloseCreditsPanel()
    {
        if (buttonClickSound != null && audioSource != null)
            audioSource.PlayOneShot(buttonClickSound);
        
        if (menuPanel != null)
            menuPanel.SetActive(true);
        if (creditsPanel != null)
            creditsPanel.SetActive(false);
    }
    
    public void ExitToMainMenu()
    {
        if (buttonClickSound != null && audioSource != null)
            audioSource.PlayOneShot(buttonClickSound);
        
        Time.timeScale = 1f;
        AudioListener.pause = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        
        SceneManager.LoadScene("StartMenu");
    }
}