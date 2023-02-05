using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] sound;
    public AudioSource source;

    //void Start() 
    //{
    //    MenuMusic();
    //}

    public void UpdateVolume()
    {
        source.volume -= 0.1f * Time.deltaTime;
    }

    public void MenuMusic()
    {
        source.clip = sound[0];
        source.volume = 0.35f;
        source.Play();
    }

    public void GameMusic()
    {
        source.clip = sound[1];
        source.volume = 0.35f;
        source.Play();
    }

    public void GameOverMusic()
    {
        source.clip = sound[2];
        source.volume = 0.35f;
        source.Play();
    }

    public void VictoryMusic()
    {
        source.clip = sound[3];
        source.volume = 0.35f;
        source.Play();
    }

}
