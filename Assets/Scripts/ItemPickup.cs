using UnityEngine;
using UnityEngine.SceneManagement; 

public class ItemPickup : MonoBehaviour
{
    public GameObject winPrefab;
    GameObject ButtonItem;

    public void OnTriggerEnter2D(Collider2D other)
    {
        GameObject pickupObject = other.gameObject;
        if (other.CompareTag("Button") && ButtonItem == null)
        {
            other.transform.SetParent(transform);
            //Destroy(other.GetComponent<Collider2D>());

            // Destroy(other);
            other.transform.localPosition = new Vector3(0.5f, 0, -1f);
            ButtonItem = other.gameObject;
        } 

    }
    
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Gate") && ButtonItem!= null){
            GameObject newButton = Instantiate(winPrefab, new Vector3(0,0,0), Quaternion.identity);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            
        }
    }
}





/**
GameObject pickedItem;

void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Carrot") && pickedItem == null){
			other.transform.SetParent(transform);
			other.transform.position = transform.position + Vector3.right * 0.5f;
			pickedItem = other.gameObject;
		}

		else if(other.CompareTag("Animal") && pickedItem != null){
			Animal animal = other.GetComponent<Animal>();
			if(animal != null){
				animal.Feed();
				Destroy(pickedItem);
			}
		}
	}
**/
