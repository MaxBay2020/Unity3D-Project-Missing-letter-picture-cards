using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip buttonClickedClip, congratsClip;

    public static SoundManager _instance;
    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
    }

    public void ButtonClickedClipPlay()
    {
        audioSource.PlayOneShot(buttonClickedClip);
    }

    public void CongratsClipPlay()
    {
        audioSource.PlayOneShot(congratsClip);
    }
}
