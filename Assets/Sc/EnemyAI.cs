using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public Rigidbody2D rb;

    [Header("Movement")]
    public float speed = 2f;

    [Header("Patrol")]
    public Transform pointA;
    public Transform pointB;
    private bool movingRight = true;

    [Header("Detect")]
    public float detectRange = 5f;
    public float stopDistance = 1.2f;

    [Header("Attack")]
    public int damage = 10;
    public float attackCooldown = 1f;
    float lastAttackTime;

    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        // 👀 เห็น player → ไล่
        if (distance <= detectRange)
        {
            Chase(distance);
        }
        else
        {
            Patrol();
        }

        Flip();
    }

    // 🟢 Patrol เดินไปมา
    void Patrol()
    {
        if (movingRight)
        {
            rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);

            if (transform.position.x >= pointB.position.x)
                movingRight = false;
        }
        else
        {
            rb.linearVelocity = new Vector2(-speed, rb.linearVelocity.y);

            if (transform.position.x <= pointA.position.x)
                movingRight = true;
        }
    }

    // 🔴 ไล่ player
    void Chase(float distance)
    {
        if (distance > stopDistance)
        {
            Vector2 dir = (player.position - transform.position).normalized;
            rb.linearVelocity = new Vector2(dir.x * speed, rb.linearVelocity.y);
        }
        else
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
            TryAttack();
        }
    }

    // ⚔️ ตี player
    void TryAttack()
    {
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            lastAttackTime = Time.time;

            player.GetComponent<PlayerHealth>()?.TakeDamage(damage);
            Debug.Log("Enemy Attack!");
        }
    }

    // 🔄 หันหน้า
    void Flip()
    {
        if (rb.linearVelocity.x > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (rb.linearVelocity.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }
}