using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour
{
    public int maxHP = 200;
    private int currentHP;

    private Rigidbody2D rb;

    public float knockbackForce = 5f;

    private SpriteRenderer sr;

    void Start()
    {
        currentHP = maxHP;

        // ✅ กันลืมลาก rb
        rb = GetComponent<Rigidbody2D>();

        // ✅ เอาไว้ทำ effect กระพริบ
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    public void TakeDamage(int dmg, float direction)
    {
        currentHP -= dmg;

        Debug.Log("Boss HP: " + currentHP);

        // 💥 กระเด็น (กัน rb เป็น null)
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            Vector2 force = new Vector2(direction * knockbackForce, 2f);
            rb.AddForce(force, ForceMode2D.Impulse);
        }

        // ✨ เอฟเฟกต์โดนตี
        StartCoroutine(HitFlash());

        if (currentHP <= 0)
        {
            Die();
        }
    }

    IEnumerator HitFlash()
    {
        if (sr != null)
        {
            sr.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            sr.color = Color.white;
        }
    }

    void Die()
    {
        Debug.Log("Boss ตาย!");
        Destroy(gameObject);
    }
}