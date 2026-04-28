using UnityEngine;

public class BossAI : MonoBehaviour
{
    public Transform player;

    [Header("Attack Range")]
    public float meleeRange = 1.5f;
    public float shootRange = 6f;

    [Header("Damage")]
    public int meleeDamage = 20;

    [Header("Cooldown")]
    public float meleeCooldown = 1f;
    public float shootCooldown = 2f;

    float lastMeleeTime;
    float lastShootTime;

    [Header("Shoot")]
    public GameObject projectilePrefab;
    public Transform firePoint;

    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        // 🔄 หันหน้าหาผู้เล่น
        if (player.position.x > transform.position.x)
            transform.localScale = new Vector3(1,1,1);
        else
            transform.localScale = new Vector3(-1,1,1);

        // ⚔️ ตีใกล้
        if (distance <= meleeRange)
        {
            if (Time.time >= lastMeleeTime + meleeCooldown)
            {
                MeleeAttack();
                lastMeleeTime = Time.time;
            }
        }

        // 💥 ยิงไกล
        else if (distance <= shootRange)
        {
            if (Time.time >= lastShootTime + shootCooldown)
            {
                Shoot();
                lastShootTime = Time.time;
            }
        }
    }

    void MeleeAttack()
    {
        Debug.Log("Boss ฟัน!");

        player.GetComponent<PlayerHealth>()?.TakeDamage(meleeDamage);
    }

    void Shoot()
    {
        Debug.Log("Boss ยิง!");

        GameObject bullet = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

        // ยิงตรงไปหา player (ไม่โค้ง)
        Vector2 dir = (player.position - firePoint.position).normalized;
        bullet.GetComponent<EnemyProjectile>()?.SetDirection(dir);
    }
}