using UnityEngine;

public class FloatingItem : MonoBehaviour
{
    public float floatHeight = 0.5f;   // สูงแค่ไหน
    public float floatSpeed = 2f;      // เร็วแค่ไหน

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float newY = startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }
}