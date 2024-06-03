using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public SpriteRenderer sprite;
    public float R, G, B;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    //resetting each time the game starts over
    void OnEnable()
    {
        speed = 1f;
        R = 0f;
        B = 0f;
        G = 0f;
        colorForward = true;
    }

    public float speed = 1.0f;

    bool colorForward = true;
    void FixedUpdate()
    {
        //handling the color's changing back and forward
        if (colorForward)
        {
            if (R < 255)
            {
                R++;
            }
            else
                if (G < 255)
            {
                G++;
            }
            else
            {
                B++;
                if (R == 255 && G == 255 && B == 255)
                {
                    colorForward = false;
                }
            }
        }
        else
        {
            if (R > 0)
            {
                R--;
            }
            else
                if (G > 0)
            {
                G--;
            }
            else
            {
                B--;
                if (R == 0 && G == 0 && B == 0)
                {
                    colorForward = true;

                    //making the game faster
                    float first = speed;
                    speed += 0.3f;
                    float second = speed;

                    //incresing enemy spawnrate
                    GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>().maxTime = first / second * GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>().maxTime;
                }
            }
        }

        //applying the changed color
        sprite.color = new Color(R / 255, G / 255, B / 255, 255);
    }
}
