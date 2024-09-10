using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : MonoBehaviour
{
    // Rat's walking speed
    public float speed = 5;  

    // Sprites for different walking directions
    public Sprite spriteUp;
    public Sprite spriteLeft;
    //public List<GameObject> fruitPrefabs; // List of fruit prefabs
    public FoodSpawner foodSpawner;

    Rigidbody2D myrb2d;  
    SpriteRenderer spriteRenderer;  

    // Start is called before the first frame update
    void Start()
    {
        myrb2d = GetComponent<Rigidbody2D>();  
        spriteRenderer = GetComponent<SpriteRenderer>(); 
        foodSpawner.GetComponent<FoodSpawner>();


         // Ensure the foodSpawner is set and spawn the first fruit
        // if (foodSpawner != null)
        // {
        //     foodSpawner.SpawnFruit();
        // }
        // else
        // {
        //     Debug.LogError("FoodSpawner reference not set on the Rat!");
        // }
        
        foodSpawner.SpawnCheese();
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

        
    }

    void UpdateRatSprite(Vector2 movement)
    {
        // Moving up
        if (movement.y > 0)  
        {
            spriteRenderer.sprite = spriteUp;
            spriteRenderer.flipX = false;
            spriteRenderer.flipY = false;
        }

        // Moving down
        else if (movement.y < 0) 
        {
            spriteRenderer.sprite = spriteUp;
            spriteRenderer.flipX = false;
            spriteRenderer.flipY = true;
        }

        // Moving right
        else if (movement.x > 0)  
        {
            spriteRenderer.sprite = spriteLeft;
            spriteRenderer.flipX = true;
        }

        // Moving left
        else if (movement.x < 0)  
        {
            spriteRenderer.sprite = spriteLeft;
            spriteRenderer.flipX = false;  // Flip sprite for left direction
        }
    }

    void PlaceButton()
    {
        //Instantiate(buttonPrefab, roundedPosition, Quaternion.identity);
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Fruit")){
            Destroy(collision.gameObject);
        }

        else if(collision.gameObject.CompareTag("Cheese")){
            foodSpawner.SpawnCheese();
            Destroy(collision.gameObject);
        }
    }

}
