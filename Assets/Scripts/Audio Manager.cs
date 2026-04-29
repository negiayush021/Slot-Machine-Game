using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    private void Awake()
    {
        instance = this;
    }


    public AudioClip[] clip;
    public AudioSource audioSource;
    public void PlayClip(int index )
    {
        if (index >= 0 && index < clip.Length)
        {
            audioSource.PlayOneShot(clip[index]);
            
        }
    }
}
