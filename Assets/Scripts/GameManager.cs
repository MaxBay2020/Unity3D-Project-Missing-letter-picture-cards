using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager _instance;

    public GameObject[] allCards;
    public static int index;
    public static int numberOfCorrects;

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
            return;
        }

        allCards[index].SetActive(true);
    }
}
