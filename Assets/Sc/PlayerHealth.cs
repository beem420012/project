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

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip hurt;   // เสียงโดนตี
    public AudioClip death;  // เสียงตาย (ถ้ามี)

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

        // 🔊 เล่นเสียงโดนตี
        if (audioSource && hurt)
        {
            audioSource.pitch = Random.Range(0.95f, 1.05f);
            audioSource.PlayOneShot(hurt);
        }

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

    public void Heal(int amount)
    {
        currentHP += amount;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);

        Debug.Log("<color=green>Player ได้รับการรักษา!</color> HP ปัจจุบัน: " + currentHP);
    }

    void Die()
    {
        Debug.Log("Player ตาย");

        // 🔊 เสียงตาย (ถ้ามี)
        if (audioSource && death)
        {
            audioSource.PlayOneShot(death);
        }

        gameObject.SetActive(false);

        // โหลดฉากตาย
        SceneManager.LoadScene("Dead");
    }
}