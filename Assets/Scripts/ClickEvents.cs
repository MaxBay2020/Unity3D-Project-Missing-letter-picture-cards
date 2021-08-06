using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickEvents : MonoBehaviour
{
    public Texture soundMutedImage, soundUnmutedImage;
    public GameObject musicIcon;
    private bool hasMusic = true;

    /// <summary>
    /// when mute button clicked, mute the bg music
    /// </summary>
    public void MuteButtonClicked()
    {
        if (hasMusic)
        {
            // 1. switch sprite to muted image
            musicIcon.GetComponent<RawImage>().texture = soundMutedImage;
            // 2. turn off music
            Camera.main.GetComponent<AudioSource>().mute = true;
        }
        else
        {
            // 1. switch sprite to unmuted image
            musicIcon.GetComponent<RawImage>().texture = soundUnmutedImage;
            // 2. turn on music
            Camera.main.GetComponent<AudioSource>().mute = false;
        }
        hasMusic = !hasMusic;
    }
}
