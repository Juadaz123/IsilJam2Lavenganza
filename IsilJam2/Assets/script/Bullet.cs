using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    private float velocity = 0f;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        rb.AddForce(Vector2.up * velocity * Time.deltaTime);
    }
}
