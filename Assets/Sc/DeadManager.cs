using UnityEngine;

public class DeadManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip loseSound;

    void Start()
    {
        if (audioSource && loseSound)
        {
            audioSource.PlayOneShot(loseSound);
        }
    }
}