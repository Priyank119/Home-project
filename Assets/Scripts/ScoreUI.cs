using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    public DeathBall _DeathBall;
    public Goblin _goblin;
    public Mremireh _mremireh;

    public Image healthBar;
    public TMP_Text healthParsentage;
    string parsentageSign = "%";

    private bool isHealing;
    private float totalScore;
    private float health;
    private float timeElapsed = 0;
    public float healingDuration = 1;

    // Update is called once per frame
    public void getTotalScore()
    {
        totalScore = _DeathBall.getScore + _goblin.getScore + _mremireh.getScore;
        health = healthBar.fillAmount;
        isHealing = true;
    }
    private void Update()
    {
        if (timeElapsed < healingDuration && isHealing == true)
        {
            float t = timeElapsed / healingDuration;
            float healing = Mathf.Lerp(health, totalScore, t);
            healthBar.fillAmount = healing / 100;
            healthParsentage.text = string.Concat(healing.ToString(), "%");
            timeElapsed += Time.deltaTime;
            if (timeElapsed >= healingDuration)
            {
                isHealing = false;
                health = healing;
            }
        }
    }
}
