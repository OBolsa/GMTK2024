using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;



    private AudioSource[] musics;
    private AudioSource[] sfxs;
    private AudioSource[] ambiences;

    private AudioSource mainMusic;
    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void Start()
    {
        musics = transform.Find("Musics").GetComponentsInChildren<AudioSource>();
        sfxs = transform.Find("SFXs").GetComponentsInChildren<AudioSource>();
        ambiences = transform.Find("Ambiences").GetComponentsInChildren<AudioSource>();
        mainMusic = musics[0];

    }


    public void StopMusic() 
    {
        mainMusic.Stop();
    }

    public void PlayMusic() 
    {
        mainMusic.Play();
    }

    public void SetAllAudioPitch(float pitch) 
    {

        SetAudioPitch(musics, pitch);
        SetAudioPitch(sfxs, pitch);
        SetAudioPitch(ambiences, pitch);
    
    }

    private void SetAudioPitch(AudioSource[] audios, float pitch) 
    {

        foreach (AudioSource audio in audios)
        {

            audio.pitch = pitch;

        }

    }


    public void PlaySfx(SFXs sfx)
    {

        switch (sfx) 
        {
            default: sfxs[0].Play();
                break;
        
        
        }

    }


}
public enum SFXs 
{
    


}
