using UnityEngine;

public class PlayerKeyDoor : MonoBehaviour
{
    public bool hasKey = false;
    public Transform spawnPoint;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Key"))
        {
            hasKey = true;
            Destroy(other.gameObject);
        }

        if(other.CompareTag("Door") && hasKey)
        {
            transform.position = spawnPoint.position;
        }

        if(other.CompareTag("Spike"))
        {
            transform.position = spawnPoint.position;
        }
    }
}