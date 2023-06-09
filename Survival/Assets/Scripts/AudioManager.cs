using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager Instance;

    public AudioSource bgm;

    public AudioSource victory;

    public AudioSource[] soundEffects;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StopBGM()
    {
        bgm.Stop();
    }

    public void PlayLevelVictory()
    {
        StopBGM();
        victory.Play();
    }

    public void PlaySFX(int sfxNumber)
    {
        soundEffects[sfxNumber].Stop();
        soundEffects[sfxNumber].Play();
    }

    public void StopSFX(int sfxNumber)
    {
        soundEffects[sfxNumber].Stop();
    }
}
