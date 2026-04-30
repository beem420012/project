using UnityEngine;

public class PlayerRespawnzone2 : MonoBehaviour
{
    public Transform spawnPoint2; // จุดเกิด

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Spike2"))
        {
            transform.position = spawnPoint2.position;
        }
    }
}