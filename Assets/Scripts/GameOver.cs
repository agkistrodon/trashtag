using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GameOver : MonoBehaviour
{

    [SerializeField] Text finalScoreText;

    static int total;

    void Awake()
    {
        total = FindObjectOfType<Score>().getScore();
    }

    // Start is called before the first frame update
    void Start()
    {
        finalScoreText.text = "Score: " + total + "/200";
    }

}
