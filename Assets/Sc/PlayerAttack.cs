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

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip whoosh;
    public AudioClip hit;

    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");

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
        // 🗡️ 1. เล่นเสียงฟันอากาศ (ทุกครั้ง)
        if (audioSource && whoosh)
        {
            audioSource.pitch = Random.Range(0.95f, 1.05f);
            audioSource.PlayOneShot(whoosh);
        }

        // 🔍 2. ตรวจโดนศัตรู
        Collider2D[] hits = Physics2D.OverlapCircleAll(
            attackPoint.position,
            attackRange,
            enemyLayer
        );

        bool hasHit = false;

        foreach (Collider2D enemy in hits)
        {
            Enemy e = enemy.GetComponentInParent<Enemy>();
            if (e != null)
            {
                e.TakeDamage(damage, lastDir);
                hasHit = true;
            }
        }

        // 💥 3. เล่นเสียงโดน (ถ้ามีโดนจริง)
        if (hasHit && audioSource && hit)
        {
            // หน่วงนิดนึงให้รู้สึก “ฟันก่อน แล้วค่อยโดน”
            Invoke(nameof(PlayHitSound), 0.03f);
        }
    }

    void PlayHitSound()
    {
        audioSource.PlayOneShot(hit);
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}