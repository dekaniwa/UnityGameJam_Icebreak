using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip bgm;

    void Start()
    {
        audioSource.clip = bgm;
        audioSource.loop = true;
        audioSource.Play();
    }
}