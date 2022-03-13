using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public void PlayCoinSound(AudioSource source)
    {   
        source.PlayOneShot(source.clip, source.volume);
    }

    public void PlayCubeExplode(AudioSource source)
    {
        if(source.isPlaying) return;
        
        source.pitch = Random.Range(0.9f,1.1f);
        source.PlayOneShot(source.clip, source.volume);
    }

    public void PlayStackSound(AudioSource source)
    {
        source.pitch = Random.Range(1f,1.7f);
        source.PlayOneShot(source.clip, source.volume);
    }
}
