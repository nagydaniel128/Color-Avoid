using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    void Start()
    {
        //get random speed
        speed = Random.Range(5, 8);

        //with a small chance (20%) they start moving up/down, not just left
        if(Random.Range(0,10) < 2)
            upDownSpeed = Random.Range(-2, 2);

        //get random size
        transform.localScale = new Vector3(Random.Range(0.2f, 3), Random.Range(0.2f, 3));

        //getting the spriteRenderer and applying a random color to it
        spriteRenderer = GetComponent<SpriteRenderer>();
        R = Random.Range(0, 255);
        G = Random.Range(0, 255);
        B = Random.Range(0, 255);
        spriteRenderer.color = new Color(R / 255, G / 255, B / 255, 255);
    }


    int speed;
    int upDownSpeed;

    float R, G, B;
    void Update()
    {
        //try to move according to the background's speed
        //if there's no background, it means the game is over so remaining enemies should destroy themselves
        try
        {
            transform.position = transform.position + new Vector3(-(speed * GameObject.Find("Background").GetComponent<Background>().speed) * Time.deltaTime, upDownSpeed * Time.deltaTime, 0);
        }
        catch
        {
            Destroy(gameObject);
        }
    }

    bool colorForward = true;
    void FixedUpdate()
    {
        //if the enemy is out of screen it dies
        if (transform.position.x < -10.5f)
        {
            Destroy(this.gameObject);
        }

        //handling the color's changing back and forward
        for (int i = 0; i < 5; i++)
        {
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
                        }
                    }
            }
        }

        //applying the changed color
        spriteRenderer.color = new Color(R / 255, G / 255, B / 255, 255);
    }

}
