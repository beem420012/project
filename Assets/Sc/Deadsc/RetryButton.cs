using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    public void OnRetry()
    {
        Time.timeScale = 1f; // กันกรณีเกมหยุด
        SceneManager.LoadScene("main"); // 👈 เปลี่ยนเป็นชื่อ Scene เกมคุณ
    }
}