using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleSpawner : MonoBehaviour
{

    [SerializeField] float minSpawnDelay = 0f;
    [SerializeField] float maxSpawnDelay = 0.5f;
    [SerializeField] Turtle turtlePrefab;
    bool spawn = true;
    SceneLoader scene;
    private float currentSpeed = 1;

    void Awake()
    {
        scene = FindObjectOfType<SceneLoader>();
    }


    IEnumerator Start()
    {
        while (spawn)
        {
            if (!scene.GetGameStatus())
            {
                StopSpawning();
            }

            SetSpawnLocation(new Vector3(Random.Range(-8, 7) + (float)0.5, -6 + (float)0.5, 0));
            SpawnTurtle();
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
        }
    }

    public void StopSpawning()
    {
        spawn = false;
    }

    private void SpawnTurtle()
    {
        Turtle newTurtle = Instantiate(turtlePrefab, transform.position, transform.rotation) as Turtle;
        newTurtle.SetMovementSpeed(currentSpeed);
        newTurtle.transform.parent = transform;
    }

    private void SetSpawnLocation(Vector3 position)
    {
        transform.position = position;
    }

    public void SetSpeed(float newSpeed)
    {
        currentSpeed = newSpeed;
    }
}
