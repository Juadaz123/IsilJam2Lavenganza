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

    //Force
    private float ShootForce = 0f;
    private float target = 10; // Valor final
    private float lerpTime = 0; // Factor de interpolaci�n
    private float duration = 5f; // Duraci�n de la interpolaci�n

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TowerTransform = gameObject.transform;
        if (TowerTransform == null)
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
        // Actualizar el factor de interpolaci�n en cada frame
        if (Input.GetKey(keyForce) && ShootForce < 10)
        {
            lerpTime += Time.deltaTime / duration;
            ShootForce = Mathf.Lerp(ShootForce, 20, lerpTime);
        }
    }

    public void ThrowShot()
    {
        if(Input.GetKeyUp(keyForce))
        {
            GameObject clone = Instantiate(bullet, transform.position, Quaternion.identity);

            if (clone.TryGetComponent<Client>(out var mover))
            {
                mover.SetVelocity(ShootForce);
            }

            ShootForce = 0f;
        }
    }
}
