using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float fireRate = 0;
    public float damage = 10;
    public LayerMask whatToHit;
    public Transform BulletTrailPrefab;
    public Transform MuzzleFlashPrefab;
    
    private float timeToSpawnEffect = 0;
    public float effectSpawnRate = 10;
    private float timeToFire = 0;
    private Transform firePoint;

    void Awake()
    {
        firePoint = transform.Find("FirePoint");
        if (firePoint == null)
        {
            Debug.LogError("No FirePoint found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (fireRate == 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
        else
        {
            if (Input.GetButton("Fire1") && Time.time > timeToFire)
            {
                timeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }
    }

    void Shoot()
    {
        Vector2 mouseWorldPoints = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePosition = new Vector2(mouseWorldPoints.x, mouseWorldPoints.y);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        Vector2 direction = mousePosition - firePointPosition;
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, direction, 100, whatToHit);
        if (Time.time >= timeToSpawnEffect)
        {
            Effect();
            timeToSpawnEffect = Time.time + 1 / effectSpawnRate;
        }

        if (hit.collider != null)
        {
            Debug.Log("We hit " + hit.collider.name + " and did " + damage + " Damage");
        }
    }

    void Effect()
    {
        Instantiate(BulletTrailPrefab, firePoint.position, firePoint.rotation);
        Transform muzzleFlash = Instantiate(MuzzleFlashPrefab, firePoint.position, firePoint.rotation);
        muzzleFlash.parent = firePoint;
        float size = Random.Range(0.6f, 0.9f);
        muzzleFlash.localScale = new Vector3(size, size, size);
        Destroy(muzzleFlash.gameObject, 0.02f);
    }
}