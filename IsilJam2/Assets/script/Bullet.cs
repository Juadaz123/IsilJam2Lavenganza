using UnityEngine;

public class Bullet : MonoBehaviour

{

    private Rigidbody2D rb;


    public void Fire(float v)
    {

        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * v * 2, ForceMode2D.Impulse);
        print("FIRE");
    }

    void OnBecameInvisible()
    {
        print("Se destruyo");
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
