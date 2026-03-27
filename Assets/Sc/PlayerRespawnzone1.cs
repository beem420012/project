using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Transform spawnPoint; // จุดเกิด

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Spike1"))
        {
            transform.position = spawnPoint.position;
        }
    }
}