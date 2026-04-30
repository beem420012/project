using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour
{
    public void menu()
    {
        Time.timeScale = 1f; // กันกรณีเกมหยุด
        SceneManager.LoadScene("menu"); // 👈 เปลี่ยนเป็นชื่อ Scene เกมคุณ
    }
}