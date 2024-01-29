using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    
    public Sound[] musicSounds, SfxSounds;
    public AudioSource musicSource, SfxSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        
        
            PlayMusic("MenuMusic");
    }
    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);
        if (s == null)
        {
            Debug.Log("Sound not Found");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
        
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(SfxSounds, x => x.name == name);
        if (s == null)
        {
            Debug.Log("Sound not Found");
        }
        else
        {
            SfxSource.PlayOneShot(s.clip);
        }
    }
}