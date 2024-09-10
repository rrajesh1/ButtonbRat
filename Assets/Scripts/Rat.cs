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

    private int numCheeseEaten = 0;
    public int numCheeseToWin = 3;

    public GameObject ButtonItem;
    
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
        // InvokeRepeating("Shoes", 2f, 5f);
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

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Fruit")){
            Destroy(collision.gameObject);
        }

        else if(collision.gameObject.CompareTag("Cheese")){
            numCheeseEaten++;

            if (numCheeseEaten>= numCheeseToWin){
                foodSpawner.SpawnButton();
            }
            else {
                foodSpawner.SpawnCheese();
            }

            Destroy(collision.gameObject);
        }

    
    
    }



    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     GameObject pickupObject = other.gameObject;
    //     if (pickupObject.CompareTag("Button") && ButtonItem == null)
    //     {
    //         pickupObject.transform.SetParent(transform);
    //         Destroy(other.GetComponent<Collider2D>());

    //         // Destroy(other);
    //         pickupObject.transform.localPosition = new Vector3(0.5f, 0, 0);
    //         ButtonItem = pickupObject;
    //     } 

    // }


/*GameObject animal = other.gameObject;
        Cow cow = animal.GetComponent<Cow>();
        // checks if the object has the cow script on it and if it is holding the carrot
        if (cow != null && item != null)
        {
            cow.Feed();
            Destroy(item);
        }
        */
}