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
