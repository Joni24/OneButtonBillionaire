using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip music;
    public List<AudioClip> happySFX;
    public List<AudioClip> madSFX;

    public AudioSource _audioSource;

    public void PlayMusic()
    {
        _audioSource.clip = music;
        _audioSource.Play();
    }

    public void PlayHappySound()
    {
        var radom = Random.Range(0, happySFX.Count);
        _audioSource.PlayOneShot(happySFX.ElementAt(radom));
    }

    public void PlayMadSound()
    {
        var radom = Random.Range(0, madSFX.Count);
        _audioSource.PlayOneShot(madSFX.ElementAt(radom));
    }
}