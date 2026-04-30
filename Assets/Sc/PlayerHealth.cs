using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHP = 100;
    public int currentHP;

    [Header("i-frame (กันโดนซ้ำรัว)")]
    public float invincibleTime = 0.3f;
    private bool isInvincible = false;

    void Start()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int dmg)
    {
        if (isInvincible) return;

        currentHP -= dmg;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);

        Debug.Log("Player HP: " + currentHP);

        if (currentHP <= 0)
        {
            Die();
            return;
        }

        StartCoroutine(IFrame());
    }

    IEnumerator IFrame()
    {
        isInvincible = true;
        yield return new WaitForSeconds(invincibleTime);
        isInvincible = false;
    }

// --- ส่วนที่เพิ่มใหม่ ---
    public void Heal(int amount)
    {
        currentHP += amount;
        
        // ใช้ Mathf.Clamp เพื่อไม่ให้เลือดเกิน maxHP
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);

        Debug.Log("<color=green>Player ได้รับการรักษา!</color> HP ปัจจุบัน: " + currentHP);
    }
    
    void Die()
    {
        Debug.Log("Player ตาย");
        // ตัวอย่างง่าย: ปิดตัวละคร
        gameObject.SetActive(false);
        // หรือจะรีสตาร์ทด่านก็ได้
        SceneManager.LoadScene("Dead"); // ชื่อ Scene ต้องตรง
    }
}