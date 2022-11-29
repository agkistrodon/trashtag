using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turtle : MonoBehaviour
{
    float currentSpeed = 1.5f;
    GameSession game;
    TurtleSpawner spawner;

    private void Start()
    {
        spawner = FindObjectOfType<TurtleSpawner>();
        game = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * currentSpeed);
    }


    private void OnTriggerEnter2D(Collider2D c2d)
    {
        GameObject otherObject = c2d.gameObject;

        if (c2d.CompareTag("Trash"))
        {
            game.LoseALife();
            spawner.SetSpeed(currentSpeed += (float) 0.5 * (game.GetTotal() / 50));
            Destroy(otherObject);
            Destroy(gameObject);
        }

    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

}
