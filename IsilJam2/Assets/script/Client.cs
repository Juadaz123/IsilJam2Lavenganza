using System;
using Unity.VisualScripting;
using UnityEngine;

public class Client : MonoBehaviour
{
    private ScoreController score;
    private float velocity;

    private void Start()
    {
        score = GameObject.Find("ScoreController").GetComponent<ScoreController>();
    }

    public void SetVelocity(float v)
    {
        velocity = v;
    }

    void Update()
    {
        transform.Translate(Vector2.right * velocity * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bullet"))
        {
            print("Cliente satisfecho");
        }
    }

    void OnBecameInvisible()
    {
    
        Destroy(gameObject);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(score.tagPlayer1Goal))
        {
            score.ActulizarPuntaje1();
        }
        else if (collision.gameObject.CompareTag(score.tagPlayer2Goal))
        {
            score.ActulizarPuntaje2();
        }
    }



}
