using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public ParticleSystem pc;
    void OnEnable()
    {
        pc.Play();
    }

    public bool gameIsGoing;
    void Update()
    {
        //if gameIsGoing because when we stop time at gameOver, player still follows cursor
        if (gameIsGoing)
        {
            Vector2 location = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(location.x, location.y);
        }
    }

    //when player collides with an enemy then the game is over
    //player can collide only with enemies so theres no need to check what it collided with
    void OnTriggerEnter2D(Collider2D collision)
    {
        GameOver();
    }

    //handling the lose panel and the stop of the game at gameOver
    public GameObject losePanel;
    void GameOver()
    {
        Cursor.visible = true;

        gameIsGoing = false;

        losePanel.SetActive(true);

        Time.timeScale = 0;
    }

}
