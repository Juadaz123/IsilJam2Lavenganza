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
}
