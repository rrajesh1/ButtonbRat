using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject cheesePrefab; // Cheese prefab
    public LayerMask mazeLayer; // LayerMask for the maze
    public float cheeseSpawnInterval = 10f; // Time interval to spawn cheese

    public List<GameObject> fruitPrefabs; // List of fruit prefabs
    private List<Vector2> occupiedPositions = new List<Vector2>(); // List to track occupied positions

    // Constructor-like initialization method to set fruit prefabs
    public void Initialize(List<GameObject> fruitPrefabs)
    {
        this.fruitPrefabs = fruitPrefabs;

        // Start spawning cheese at regular intervals
        //StartCoroutine(SpawnCheeseAtIntervals());
    }

    public void Start()
    {
        
    }
    // Function to spawn a single fruit
    public void SpawnFruit()
    {
        Vector2 randomPosition = GetRandomPosition();

        // Check if position is valid (not occupied by fruit or maze)
        if (!IsPositionOccupied(randomPosition) && !IsPositionInMaze(randomPosition))
        {
            // Randomly select a fruit prefab from the list
            GameObject fruitPrefab = fruitPrefabs[Random.Range(0, fruitPrefabs.Count)];

            // Instantiate the fruit prefab at the given position
            GameObject newFruit = Instantiate(fruitPrefab, randomPosition, Quaternion.identity);

            // Add the position to the list of occupied positions
            occupiedPositions.Add(randomPosition);
        }
    }

    public void SpawnCheese()
    {
        Vector2 randomPosition = GetRandomPosition();

        while (IsPositionOccupied(randomPosition) || IsPositionInMaze(randomPosition))
        {
            randomPosition = GetRandomPosition();
        }
        // Instantiate the cheese prefab at the given position
        GameObject newCheese = Instantiate(cheesePrefab, randomPosition, Quaternion.identity);

        // Add the position to the list of occupied positions
        occupiedPositions.Add(randomPosition);

    }

    //IEnumerator SpawnCheeseAtIntervals()
    //{
    //    while (true)
    //    {
    //        yield return new WaitForSeconds(cheeseSpawnInterval);

    //        Vector2 randomPosition = GetRandomPosition();

    //        // Check if position is valid (not occupied by fruit or maze)
    //        if (!IsPositionOccupied(randomPosition) && !IsPositionInMaze(randomPosition))
    //        {
    //            SpawnCheese(randomPosition);
    //        }
    //    }
    //}

    Vector2 GetRandomPosition()
    {
        // Adjust the range of random values to match your game area
        float x = Random.Range(-10f, 10f);
        float y = Random.Range(-10f, 10f);
        return new Vector2(x, y);
    }

    bool IsPositionOccupied(Vector2 position)
    {
        // Check if the position is already occupied by another fruit or cheese
        // Check if position is valid (not occupied by fruit or maze)
        //Vector3 horizontalOffset = new Vector3(0, 0.1f, 0);
        //Vector3 verticalOffset = new Vector3(0.1f, 0, 0);

        //float distance = Vector3.Magnitude(2 * verticalOffset);
        //RaycastHit2D hit1 = Physics2D.Raycast(transform.position - verticalOffset, new Vector2(0, 1), 1f, mazeLayer);
        //RaycastHit2D hit2 = Physics2D.Raycast(transform.position - horizontalOffset, new Vector2(1, 0), 1f, mazeLayer);
        //return (hit1.collider != null || hit2.collider != null || occupiedPositions.Contains(position));
        return occupiedPositions.Contains(position);
    }

    bool IsPositionInMaze(Vector2 position)
    {
        // Check if there's a maze object at this position using a raycast
        return Physics2D.OverlapCircle(position, 0.1f, mazeLayer);
    }

    void SpawnCheese(Vector2 position)
    {
        // Instantiate the cheese prefab at the given position
        GameObject newCheese = Instantiate(cheesePrefab, position, Quaternion.identity);

        // Add the position to the list of occupied positions
        occupiedPositions.Add(position);
    }
}

// using UnityEngine;

// public class FoodSpawner : MonoBehaviour
// {
//     // Start is called once before the first execution of Update after the MonoBehaviour is created
//     public Sprites[] sprites;

//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }

//     public void spawnNewFruit() {
//         // check if something is in the random location then spawn 
//         Vector3 horizontalOffset = new Vector3(0, 0.1f, 0);
//         Vector3 verticalOffset = new Vector3(0.1f, 0, 0);

//         float distance = Vector3.Magnitude(2 * verticalOffset);
//         RaycastHit2D hit1 = Physics2D.Raycast(transform.position - verticalOffset, new Vector2(0, 1), 1f, mask);
//         RaycastHit2D hit2 = Physics2D.Raycast(transform.position - horizontalOffset, new Vector2(1, 0), 1f, mask);
//         if (hit1.collider == null && hit2.collider == null)
//         {
//             //Instantiate(bomb, transform.position, Quaternion.identity);
//         }
//     }
// }
