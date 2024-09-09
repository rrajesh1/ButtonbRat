using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : MonoBehaviour
{
    // Rat's walking speed
    public float speed = 5;  

    // Sprites for different walking directions
    public Sprite spriteUp;
    public Sprite spriteDown;
    public Sprite spriteRight;

    public GameObject strawberry;  
    public GameObject banana;
    public GameObject rotten_apple;
    public GameObject button;

    Rigidbody2D myrb2d;  
    SpriteRenderer spriteRenderer;  

    // Start is called before the first frame update
    void Start()
    {
        myrb2d = GetComponent<Rigidbody2D>();  
        spriteRenderer = GetComponent<SpriteRenderer>(); 
    }

    // Update is called once per frame
    void Update()
    {
        // Setting movement input for Player 1
        float movementX = 0;
        float movementY = 0;

        if (Input.GetKey(KeyCode.UpArrow)) movementY = 1;  // Move up
        if (Input.GetKey(KeyCode.DownArrow)) movementY = -1;  // Move down
        if (Input.GetKey(KeyCode.LeftArrow)) movementX = -1;  // Move left
        if (Input.GetKey(KeyCode.RightArrow)) movementX = 1;  // Move right

        Vector2 movement = new Vector2(movementX, movementY).normalized;
        myrb2d.linearVelocity = movement * speed;

        UpdateRatSprite(movement);

        // Placing button with Right Shift
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            PlaceButton();
        }

    }

    void UpdateRatSprite(Vector2 movement)
    {
        // Moving up
        if (movement.y > 0)  
        {
            spriteRenderer.sprite = spriteUp;
            spriteRenderer.flipX = false;
        }

        // Moving down
        else if (movement.y < 0) 
        {
            spriteRenderer.sprite = spriteDown;
            spriteRenderer.flipX = false;
        }

        // Moving right
        else if (movement.x > 0)  
        {
            spriteRenderer.sprite = spriteRight;
            spriteRenderer.flipX = false;
        }

        // Moving left
        else if (movement.x < 0)  
        {
            spriteRenderer.sprite = spriteRight;
            spriteRenderer.flipX = true;  // Flip sprite for left direction
        }
    }

    void PlaceButton()
    {
        Instantiate(buttonPrefab, roundedPosition, Quaternion.identity);
    }

}
