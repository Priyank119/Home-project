using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour
{
    private ScoreUI _scoreUI;
    public float getScore;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "arrow")
        {
            _scoreUI.getTotalScore();
        }
    }
}
