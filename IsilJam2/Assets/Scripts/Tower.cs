using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Tower : MonoBehaviour
{
    [SerializeField] private KeyCode keyUP;
    [SerializeField] private KeyCode keyDown;
    [SerializeField] private KeyCode keyForce;

    //refererncia del objeto
    private Transform TowerTransform;

    //declaran
    [Range(0f, 90f)]
    private float _angleToShooting;
  
    private float ShootForce;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TowerTransform = gameObject.transform;
        if(TowerTransform == null)
        {
            Debug.Log("Se obtiene el tranform correctamente");
        }
    }

    // Update is called once per frame
    void Update()
    {
        _angleToShooting = Mathf.Clamp(_angleToShooting, 0f, 90f);
        directionUp();
        directionDown();


        ExecuteForce();

        TowerTransform.localEulerAngles = new Vector3(0, 0, _angleToShooting);


        
    }

    private void directionUp()
    {
        if (Input.GetKey(keyUP))
        {
            _angleToShooting++;

            Debug.Log(TowerTransform.localRotation.z);
        }

    }

    private void directionDown()
    {
        if (Input.GetKey(keyDown))
        {
            _angleToShooting--;
        }
    }

    private void ExecuteForce()
    {
        ShootForce = 0f;
        float target = 10; // Valor final
        float lerpTime = 0; // Factor de interpolación
        float duration = 5f; // Duración de la interpolación

        // Actualizar el factor de interpolación en cada frame
        lerpTime += Time.deltaTime / duration;

        if(Input.GetKey(keyForce))
        ShootForce = Mathf.Lerp(ShootForce, 20, lerpTime);

        // (Opcional) Asegurar que se alcance el valor final
        if (lerpTime >= 1)
        {
            ShootForce = target;
        }

        if(Input.GetKeyUp(keyForce))
        {
            //disparar la bala
            ShootForce = 0f;
                Debug.Log(ShootForce + "dime valor");
        }
    }

}
