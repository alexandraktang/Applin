using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    // 1. needs to make sure food spawns in the bounds of the game (created GridArea to make sure food cannot spawn outside/in walls)
    public BoxCollider2D gridArea; // can drag the GridArea game object into the inspector

    private void Start()
    {
        RandomizePosition();
    }

    private void RandomizePosition()
    {
        Bounds bounds = this.gridArea.bounds; // defines the boundaries that the food can spawn within

        float x = Random.Range(bounds.min.x, bounds.max.x); // randomly determines an x coordinate within the bounds
        float y = Random.Range(bounds.min.y, bounds.max.y); // randomly determines a y coordinate within the bounds

        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f); // moves the food to said position
    }

    // calls when the trigger goes off / when snake collides with this
    private void OnTriggerEnter2D(Collider2D other) 
    {
        // good practice: ensures that the thing that collided is the snake and not something else
        if (other.tag == "Player") // the tags can be selected in the inspector window on Unity
        {
            RandomizePosition();
        }
    }
}
