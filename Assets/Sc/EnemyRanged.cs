using UnityEngine;

public class EnemyRanged : MonoBehaviour
{
    public Transform player;
    public GameObject projectilePrefab;
    public Transform firePoint;

    public float attackRange = 6f;
    public float attackCooldown = 1.5f;

    float lastAttackTime;

    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        // 👉 ถ้า player อยู่ในระยะ → ยิง
        if (distance <= attackRange)
        {
            if (Time.time >= lastAttackTime + attackCooldown)
            {
                Shoot();
                lastAttackTime = Time.time;
            }
        }
    }

void Shoot()
{
    GameObject bullet = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

    // 🎯 คำนวณทิศไปหา player “ตอนยิง”
    Vector2 dir = (player.position - firePoint.position).normalized;

    bullet.GetComponent<EnemyProjectile>()?.SetDirection(dir);
}


}