using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static int score = 0;

    public void setScore(int newScore)
    {
        score = newScore;
    }

    public int getScore()
    {
        return score;
    }
}
