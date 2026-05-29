using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Level_timer : MonoBehaviour
{
    public float timeLeft = 30f;
    public TMP_Text timerText;

    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
        }
        else
        {
            timeLeft = 0;

            LoadNextLevel();
        }

        if (timerText != null)
            timerText.text = "Timer " + Mathf.CeilToInt(timeLeft);
    }

    void LoadNextLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentScene + 1);
    }
}
