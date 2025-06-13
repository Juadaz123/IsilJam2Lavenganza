using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private KeyCode keyUP;
    [SerializeField] private KeyCode keyDown;
    [SerializeField] private KeyCode keyForce;
    [SerializeField] private GameObject bullet;

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
   
        directionUp();
        directionDown();
        ExecuteForce();
        if (Input.GetKeyUp(keyForce))
        {

            GameObject clone = Instantiate(bullet, transform.position, Quaternion.identity);
            print(ShootForce);

            if (clone.TryGetComponent<Client>(out var mover))
            {
                mover.SetVelocity(ShootForce);
            }
            TowerTransform.localEulerAngles = new Vector3(0, 0, _angleToShooting);
            //disparar la bala
            ShootForce = 0f;
            Debug.Log(ShootForce + "dime valor");

            _angleToShooting = Mathf.Clamp(_angleToShooting, 0f, 90f);github
        }

    }



    private void directionUp()
    {
        if (Input.GetKey(keyUP))
        {
            _angleToShooting++;

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
        float lerpTime = 0; // Factor de interpolaci�n
        float duration = 5f; // Duraci�n de la interpolaci�n

        // Actualizar el factor de interpolaci�n en cada frame
        lerpTime += Time.deltaTime / duration;

        if (Input.GetKey(keyForce))
        {
            ShootForce = Mathf.Lerp(ShootForce, 20, lerpTime);
            Debug.Log(ShootForce);

        }

        // (Opcional) Asegurar que se alcance el valor final
        if (lerpTime >= 1)
        {
            ShootForce = target;
        }


    }

}
