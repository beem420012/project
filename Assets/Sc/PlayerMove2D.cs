using UnityEngine;

public class PlayerMove2D : MonoBehaviour
{
    public float speed = 6f;
    public float jumpForce = 7f;

    public int maxJump = 2;
    public float jumpCooldown = 0.3f;

    private int jumpCount;
    private float lastJumpTime;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);

        if (Input.GetKeyDown(KeyCode.W) &&
            jumpCount < maxJump &&
            Time.time > lastJumpTime + jumpCooldown)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            jumpCount++;
            lastJumpTime = Time.time;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        jumpCount = 0;
    }
}