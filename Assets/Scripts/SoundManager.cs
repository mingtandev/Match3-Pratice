using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Sound[] sounds;
    public static float volumeSound = 1f;
    public static float volumeMusic = 1f;
    DataPlayer data;

    public static SoundManager instance;
    private void Awake()
    {
        data = SaveLoadManager.LoadData();
        if (instance == null)
        {
            instance = this;
        }
        else if(instance!=this)
        {
            Destroy(instance.gameObject);
            instance = this;

        }
        DontDestroyOnLoad(gameObject);
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            if(data==null) s.source.volume = s.volume;
            else if (data != null && s.name == "home")
                s.source.volume = data.volMusic;
            else if (data != null)
            {
                s.source.volume = data.volSound;
            }
            s.source.loop = s.loop;
            
        }

        

        
            Play("home");

    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound " + name + " not found ");
            return;
        }

        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
       

        if (s == null)
        {
            Debug.LogWarning("Sound " + name + " not found ");
            return;
        }

        s.source.Stop();
    }


    public void changeSound(float vol)
    {
        volumeSound = vol;
        foreach (Sound s in sounds)
        {
            if (s.name == "home")
                continue;
            s.source.volume = volumeSound;
        }

        
    }

    public void changeMusic(float vol)
    {
        volumeMusic = vol;
        Sound s = Array.Find(sounds, sound => sound.name == "home");
        s.source.volume = volumeMusic;
    }



}
