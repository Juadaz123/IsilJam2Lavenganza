using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    private float velocity = 0f;

    void Update()
    {
        transform.Translate(Vector2.up * velocity * Time.deltaTime);
    }
}
