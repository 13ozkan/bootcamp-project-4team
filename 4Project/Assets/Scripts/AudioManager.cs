using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    
    public Sound[] sounds;

    public static AudioManager instance;

    private bool hasPlayed = false;


    // Start is called before the first frame update
    private void Awake()

    {

        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;    

        }
    }


    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + "not found!");
            return;
        }
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;


        s.source.PlayOneShot(s.clip);
    }


    public void PlayLooped(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + "not found!");
            return;
        }
        s.source.volume = s.volume;
        s.source.pitch = s.pitch;
        s.source.loop = s.loop;


        s.source.Play();
    }



    public void PlayOnce(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + "not found!");
            return;
        }
        s.source.volume = s.volume;
        s.source.pitch = s.pitch;
        s.source.loop = s.loop;

        if (hasPlayed==false)
        {
            s.source.PlayOneShot(s.clip);
            hasPlayed = true;
        }

           

    }

    public void PitchIncrease(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

          
          s.pitch = s.pitch + 0.05f;
        
           

    }

    public void PitchNormalize(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        s.pitch = 1f;

    }
}
