using UnityEngine;

public class Gun : MonoBehaviour
{
    private float rotateOffset = 0f;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float delayShot = 10f;

    [SerializeField] private float damage = 20f;
    private float nextTime;

    private Transform target;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RotateGun();
    }

    void RotateGun()
    {
        Vector3 mouserPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouserPos.z = 0f;

        Vector2 dir = (mouserPos - transform.position).normalized;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        angle -= 90f;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    void Shoot()
    {
        if(Time.time >= nextTime)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            nextTime = Time.time + delayShot;
        }
    }
}
