using UnityEngine;
using System.Collections;

public class BossAI : MonoBehaviour
{
    public Transform player;

    [Header("Shoot Range")]
    public float shootRange = 8f;

    [Header("Cooldown")]
    public float shootCooldown = 2f;
    float lastShootTime;

    [Header("Shoot")]
    public GameObject projectilePrefab;
    public Transform firePoint;

    [Header("Random Shoot")]
    public int minBullets = 1;
    public int maxBullets = 3;
    public float spreadAngle = 25f;

    [Header("Warning")]
    public GameObject warningCirclePrefab;
    public float telegraphTime = 0.6f;

    private bool isAttacking = false;

    // 🔥 เก็บ scale เดิม
    private Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;
    }

    void Update()
    {
        if (player == null || isAttacking) return;

        float distance = Vector2.Distance(transform.position, player.position);

        // 🔥 flip แบบไม่ทำให้ขนาดเพี้ยน
        if (player.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(
                Mathf.Abs(originalScale.x),
                originalScale.y,
                originalScale.z
            );
        }
        else
        {
            transform.localScale = new Vector3(
                -Mathf.Abs(originalScale.x),
                originalScale.y,
                originalScale.z
            );
        }

        // 🎯 ยิงอย่างเดียว
        if (distance <= shootRange)
        {
            if (Time.time >= lastShootTime + shootCooldown)
            {
                StartCoroutine(ShootTelegraph());
                lastShootTime = Time.time;
            }
        }
    }

    IEnumerator ShootTelegraph()
    {
        isAttacking = true;

        // 🔴 วงเตือนใต้ player
        Vector3 pos = player.position;
        pos.z = 0;

        GameObject warning = Instantiate(warningCirclePrefab, pos, Quaternion.identity);

        yield return new WaitForSeconds(telegraphTime);

        Destroy(warning);

        ShootRandom();

        isAttacking = false;
    }

    void ShootRandom()
    {
        int bulletCount = Random.Range(minBullets, maxBullets + 1);

        for (int i = 0; i < bulletCount; i++)
        {
            GameObject bullet = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

            Vector2 baseDir = (player.position - firePoint.position).normalized;

            float angle = Random.Range(-spreadAngle, spreadAngle);
            Vector2 finalDir = Quaternion.Euler(0, 0, angle) * baseDir;

            bullet.GetComponent<EnemyProjectile>()?.SetDirection(finalDir);
        }
    }
}