using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Trash : MonoBehaviour
{

    [SerializeField] private Tilemap beachTilemap;
    [SerializeField] private Tilemap edgeTilemap;

    public Sprite[] trashImages;

    SceneLoader scene; 
    GameSession game;
    TrashSpawner spawner;


    // Start is called before the first frame update
    void Start()
    {
        scene = FindObjectOfType<SceneLoader>();
        game = FindObjectOfType<GameSession>();
        spawner = FindObjectOfType<TrashSpawner>();
    }

    void Awake()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D c2d)
    {
        if (c2d.CompareTag("Player")) {
            game.Add();
            Destroy(gameObject);
            if (game.GetTotal() >= spawner.GetWinAmount())
            {
                scene.Win();
            }
            spawner.SpawnTrash();
        }
    }

    public void Place()
    {
        Place(new Vector3(Random.Range(-8, 7) + (float)0.5, Random.Range(-3, 2) + (float)0.5, 0));
    }

    private void Place(Vector3 position)
    {
        if (CanPlace(position))
        {
            System.Random r = new System.Random();
            GetComponent<SpriteRenderer>().sprite = trashImages[r.Next(0, trashImages.Length)];
            transform.position = position;
        }

    }

    private bool CanPlace(Vector3 position)
    {
        foreach (Trash trash in FindObjectsOfType<Trash>()) 
        {
            if (trash.transform.position == position)
            {
                return false;
            }
        }

        return true;
    }    
}
