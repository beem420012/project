using UnityEngine;

public class PlayerRespawnzone3 : MonoBehaviour
{
    public Transform spawnPoint; // จุดเกิด

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Spike2"))
        {
            transform.position = spawnPoint.position;
        }
    }
}