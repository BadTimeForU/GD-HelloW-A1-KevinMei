using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float projectileSpeed = 20f;
    public float fireRate = 0.5f;
    private float nextFireTime = 0f;
    public AnimationClip fireClip;
    public Animator[] aniamtion;


    void Update()
    {
        Animator animator = GetComponent<Animator>();
        if (gameObject.CompareTag("Player"))
        {
            if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
            {
                FireProjectile();
                nextFireTime = Time.time + fireRate;
            }
        }
        else
        {
            if (Time.time >= nextFireTime)
            {
                FireProjectile();
                animator.SetTrigger("Gtafemboyskissing");
                nextFireTime = Time.time + fireRate;
            }
        }
    }

    void FireProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(firePoint.forward * projectileSpeed, ForceMode.VelocityChange);
        }
    }
}