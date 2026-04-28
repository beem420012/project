using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public int damage = 20;

    public LayerMask enemyLayer;

    public float attackCooldown = 0.5f;
    private float lastAttackTime;

    // 👉 เก็บทิศล่าสุด
    private float lastDir = 1f;

    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");

        // 👉 ถ้ามีการกดเดิน → อัปเดตทิศ
        if (move != 0)
        {
            lastDir = move;
            transform.localScale = new Vector3(move, 1, 1);
        }

        // 👉 กดตี
        if (Input.GetMouseButtonDown(0) && Time.time >= lastAttackTime + attackCooldown)
        {
            // 🔄 ใช้ทิศล่าสุด แม้ไม่ได้กดตอนตี
            transform.localScale = new Vector3(lastDir, 1, 1);

            Attack();
            lastAttackTime = Time.time;
        }
    }

    void Attack()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(
            attackPoint.position,
            attackRange,
            enemyLayer
        );

        float direction = lastDir;

        foreach (Collider2D enemy in hits)
        {
            enemy.GetComponentInParent<Enemy>()?.TakeDamage(damage, direction);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}