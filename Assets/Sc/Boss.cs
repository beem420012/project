using UnityEngine;

public class Boss : MonoBehaviour
{
    public int hp = 200;
    public Rigidbody2D rb;

    public float knockbackForce = 5f;

    public void TakeDamage(int dmg, float direction)
    {
        hp -= dmg;

        // 💥 กระเด็น
        Vector2 force = new Vector2(direction * knockbackForce, 2f);
        rb.AddForce(force, ForceMode2D.Impulse);

        if (hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}