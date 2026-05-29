using UnityEngine;
using TMPro;

public class ComboManager : MonoBehaviour
{
    public int xp = 0;
    public int combo = 0;

    public float comboResetTime = 5f;
    private float comboTimer;

    public TMP_Text xpText;
    public TMP_Text comboText;
    public TMP_Text spellText;

    void Update()
    {
        if (combo > 0)
        {
            comboTimer -= Time.deltaTime;

            if (comboTimer <= 0)
            {
                ResetCombo();
            }
        }
    }

    public void RegisterHit()
    {
        combo++;
        comboTimer = comboResetTime;

        int gainedXP = 10;

        if (combo >= 10)
        {
            gainedXP += 50;
            ShowSpell("Mischief Managed!");
        }
        else if (combo >= 5)
        {
            gainedXP += 25;
            ShowSpell("Expelliarmus Combo!");
        }
        else if (combo >= 3)
        {
            gainedXP += 10;
            ShowSpell("Stupefy Streak!");
        }
        else
        {
            ShowSpell("Nice hit!");
        }

        xp += gainedXP;
        UpdateUI();
    }

    public void RegisterMiss()
    {
        ResetCombo();
        ShowSpell("Combo broken!");
        xp -= 10;
    }

    void ResetCombo()
    {
        combo = 0;
        comboTimer = 0;
        UpdateUI();
    }

    void ShowSpell(string message)
    {
        if (spellText != null)
            spellText.text = message;
    }

    void UpdateUI()
    {
        if (xpText != null)
            xpText.text = "House Points: " + xp;

        if (comboText != null)
            comboText.text = "Combo: x" + combo;
    }
}
