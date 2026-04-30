using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed = 10f;
    private Vector2 direction;

    public void SetDirection(Vector2 dir)
    {
        direction = dir;

        // 🔥 หมุนให้ลูกไฟหันไปตามทิศ
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

// 👇 เพิ่ม offset
transform.rotation = Quaternion.Euler(0, 0, angle + 180f);
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }
}