using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TMP_Text text;
    void Awake()
    {
        text = GetComponent<TMP_Text>();
    }

    //resetting score
    private void OnEnable()
    {
        score = 0;
    }

    //handling the score
    public float score;
    void FixedUpdate()
    {
        //if the game is in the menu it cant find the "Background" element
        try
        {
            score += GameObject.Find("Background").GetComponent<Background>().speed * 3;
            int intScore = (int)score;
            text.text = (intScore / 80).ToString();
        }
        catch { }
    }
}
