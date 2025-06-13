using UnityEngine;

public class DispararProyectil : MonoBehaviour
{
    public GameObject proyectilPrefab;  // Asigna aqu� tu prefab del proyectil
    public float velocidadDisparo = 10f;
    public Transform puntoDeDisparo;    // Punto desde donde sale el proyectil

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Disparar();
        }
    }

    void Disparar()
    {
        // Instancia el proyectil en la posici�n y rotaci�n del punto de disparo
        GameObject nuevoProyectil = Instantiate(proyectilPrefab, puntoDeDisparo.position, puntoDeDisparo.rotation);

        // Le da velocidad en la direcci�n del eje Y local (arriba del objeto que dispara)
        Rigidbody2D rb = nuevoProyectil.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = puntoDeDisparo.up * velocidadDisparo;
        }
    }
}
