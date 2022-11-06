using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
   // has two floating point values in the x and the y => snake can move in x and y axis
   // snake by default will move right
   private Vector2 _direction = Vector2.right; 

   // uses Systems.Collections.Generic, a list of the snake segments
   private List<Transform> _segments = new List<Transform>(); // instantiate this so Start function can use List
   public Transform segmentPrefab; // normally the type is GameObject, but the list is type Transform

   public int initialSize = 4; // initial size, publiic to tweak in editor

   private void Start() 
   {
      ResetState();
      
      //_segments = new List<Transform>();
      //_segments.Add(this.transform);
   }

   // Unity automatically forces each time the frame updates, depends on your game and your pc
   // handles input from the player (N, S, W, E)
   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.Escape)) {}

      // assigns direction of snake based on input from player
      if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
         _direction = Vector2.up;
      } else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
         _direction = Vector2.left;
      } else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
         _direction = Vector2.down;
      } else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)){
         _direction = Vector2.right;
      }
   }

   // always runs at a fixed time interval
   // impt for physics updates (snake is a physics object - has rigid body, which unity handles w physics handler)
   // moves the snake at a fixed interval, can edit the time interval in Edit > Project Settings > Time > Fixed Timestep
   private void FixedUpdate() 
   {
      for (int i = _segments.Count - 1; i > 0; i--) 
      {
         _segments[i].position = _segments[i - 1].position; // each segment moves into the position of the segment in front of it  => following motion
      }
      // takes snake's current position and adds the direction to it
      this.transform.position = new Vector3(
         Mathf.Round(this.transform.position.x) + _direction.x, // round bc we need integers for pixel based game
         Mathf.Round(this.transform.position.y) + _direction.y,
         0.0f // z value, not needed in 2d
      );
   }

   private void Grow()
   {
      Transform segment = Instantiate(this.segmentPrefab); // creating a segment each time the snake eats
      segment.position = _segments[_segments.Count - 1].position; // grabs the last position in the list

      _segments.Add(segment); // adds this segment to the List
   }

   private void ResetState()
   {
      for (int i = 1; i < _segments.Count; i++) // starting at 1 bc snake head
      {
         Destroy(_segments[i].gameObject); // passes in references to GameObjects to destroy
      }

      _segments.Clear(); // clears the list
      _segments.Add(this.transform); // add back the snake head

      for (int i = 1; i < this.initialSize; i++)
      {
         _segments.Add(Instantiate(this.segmentPrefab));
      }

      this.transform.position = Vector3.zero; // reset the position of the snake to the start
   }

   // calls when the trigger goes off / when snake collides with this
    private void OnTriggerEnter2D(Collider2D other) 
    {
        // good practice: ensures that the thing that collided is the food, not the snake
        if (other.tag == "Food") // the tags can be selected in the inspector window on Unity
        {
            Grow();
        } else if (other.tag == "Obstacle") {
            ResetState();
        } else if (other.tag == "Wall_UD") { // top and bottom, y coord
            this.transform.position = new Vector3(
               Mathf.Round(this.transform.position.x) + _direction.x, // negate y position to start from opposite wall
               -1 * Mathf.Round(this.transform.position.y) + _direction.y,
               0.0f // z value, not needed in 2d
            );
        }
        else if (other.tag == "Wall_LR") { // left and right, x coord
            this.transform.position = new Vector3(
               -1 * Mathf.Round(this.transform.position.x) + _direction.x, // negate x position to start from opposite wall
               Mathf.Round(this.transform.position.y) + _direction.y,
               0.0f // z value, not needed in 2d
            );
        }
    }
}
