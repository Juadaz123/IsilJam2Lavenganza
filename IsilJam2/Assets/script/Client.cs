using System;
using Unity.VisualScripting;
using UnityEngine;

public class Client : MonoBehaviour
{
    private float velocity;

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
}
