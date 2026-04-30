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
        Vector2 dir = (player.position - firePoint.position).normalized;

        GameObject bullet = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

        // 👇 ส่งทิศไปให้ลูกไฟ
        bullet.GetComponent<EnemyProjectile>()?.SetDirection(dir);
    }
}