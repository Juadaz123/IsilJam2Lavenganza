using UnityEngine;

public class rotador : MonoBehaviour
{
    public float velocidadRotacion = 200f;

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 0, velocidadRotacion * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0, -velocidadRotacion * Time.deltaTime);
        }
    }
}
