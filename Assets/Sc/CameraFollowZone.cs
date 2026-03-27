using UnityEngine;
public class CameraFollowWithObjectBounds : MonoBehaviour
{
    public Transform player;

    public Collider2D leftBound;
    public Collider2D rightBound;

    public float smoothTime = 0.2f;
    private float velocityX = 0f;

    void LateUpdate()
    {
        float halfWidth = Camera.main.orthographicSize * Screen.width / Screen.height;

        float minX = leftBound.bounds.max.x + halfWidth;
        float maxX = rightBound.bounds.min.x - halfWidth;

        float targetX = player.position.x;

        targetX = Mathf.Clamp(targetX, minX, maxX);

        float smoothX = Mathf.SmoothDamp(
            transform.position.x,
            targetX,
            ref velocityX,
            smoothTime
        );

        transform.position = new Vector3(
            smoothX,
            transform.position.y,
            transform.position.z
        );
    }

    // 🔥 ต้องมีอันนี้
    public void SetBounds(Collider2D left, Collider2D right)
    {
        leftBound = left;
        rightBound = right;
    }

    public void SnapToX(float targetX)
    {
        velocityX = 0f;

        transform.position = new Vector3(
            targetX,
            transform.position.y,
            transform.position.z
        );
    }
}