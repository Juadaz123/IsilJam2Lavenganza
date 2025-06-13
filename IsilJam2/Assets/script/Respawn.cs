using System.Collections;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private float velocity;
    [SerializeField] private float timeRespawn = 2f;
    [SerializeField] private bool leftOrRight = false;
    [SerializeField] private GameObject client;
    [SerializeField] private new Camera camera;

    private void Start()
    {
        StartCoroutine(RespawnCycle());
    }

    IEnumerator RespawnCycle()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeRespawn);

            if (client != null)
            {
                //Obtengo la medida de la camara y posiciono el cliente
                Vector2 vectorRespawn = camera.transform.position;
                float extremes = (camera.orthographicSize * 2 * camera.aspect / 2) + 2;
                vectorRespawn.x = leftOrRight ? -extremes : extremes;
                vectorRespawn.y = -(camera.orthographicSize / 2);   

                GameObject clone = Instantiate(client, vectorRespawn, Quaternion.identity);

                if (clone.TryGetComponent<Client>(out var mover))
                {
                    mover.SetVelocity(leftOrRight ? velocity : -velocity);
                }

                leftOrRight = !leftOrRight;
            }
            else
            {
                Debug.LogWarning("No se asignó el prefab 'client' al respawner.");
            }
        }
    }
}
