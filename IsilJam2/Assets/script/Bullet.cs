using UnityEngine;

public class Bullet : MonoBehaviour

{
    private ScoreController score;
    [SerializeField] private GameObject bullet;
    private float velocity = 0f;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        score = GameObject.Find("ScoreController").GetComponent<ScoreController>();
    }
    void Update()
    {
        rb.AddForce(Vector2.up * velocity * Time.deltaTime);
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
