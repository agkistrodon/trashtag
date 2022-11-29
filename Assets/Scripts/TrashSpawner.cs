using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{

    [SerializeField] Trash trashPrefab;
    [SerializeField] GameSession game;

    private int trashSpawned = 0;
    private const int winTrashAmount = 200;

    private void Awake()
    {
    }

    private void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            SpawnTrash();
        }

    }

    public void SpawnTrash()
    {
        if (trashSpawned < winTrashAmount)
        {
            Trash newTrash = Instantiate(trashPrefab, transform.position, transform.rotation);
            newTrash.transform.parent = transform;
            newTrash.Place();
            trashSpawned++;
        }
    }

    public int GetWinAmount()
    {
        return winTrashAmount;
    }

    public void UpdateTrashSpawned()
    {
        trashSpawned--;
    }
}
