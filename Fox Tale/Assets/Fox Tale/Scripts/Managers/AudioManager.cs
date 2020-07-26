using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource[] sfx;
    public AudioSource bgm, victoryMusic, bossMusic;

    private void Awake()
    {
        instance = this;    
    }

    public void playSFX(int sfxnumber)
    {
        sfx[sfxnumber].Stop();
        sfx[sfxnumber].pitch = Random.Range(.9f, 1.1f);
        sfx[sfxnumber].Play();
    }

    public void playVictory()
    {
        bgm.Stop();
        victoryMusic.Play();
    }

    public void playBossMusic()
    {
        bgm.Stop();
        bossMusic.Play();
    }

    public void stopBossMusic()
    {
        bossMusic.Stop();
        bgm.Play();
    }

}
