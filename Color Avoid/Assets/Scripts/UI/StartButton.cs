using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    //starting the game, resetting everything
    public GameObject startButton, player, score, background, enemySpawner;
    public void StartGame()
    {
        Cursor.visible = false;

        startButton.SetActive(false);
        player.SetActive(true);
        score.SetActive(true);
        background.SetActive(true);
        enemySpawner.SetActive(true);

        player.GetComponent<Player>().gameIsGoing = true;

        Time.timeScale = 1;
    }
}
