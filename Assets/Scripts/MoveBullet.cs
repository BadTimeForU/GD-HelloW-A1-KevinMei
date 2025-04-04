using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    public float speed = 500f; // Snelheid van de bullet  
    private Rigidbody rb; // Referentie naar de Rigidbody  

    void Start()
    {
        // Haal de Rigidbody component op  
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Update de snelheid van de bullet  
        rb.velocity = rb.transform.forward * speed * Time.fixedDeltaTime;
    }
}