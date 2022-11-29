using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Tilemap beachTilemap;
    [SerializeField] private Tilemap edgeTilemap;

    private PlayerMovement controls;
    public Vector2 position;

    private void Awake()
    {
        controls = new PlayerMovement();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
    
    void Start()
    {
        controls.Main.Movement.performed += ctx => Move(ctx.ReadValue<Vector2>());
        position = transform.position;
    }

    private void Move(Vector2 direction)
    {
        if (CanMove(direction))
        {
            transform.position += (Vector3) direction;
        }
        position = transform.position;
    }

    private bool CanMove(Vector2 direction)
    {
        Vector3Int gridPosition = beachTilemap.WorldToCell(transform.position + (Vector3) direction);
        if (!beachTilemap.HasTile(gridPosition) || edgeTilemap.HasTile(gridPosition))
            return false;
        return true;
    }

}
