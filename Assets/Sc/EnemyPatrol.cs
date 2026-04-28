using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed = 2f;

    public Transform pointA;
    public Transform pointB;

    private bool movingRight = true;

    public Rigidbody2D rb;

    void Update()
    {
        if (movingRight)
        {
            rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);

            if (transform.position.x >= pointB.position.x)
            {
                movingRight = false;
                Flip();
            }
        }
        else
        {
            rb.linearVelocity = new Vector2(-speed, rb.linearVelocity.y);

            if (transform.position.x <= pointA.position.x)
            {
                movingRight = true;
                Flip();
            }
        }
    }

    void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, 1, 1);
    }
}