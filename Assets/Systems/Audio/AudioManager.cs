using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;



    private AudioSource[] musics;
    private AudioSource[] SFXs;
    private AudioSource[] playerSFXs;
    private AudioSource[] ambiences;

    private AudioSource mainMusic;




    private bool isSteping = false;


    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void Start()
    {
        musics = transform.Find("Musics").GetComponentsInChildren<AudioSource>();
        SFXs = transform.Find("SFXs").GetComponentsInChildren<AudioSource>();
        playerSFXs = transform.Find("PlayerSFXs").GetComponentsInChildren<AudioSource>();
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
        SetAudioPitch(SFXs, pitch);
        SetAudioPitch(playerSFXs, pitch);
        SetAudioPitch(ambiences, pitch);
    
    }

    private void SetAudioPitch(AudioSource[] audios, float pitch) 
    {

        foreach (AudioSource audio in audios)
        {

            audio.pitch = pitch;

        }

    }



    public void PlaySfx(AudioClip audio) 
    {
        RandomizePitchAndPlay(audio);
    }

    public void PlaySfx(SFXs sfx)
    {

        switch (sfx) 
        {
            case global::SFXs.SMASH_BUMP: RandomizePitchAndPlay(SFXs[0]); break;
            
            case global::SFXs.BOX_CRASH: RandomizePitchAndPlay(SFXs[1]); break;


            default:
                SFXs[0].Play();
                break;
        
        
        }

    }


    void RandomizePitchAndPlay( AudioSource sfx) 
    {
        float randomPitch = Random.Range(0.8f,1.2f);
        sfx.pitch = randomPitch;
        sfx.Play();
    }

    void RandomizePitchAndPlay(AudioClip sfx)
    {
        float randomPitch = Random.Range(0.8f, 1.2f);
        SFXs[0].pitch = randomPitch;
        SFXs[0].clip = sfx;
        SFXs[0].Play();
    }


    public void SetPlayerSteps(bool onOFF) 
    {

        if (onOFF && !isSteping) 
        {
            playerSFXs[0].Play();
            isSteping = true;
        }
    
        else if (!onOFF) 
        {
            playerSFXs[0].Stop();
            isSteping = false;
        }
    
    }

}
public enum SFXs 
{
    
    SMASH_BUMP,
    BOX_CRASH
}
