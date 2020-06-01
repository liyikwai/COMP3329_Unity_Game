using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource soundFX, audioTheme;

    public AudioClip[] themeSongs;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlaySoundFX(AudioClip clip, float volume)
    {
        soundFX.clip = clip;
        soundFX.volume = volume;
        //soundFX.pitch = Random.Range(.8f, 1);
        soundFX.Play();
    }
}
