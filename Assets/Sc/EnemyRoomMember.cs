using UnityEngine;

public class EnemyRoomMember : MonoBehaviour
{
    private void OnDestroy()
    {
        if (GameManager.instance != null)
        {
            Debug.Log($"<color=orange>EnemyRoomMember:</color> กำลังส่งสัญญาณการตายของ {gameObject.name}");
            GameManager.instance.EnemyDefeated(this.gameObject);
        }
    }
}