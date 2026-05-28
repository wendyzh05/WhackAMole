using UnityEngine;
using TMPro;

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
            
        }

        if (timerText != null)
            timerText.text = "Time Remaining: " + Mathf.CeilToInt(timeLeft);
    }
}
