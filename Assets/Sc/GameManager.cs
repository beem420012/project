using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<GameObject> enemiesInRoom = new List<GameObject>();

    void Awake()
    {
        instance = this;
        Debug.Log("<color=cyan>GameManager: ระบบพร้อมทำงาน!</color>");
    }

    public void RegisterEnemy(GameObject enemy)
    {
        if (!enemiesInRoom.Contains(enemy))
        {
            enemiesInRoom.Add(enemy);
            // แสดงชื่อมอนสเตอร์ที่ถูกนับ และจำนวนรวมปัจจุบัน
            Debug.Log($"<color=yellow>คลังข้อมูล:</color> เพิ่ม {enemy.name} เข้าในระบบ (รวมในห้องนี้: {enemiesInRoom.Count} ตัว)");
        }
    }

    public void EnemyDefeated(GameObject enemy)
    {
        if (enemiesInRoom.Contains(enemy))
        {
            enemiesInRoom.Remove(enemy);
            Debug.Log($"<color=red>รายงานการกำจัด:</color> {enemy.name} ตายแล้ว! (เหลือมอนสเตอร์อีก: {enemiesInRoom.Count} ตัว)");

            if (enemiesInRoom.Count <= 0)
            {
                EndGame();
            }
        }
    }
void EndGame()
{
    Debug.Log("<color=green><b>MISSION COMPLETE:</b> กำจัดมอนสเตอร์หมดห้องแล้ว! จบเกม!</color>");
    
    Invoke(nameof(LoadWin), 2f); // หน่วง 2 วิ
}

void LoadWin()
{
    SceneManager.LoadScene("win");
}
}