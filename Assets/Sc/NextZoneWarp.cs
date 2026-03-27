using UnityEngine;

public class NextZoneWarp : MonoBehaviour
{
    public Transform nextSpawnPoint;

    public Collider2D newLeftBound;
    public Collider2D newRightBound;

    public int targetZone = 2; // 👈 เพิ่มอันนี้

    private bool used = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (used) return;

        if (collision.CompareTag("Player"))
        {
            used = true;

            // 🔥 อัปเดต Zone ของ Player
            PlayerKeyDoor player = collision.GetComponent<PlayerKeyDoor>();
            if(player != null)
            {
                player.currentZone = targetZone;
            }

            // วาร์ป Player
            collision.transform.position = nextSpawnPoint.position;

            // 🎥 กล้อง
            CameraFollowWithObjectBounds cam = Camera.main.GetComponent<CameraFollowWithObjectBounds>();
            cam.SetBounds(newLeftBound, newRightBound);
            cam.SnapToX(nextSpawnPoint.position.x);

            gameObject.SetActive(false);
        }
    }
}