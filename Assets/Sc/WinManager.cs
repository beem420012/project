using UnityEngine;

public class WinManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip winSound;

    void Start()
    {
        if (audioSource && winSound)
        {
            audioSource.PlayOneShot(winSound);
        }
    }
}