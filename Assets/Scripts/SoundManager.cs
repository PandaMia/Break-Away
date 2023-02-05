using UnityEngine;

public class SoundManager : MonoBehaviour
{
    
    public AudioClip[] sound;
    public AudioSource source;

    public void Click()
    {
        source.clip = sound[0];
        source.volume = 0.25f;
        source.Play();
    }

    public void Hit()
    {
        source.clip = sound[1];
        source.volume = 0.35f;
        source.Play();
    }

    public void GetItem()
    {
        source.clip = sound[2];
        source.volume = 0.3f;
        source.Play();
    }

    public void Fall()
    {
        source.clip = sound[3];
        source.volume = 0.7f;
        source.Play();
    }
}
