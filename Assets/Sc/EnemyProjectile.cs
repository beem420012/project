using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed = 8f;
    public int damage = 10;

    private Vector2 direction;

    // 🎯 รับทิศครั้งเดียวตอนยิง

    void Start()
{
    Destroy(gameObject, 3f); // 💨 หายหลัง 3 วินาที
}

    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
    }

    void Update()
    {
        // 👉 วิ่งตรงตลอด ไม่ตามแล้ว
        transform.position += (Vector3)(direction * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>()?.TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    
}