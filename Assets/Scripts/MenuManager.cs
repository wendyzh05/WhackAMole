using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject creditsPanel;
    
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip buttonClickSound;
    [SerializeField] private AudioClip playGameSound;
    [SerializeField] private AudioClip exitGameSound;
    
    private bool isCreditsVisible = false;
    
    private void Start()
    {
        if (creditsPanel != null)
            creditsPanel.SetActive(false);
        
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
    }
    
    public void PlayGame()
    {
        if (playGameSound != null && audioSource != null)
            audioSource.PlayOneShot(playGameSound);
        else if (buttonClickSound != null && audioSource != null)
            audioSource.PlayOneShot(buttonClickSound);
        
        SceneManager.LoadScene("map scene");
    }
    
    public void ToggleCreditsPanel()
    {
        if (buttonClickSound != null && audioSource != null)
            audioSource.PlayOneShot(buttonClickSound);
        
        if (creditsPanel != null)
        {
            isCreditsVisible = !isCreditsVisible;
            creditsPanel.SetActive(isCreditsVisible);
        }
    }
    
    public void QuitGame()
    {
        if (exitGameSound != null && audioSource != null)
            audioSource.PlayOneShot(exitGameSound);
        else if (buttonClickSound != null && audioSource != null)
            audioSource.PlayOneShot(buttonClickSound);
        
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }
}