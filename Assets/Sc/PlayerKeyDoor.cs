using UnityEngine;

public class PlayerKeyDoor : MonoBehaviour
{
    public bool hasKey = false;
    public int currentZone = 1;

    public Transform spawnPoint2;
    public Transform spawnPoint3;
    public Transform spawnPoint4; // 🆕

    public Collider2D zone2Left;
    public Collider2D zone2Right;

    public Collider2D zone3Left;
    public Collider2D zone3Right;

    public Collider2D zone4Left;  // 🆕
    public Collider2D zone4Right; // 🆕

    void OnTriggerEnter2D(Collider2D other)
    {
        // 🔑 เก็บกุญแจ (เฉพาะด่าน 2)
        if(other.CompareTag("Key") && currentZone == 2)
        {
            hasKey = true;
            Destroy(other.gameObject);
            Debug.Log("เก็บกุญแจแล้ว");
        }

        // 🚪 ประตู
        else if(other.CompareTag("Door"))
        {
            CameraFollowWithObjectBounds cam = Camera.main.GetComponent<CameraFollowWithObjectBounds>();

            // 🟢 ด่าน 1 → ไปด่าน 2
            if(currentZone == 1)
            {
                transform.position = spawnPoint2.position;
                currentZone = 2;

                cam.SetBounds(zone2Left, zone2Right);
                cam.SnapToX(spawnPoint2.position.x);
            }

            // 🟡 ด่าน 2 → ต้องมีกุญแจ
            else if(currentZone == 2)
            {
                if(!hasKey)
                {
                    Debug.Log("🚫 ยังไม่มีกุญแจ");
                    return;
                }

                transform.position = spawnPoint3.position;
                currentZone = 3;
                hasKey = false;

                cam.SetBounds(zone3Left, zone3Right);
                cam.SnapToX(spawnPoint3.position.x);
            }

            // 🔴 ด่าน 3 → ไปด่าน 4
            else if(currentZone == 3)
            {
                transform.position = spawnPoint4.position;
                currentZone = 4;

                cam.SetBounds(zone4Left, zone4Right);
                cam.SnapToX(spawnPoint4.position.x);
            }
        }
    }
}