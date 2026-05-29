using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject levelSelectPanel;
    public GameObject creditsPanel;
    
    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip openPanelSound;
    public AudioClip closePanelSound;
    public AudioClip quitGameSound;
    
    private void Start()
    {
        levelSelectPanel.SetActive(false);
        creditsPanel.SetActive(false);
        Time.timeScale = 1f;
        AudioListener.pause = false;
    }
    
    public void OpenLevelSelect()
    {
        audioSource.PlayOneShot(openPanelSound);
        
        levelSelectPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }
    
    public void CloseLevelSelect()
    {
        audioSource.PlayOneShot(closePanelSound);
        
        levelSelectPanel.SetActive(false);
    }
    
    public void LoadLevel(int levelIndex)
    {
        audioSource.PlayOneShot(closePanelSound);
        
        switch(levelIndex)
        {
            case 1:
                SceneManager.LoadScene("Level1");
                break;
            case 2:
                SceneManager.LoadScene("Level2");
                break;
            case 3:
                SceneManager.LoadScene("Level3");
                break;
        }
    }
    
    public void OpenCredits()
    {
        audioSource.PlayOneShot(openPanelSound);
        
        creditsPanel.SetActive(true);
        levelSelectPanel.SetActive(false);
    }
    
    public void CloseCredits()
    {
        audioSource.PlayOneShot(closePanelSound);
        
        creditsPanel.SetActive(false);
    }
    
    public void QuitGame()
    {
        audioSource.PlayOneShot(quitGameSound);
        
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }
}
