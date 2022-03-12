using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;
    
    // Start is called before the first frame update
    public void Awake ()
    {
        foreach (var sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            var source = sound.source;
            source.clip = sound.clip;
            source.volume = sound.volume;
            source.pitch = sound.pitch;
            source.loop = sound.loop;
        }
    }

    private void Start()
    {
        Play("Theme");
    }

    public void Play(string soundName)
    {
        var sound = Array.Find(sounds, sound => sound.name == soundName);
        sound?.source.Play();
    }
}
