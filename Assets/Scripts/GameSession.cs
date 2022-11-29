using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GameSession : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] GameObject livesImage;

    
    // [SerializeField] Trash trash;

    public Sprite[] livesArray;

    private static int total = 0;
    private int lives = 3;
    private SceneLoader scene;
    private Score score;

    private TrashSpawner trashSpawner;

    // Start is called before the first frame update
    private void Start()
    {
        score = FindObjectOfType<Score>();
        trashSpawner = FindObjectOfType<TrashSpawner>();
        scene = FindObjectOfType<SceneLoader>();
        UpdateLivesImage();
    }

    private void Awake()
    {
        lives = 3;
        total = 0;
    }

    private void UpdateText()
    {
        scoreText.text = total.ToString();
    }

    public int GetTotal()
    {
        return total;
    }

    public void Add()
    {
        total++;
        UpdateText();
    }

    public void LoseALife()
    {
        lives--;
        trashSpawner.UpdateTrashSpawned();
        if (lives == 0)
        {
            score.setScore(total);
            scene.GameOver();
            return;
        }
        UpdateLivesImage();
    }

    private void UpdateLivesImage()
    {
        int index = lives - 1;
        if (index >= 0)
        {
            livesImage.GetComponent<SpriteRenderer>().sprite = livesArray[lives - 1];
        }
        
    }

}
