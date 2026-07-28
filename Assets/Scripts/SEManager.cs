using UnityEngine;

public class SEManager : MonoBehaviour
{
    public static SEManager Instance;

    public AudioSource audioSource;

    public AudioClip getSE;
    public AudioClip deliverySE;

    private void Awake()
    {
        Instance = this;
    }

    public void PlayGet()
    {
        audioSource.PlayOneShot(getSE);
    }

    public void PlayDelivery()
    {
        audioSource.PlayOneShot(deliverySE);
    }
}