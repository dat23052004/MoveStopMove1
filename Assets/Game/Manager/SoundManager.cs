using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] AudioSource bgSource;
    [SerializeField] AudioSource efxSource;
    //[SerializeField] AudioSource deadSource;

    [SerializeField] AudioClip bgSound;

    [Header("[Sound]")]
    public Sound Sound;
    public bool checkSound = true;

    public void PlayBackground()
    {
        if (checkSound)
        {
            bgSource.clip = bgSound;
            bgSource.loop = true;
            bgSource.Play();
        }
        else
        {
            bgSource.Stop();
        }
    }

    public void PlaySound(AudioClip sound)
    {
        efxSource.PlayOneShot(sound);
    }

    public void PlaySoundAt(Vector3 position, AudioClip sound)
    {    
        AudioSource.PlayClipAtPoint(sound, position);
    } 
}

[System.Serializable]
public class Sound
{
    [SerializeField] AudioClip UIclip;
    [SerializeField] AudioClip gunClip;
    [SerializeField] AudioClip deadClip;
    [SerializeField] Transform pl;

    
    public void Play()
    {
        SoundManager.Ins.PlaySound(UIclip);
    }

    public void GunPlayAt()
    {
        SoundManager.Ins.PlaySoundAt(pl.position, gunClip);
    }

    public void DeadPlayAt()
    {
        SoundManager.Ins.PlaySoundAt(pl.position, deadClip);
    }

}

