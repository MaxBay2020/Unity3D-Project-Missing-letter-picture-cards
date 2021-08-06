using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OptionButton2Effect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    public Texture enterEffectSprite;
    private Texture leaveEffectSprite;
    private Color red;
    private Color white;


    /// <summary>
    /// when the pointer enters the option1 button
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerEnter(PointerEventData eventData)
    {
        leaveEffectSprite = this.GetComponent<RawImage>().texture;
        this.GetComponent<RawImage>().texture = enterEffectSprite;
        red = this.transform.Find("text").GetComponent<Text>().color;
        this.transform.Find("text").GetComponent<Text>().color = Color.white;
    }

    /// <summary>
    /// when the pointer leaves the option1 button
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerExit(PointerEventData eventData)
    {
        this.GetComponent<RawImage>().texture = leaveEffectSprite;
        this.transform.Find("text").GetComponent<Text>().color = red;
    }
}
