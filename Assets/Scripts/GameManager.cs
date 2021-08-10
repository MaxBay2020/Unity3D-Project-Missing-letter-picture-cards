using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager _instance;

    public GameObject[] allCards;
    public static int index;
    public static int score;
    public GameObject greyBg;
    public Text scoreText;
    public GameObject scorePanel;

    private void Awake()
    {
        _instance = this;
    }

    public void ShowNextCard()
    {
        

        // hide current card
        allCards[index].SetActive(false);
        // display next card
        index++;
        if (index > allCards.Length-1)
        {
            ShowResultPanel();
            return;
        }

        allCards[index].SetActive(true);
    }

    public void ScoreIncrement()
    {
        score++;
    }

    public void ShowResultPanel()
    {
        // 1. make bg grey
        greyBg.SetActive(true);

        //// 2. fill in the blank with score
        //scoreText.GetComponent<Text>().text = score+"";

        // 3. activate the score panel
        scorePanel.GetComponent<Animator>().enabled = true;
    }
}
