using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip music;
    public List<AudioClip> happySFX;
    public List<AudioClip> madSFX;
    public AudioClip shortMorse;
    public AudioClip longMorse;

    public AudioSource _musicAudioSource;
    public AudioSource _sfxAudioSource;

    public void PlayMusic()
    {
        _musicAudioSource.clip = music;
        _musicAudioSource.Play();
    }

    public void PlayHappySound()
    {
        var random = Random.Range(0, happySFX.Count);
        _sfxAudioSource.PlayOneShot(happySFX.ElementAt(random));
    }

    public void PlayMadSound()
    {
        var random = Random.Range(0, madSFX.Count);
        _sfxAudioSource.PlayOneShot(madSFX.ElementAt(random));
    }

    public void PlayMorseSound(bool isShort)
    {
        _sfxAudioSource.PlayOneShot(isShort ? shortMorse : longMorse);
    }
}