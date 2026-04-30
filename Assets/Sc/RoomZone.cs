using UnityEngine;

public class RoomZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log($"<color=white>RoomZone:</color> ตรวจพบ {other.name} เข้ามาในพื้นที่ห้อง");
            GameManager.instance.RegisterEnemy(other.gameObject);
        }
    }
}