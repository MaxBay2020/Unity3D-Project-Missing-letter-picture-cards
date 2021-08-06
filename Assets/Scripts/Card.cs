using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    // Start is called before the first frame update
    private string[] vowels = { "a", "e", "i", "o", "u" };
    private string correctAnswer;
    private string leftOption, rightOption;
    private AudioSource audioSource;
    public AudioClip correctAudioClip, wrongAudioClip;

    private void Awake()
    {
        correctAnswer = this.transform.Find("answer").GetComponent<Text>().text;
        audioSource = this.GetComponent<AudioSource>();
    }

    void Start()
    {
        // 1. a random number, which decides which one should show the correct answer
        int randomNum = Random.Range(1, 3);
        // if the random number is 0,
        // the correct answer will be on the left
        this.transform.Find("option"+randomNum).Find("text").GetComponent<Text>().text = correctAnswer;

        // 2. the other side will be the random vowel, except for the correct answer
        
        while (true)
        {
            int randomIndex = Random.Range(0, vowels.Length);
            if (vowels[randomIndex] == correctAnswer)
                continue;
            else
            {
                if (randomNum == 1)
                    this.transform.Find("option2").Find("text").GetComponent<Text>().text = vowels[randomIndex];
                else
                    this.transform.Find("option1").Find("text").GetComponent<Text>().text = vowels[randomIndex];
                break;
            }
        }


        // 3. store two options value;
        leftOption = this.transform.Find("option1").Find("text").GetComponent<Text>().text;
        rightOption= this.transform.Find("option2").Find("text").GetComponent<Text>().text;
       

    }

    /// <summary>
    /// when option1 selected
    /// </summary>
    public void OptionButton1Clicked()
    {
        // play click sound
        SoundManager._instance.ButtonClickedClipPlay();

        if (correctAnswer == leftOption)
        {
            // if it is correct, 
            // 1. play correct audio clip
            CorrectAudioPlay();
            // 2. display the right vowel on the blank
            DisplayCorrectVowel();
            // 3. move on to the next card
            StartCoroutine(ShowNextCard(1.0f));
        }
        else
        {
            WrongAudioPlay();
        }
    }

    /// <summary>
    /// when option2 selected
    /// </summary>
    public void OptionButton2Clicked()
    {
        // play click sound
        SoundManager._instance.ButtonClickedClipPlay();

        if (correctAnswer == rightOption)
        {
            // if it is correct, 
            // 1. play correct audio clip
            CorrectAudioPlay();

            // 2. display the right vowel on the blank
            DisplayCorrectVowel();

            // 3. move on to the next card
            StartCoroutine(ShowNextCard(1.0f));
            
        }
        else
        {
            WrongAudioPlay();
        }
    }

    /// <summary>
    /// play correct audio clip once
    /// </summary>
    private void CorrectAudioPlay()
    {
        audioSource.PlayOneShot(correctAudioClip);
    }

    IEnumerator ShowNextCard(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        GameManager._instance.ShowNextCard();
    }

    /// <summary>
    /// play wrong audio clip once
    /// </summary>
    private void WrongAudioPlay()
    {
        audioSource.PlayOneShot(wrongAudioClip);
    }

    private void DisplayCorrectVowel()
    {
        this.transform.Find("word").Find("blank").GetComponent<Text>().text = correctAnswer;

    }
}
