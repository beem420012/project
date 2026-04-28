using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    public PlayerHealth player;
    public Image healthBar;

    void Update()
    {
        float percent = (float)player.currentHP / player.maxHP;
        healthBar.fillAmount = percent;
    }
}