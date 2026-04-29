using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public int damage = 20;

    public LayerMask enemyLayer;

    public float attackCooldown = 0.5f;
    private float lastAttackTime;

    private float lastDir = 1f;

    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");

        // 👉 แค่เก็บทิศ ไม่ต้องไปยุ่ง scale
        if (move != 0)
        {
            lastDir = move;
        }

        if (Input.GetMouseButtonDown(0) && Time.time >= lastAttackTime + attackCooldown)
        {
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

        foreach (Collider2D enemy in hits)
        {
            enemy.GetComponentInParent<Enemy>()?.TakeDamage(damage, lastDir);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}