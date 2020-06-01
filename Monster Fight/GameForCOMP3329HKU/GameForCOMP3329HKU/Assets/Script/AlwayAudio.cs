using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwayAudio : MonoBehaviour
{
    public AudioSource audioTheme;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        if (!audioTheme.isPlaying)
        {
            audioTheme.Play();
        }

    }
}
