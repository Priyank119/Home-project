using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class ScoreUI : MonoBehaviour
{
    private DeathBall _DeathBall;
    private Goblin _goblin;
    private Mremireh _mremireh;
    private float totalScore;

    public Image healthBar;
    public TMP_Text healthParsentage;

    string parsentageSign = "%";

    // Update is called once per frame
    public void getTotalScore()
    {
        totalScore = _DeathBall._getScore + _goblin.getScore + _mremireh.getScore;
        healthBar.fillAmount = totalScore / 10;
        healthParsentage.text = string.Concat(totalScore.ToString(), "%");
    }
}
