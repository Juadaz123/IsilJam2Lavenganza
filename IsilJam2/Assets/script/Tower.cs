using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private KeyCode keyUP;
    [SerializeField] private KeyCode keyDown;
    [SerializeField] private KeyCode keyForce;
    [SerializeField] private GameObject bullet;

    //refererncia del objeto
    private Transform TowerTransform;

    private float _angleToShooting;
    [SerializeField] private float minAngle;
    [SerializeField] private float maxAngle;

    //Force
    private float ShootForce = 0f;
    private float lerpTime = 0f;
    private float duration = 1.5f;


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
        _angleToShooting = Mathf.Clamp(_angleToShooting, minAngle, maxAngle);
        directionUp();
        directionDown();
        ExecuteForce();
        ThrowShot();
        TowerTransform.localEulerAngles = new Vector3(0, transform.rotation.y,_angleToShooting);
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
        if (Input.GetKey(keyForce))
        {
            lerpTime += Time.deltaTime / duration;
            ShootForce = Mathf.Lerp(5f, 10f, lerpTime);
        }
    }


    public void ThrowShot()
    {
        if (Input.GetKeyUp(keyForce))
        {
            GameObject clone = Instantiate(bullet, transform.position, transform.rotation);

            if (clone.TryGetComponent<Bullet>(out var mover))
            {
                mover.Fire(ShootForce);
            }

            // Reiniciar fuerza y tiempo
            ShootForce = 0f;
            lerpTime = 0f;
        }
    }
}
