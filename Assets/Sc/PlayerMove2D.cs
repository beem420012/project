using UnityEngine;

public class PlayerMove2D : MonoBehaviour
{
    public float speed = 6f;
    public float jumpForce = 7f;
    public float characterScale = 0.5f;

    public int maxJump = 2;
    private int jumpCount = 0;

    public float jumpCooldown = 0.3f; // 👈 delay หลังใช้ครบ 2 ที
    private float lastJumpTime;

    private Rigidbody2D rb;
    public KnightControl anim;

    private bool isAttacking = false;
    private bool isJumping = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal");

        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);

        // flip
        if (move > 0)
            transform.localScale = new Vector3(characterScale, characterScale, 1);
        else if (move < 0)
            transform.localScale = new Vector3(-characterScale, characterScale, 1);

        // 🔥 jump (2 ครั้งติด + มี delay หลังจากนั้น)
        if (Input.GetKeyDown(KeyCode.W) &&
            jumpCount < maxJump &&
            Time.time > lastJumpTime + jumpCooldown)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

            jumpCount++;
            lastJumpTime = Time.time;

            anim.jump();
            isJumping = true;
        }

        // 🔥 attack
        if (Input.GetMouseButtonDown(0) && !isAttacking)
        {
            isAttacking = true;
            anim.attack_1();
            Invoke(nameof(ResetAttack), 0.5f);
        }

        // ❗ กัน animation ทับ
        if (isAttacking) return;

        if (!isJumping)
        {
            if (Mathf.Abs(move) > 0.1f)
                anim.walking();
            else
                anim.idle();
        }
    }

    void ResetAttack()
    {
        isAttacking = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // แตะพื้น = reset jump
        jumpCount = 0;
        isJumping = false;
    }
}