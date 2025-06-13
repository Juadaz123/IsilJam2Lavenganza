using UnityEngine;

public class MostrarTecla : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKeyDown)
        {
            foreach (KeyCode tecla in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(tecla))
                {
                    Debug.Log("Tecla presionada: " + tecla);
                    break;
                }
            }
        }
    }
}
