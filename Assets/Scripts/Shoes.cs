using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Shoes : MonoBehaviour
{
    public List<GameObject> shoePrefabs; // List of shoe prefabs
    public GameObject rat; // Reference to the rat object

    private GameObject spawnedShoe; // To keep track of the currently spawned shoe
    private float shoeLifetime = 3f; // Time in seconds before the shoe disappears
    private float spawnTime; // To track when the shoe was spawned
    private bool shoeSpawned = false; // To track if a shoe has been spawned

    public GameObject endPrefab;
    
    public void Start(){
        InvokeRepeating("SpawnShoe", 2f, 5f);
    }
    
    public void Update()
    {
        if (shoeSpawned)
        {
            // Check if the shoe collides with the rat
            if (IsCollidingWithRat(spawnedShoe))
            {
                EndGame();
            }
            else
            {
                // Destroy the shoe after 3 seconds if it hasn't collided with the rat
                if (Time.time - spawnTime >= shoeLifetime)
                {
                    Destroy(spawnedShoe);
                    shoeSpawned = false;
                }
            }
        }
    }

    public void SpawnShoe()
    {
        // Randomly select a shoe prefab from the list
        GameObject shoePrefab = shoePrefabs[Random.Range(0, shoePrefabs.Count)];

        Vector2 randomPosition = GetRandomPosition();

        // Ensure the position is valid
        while (IsPositionOccupied(randomPosition) || IsPositionInMaze(randomPosition))
        {
            randomPosition = GetRandomPosition();
        }

        // Instantiate the shoe prefab at the random position
        spawnedShoe = Instantiate(shoePrefab, randomPosition, Quaternion.identity);

        //new code 
        Rigidbody2D rb = spawnedShoe.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = spawnedShoe.AddComponent<Rigidbody2D>();
        }
        rb.bodyType = RigidbodyType2D.Dynamic; // Set the shoe to dynamic

        // Add a Collider2D if not already present
        Collider2D collider = spawnedShoe.GetComponent<Collider2D>();
        if (collider == null)
        {
            collider = spawnedShoe.AddComponent<BoxCollider2D>(); // Add a BoxCollider2D
        }
        collider.isTrigger = false; // Make sure it's not set as a trigger



        // Set the spawn time and mark that the shoe has been spawned
        spawnTime = Time.time;
        shoeSpawned = true;
    }

    // Function to check if the shoe has collided with the rat
    private bool IsCollidingWithRat(GameObject shoe)
    {
        // Simple distance-based check to see if the shoe and rat are close enough
        float distance = Vector2.Distance(shoe.transform.position, rat.transform.position);

        // Assuming a reasonable collision distance (adjust as needed)
        return distance < 0.5f;
    }

    // End game logic when shoe hits the rat
    private void EndGame()
    {
        GameObject endPrefab = Instantiate(endPrefab, new Vector3(0,0,0), Quaternion.identity);
    }

    // Example utility methods you likely have already:
    private Vector2 GetRandomPosition()
    {
        // Your logic to get a random position on the map
        return new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f));
    }

    private bool IsPositionOccupied(Vector2 position)
    {
        // Your logic to check if the position is occupied
        return false;
    }

    private bool IsPositionInMaze(Vector2 position)
    {
        // Your logic to check if the position is inside the maze
        return false;
    }
}


// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// public class Shoes : MonoBehaviour
// {
//     public List<GameObject> shoePrefabs; // List of shoe prefabs
//     public GameObject rat; // Reference to the rat object

//     public GameObject endPrefab;

//     public void Start(){
//         InvokeRepeating("SpawnShoe", 2f, 5f);
//     }
//     public void SpawnShoe()
//     {
//         // Randomly select a shoe prefab from the list
//         GameObject shoePrefab = shoePrefabs[Random.Range(0, shoePrefabs.Count)];

//         Vector2 randomPosition = GetRandomPosition();

//         // Ensure the position is valid
//         while (IsPositionOccupied(randomPosition) || IsPositionInMaze(randomPosition))
//         {
//             randomPosition = GetRandomPosition();
//         }

//         // Instantiate the shoe prefab at the random position
//         GameObject newShoe = Instantiate(shoePrefab, randomPosition, Quaternion.identity);
        
//         // Check for collision with the rat
//         StartCoroutine(CheckCollisionOrDestroy(newShoe));
//     }

//     // Coroutine to check collision and destroy the shoe if it doesn't hit the rat
//     private IEnumerator CheckCollisionOrDestroy(GameObject shoe)
//     {
//         bool hasHitRat = false;

//         // This assumes the shoe has a Collider2D and Rigidbody2D (set to trigger)
//         shoe.GetComponent<Collider2D>().isTrigger = true;

//         float elapsedTime = 0f;

//         while (elapsedTime < 3f)
//         {
//             // Check for collision
//             if (IsCollidingWithRat(shoe))
//             {
//                 hasHitRat = true;
//                 EndGame();
//                 break;
//             }

//             // Wait a frame and increment the elapsed time
//             yield return null;
//             elapsedTime += Time.deltaTime;
//         }

//         if (!hasHitRat)
//         {
//             // If the shoe did not hit the rat, destroy it after 3 seconds
//             Destroy(shoe);
//         }
//     }

//     // Function to check if the shoe has collided with the rat
//     private bool IsCollidingWithRat(GameObject shoe)
//     {
//         // Simple distance-based check to see if the shoe and rat are close enough
//         float distance = Vector2.Distance(shoe.transform.position, rat.transform.position);

//         // Assuming a reasonable collision distance (adjust as needed)
//         return distance < 0.5f;
//     }

//     // End game logic when shoe hits the rat
//     private void EndGame()
//     {
//         Debug.Log("Game Over! Shoe hit the rat.");
//         GameObject endButton = Instantiate(endPrefab, new Vector3(0,0,0), Quaternion.identity);
//     }

//     // Example utility methods you likely have already:
//     private Vector2 GetRandomPosition()
//     {
//         // Your logic to get a random position on the map
//         return new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f));
//     }

//     private bool IsPositionOccupied(Vector2 position)
//     {
//         // Your logic to check if the position is occupied
//         return false;
//     }

//     private bool IsPositionInMaze(Vector2 position)
//     {
//         // Your logic to check if the position is inside the maze
//         return false;
//     }
// }
