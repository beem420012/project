using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void start()
    {
        Time.timeScale = 1f; // กันกรณีเกมหยุด
        SceneManager.LoadScene("main"); // 👈 เปลี่ยนเป็นชื่อ Scene เกมคุณ
    }
}