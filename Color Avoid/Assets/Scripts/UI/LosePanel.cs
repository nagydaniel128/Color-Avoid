using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LosePanel : MonoBehaviour
{
    //getting the earned score to show each time we lose 
    private void OnEnable()
    {
        int playerScore = (int)GameObject.Find("ScoreText").GetComponent<Score>().score / 80;

        GameObject.Find("Score").GetComponent<TextMeshProUGUI>().text = playerScore.ToString();
    }


    //back to menu button
    //turns everything off thats required to see the menu again
    public GameObject startButton, player, score, background, enemySpawner;
    public void GoBackToMenu()
    {
        background.GetComponent<Background>().sprite.color = new Color(0, 0, 0);

        startButton.SetActive(true);
        score.SetActive(false);
        background.SetActive(false);
        enemySpawner.SetActive(false);
        player.SetActive(false);

        gameObject.SetActive(false);
    }
}

