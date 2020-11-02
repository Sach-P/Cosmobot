using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject crosshairs;
    public GameObject player;
    public GameObject bulletPrefab;
    public GameObject bulletStart;
    public CameraShake cameraShake;
    private Vector3 target;

    [SerializeField]
    private float shakeMag;
    [SerializeField]
    private float shakeDur;


    public float bulletSpeed = 60.0f;
    public float startBulletTime = 0.2f;
    public float bulletTime = 0.0f;
   
    void Start()
    {
        Cursor.visible = false; 
    }

    void Update()
    {
        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        crosshairs.transform.position = new Vector2(target.x, target.y);

        Vector3 difference = target - player.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        player.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

        if (Input.GetMouseButton(0))
        {
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            if (bulletTime <= 0)
            {
               fireBullet(direction, rotationZ);
               bulletTime = startBulletTime;
            }
            else
            {
                bulletTime -= Time.deltaTime;
            }
            
        }

       
    }

    void fireBullet(Vector2 direction, float rotationZ)
    {
        GameObject b = Instantiate(bulletPrefab) as GameObject;
        b.transform.position = bulletStart.transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        StartCoroutine(cameraShake.Shake(shakeDur, shakeMag));
    }
}
