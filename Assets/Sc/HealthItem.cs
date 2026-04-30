using UnityEngine;

public class HealthItem : MonoBehaviour
{
    public int healAmount = 20; // ตั้งค่าได้ว่าจะให้เด้งกี่หน่วย

    private void OnTriggerEnter2D(Collider2D other)
    {
        // เช็คว่าคนที่มาชนมี Tag ว่า Player หรือไม่
        if (other.CompareTag("Player"))
        {
            // ดึงสคริปต์ PlayerHealth ออกมาจากตัวที่มาชน
            PlayerHealth player = other.GetComponent<PlayerHealth>();

            if (player != null)
            {
                // สั่งให้เลือดเด้ง
                player.Heal(healAmount);
                
                // เก็บเสร็จแล้วทำลายไอเทมทิ้ง
                Destroy(gameObject);
            }
        }
    }
}