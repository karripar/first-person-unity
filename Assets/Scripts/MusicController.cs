using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioSource musicSource;

    void Start()
    {
        musicSource.Play();  // Start music
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }
}

