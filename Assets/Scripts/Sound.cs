using UnityEngine.Audio;
using UnityEngine;


[System.Serializable]
public class Sound 
{
    public string name;
    public AudioClip clip;
    public float volume;
    public bool loop = false;


    public AudioSource source; //Management that audioclip when i hit play

}
