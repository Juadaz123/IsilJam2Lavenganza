using UnityEngine;
using TMPro;

public class CuentaRegresivaTMP : MonoBehaviour
{
    public float tiempoRestante;
    public TMP_Text textoTiempo; // Asigna aquí tu TextMeshPro en el Inspector
    private bool cuentaActiva = true;

    void Update()
    {
        if (cuentaActiva)
        {
            tiempoRestante -= Time.deltaTime;

            if (tiempoRestante <= 0f)
            {
                tiempoRestante = 0f;
                cuentaActiva = false;
                Debug.Log("¡Tiempo agotado!");
            }

            ActualizarTexto();
        }
    }

    void ActualizarTexto()
    {
        int segundos = Mathf.CeilToInt(tiempoRestante);
        textoTiempo.text = "Tiempo: " + segundos.ToString();
    }
}
