using UnityEngine;

public class ExplodeOnCollision : MonoBehaviour
{
    public string targetTag = "Enemy"; // Tag om het object aan te wijzen dat kan exploderen  
    public GameObject effect; // Referentie naar het explosie prefab  
    private AudioSource audioSource; // Referentie naar de audio source  

    private void Start()
    {
        bool tagFound = false; // Boolean om bij te houden of de tag is gevonden  

        // Loop door de lijst van gedefinieerde tags in Unity  
        foreach (string tag in UnityEditorInternal.InternalEditorUtility.tags)
        {
            // Controleer of de ingevoerde tag in de lijst zit  
            if (targetTag == tag)
            {
                tagFound = true;
                break;
            }
        }

        // Als de tag niet in de lijst is gevonden, log een error message  
        if (!tagFound)
        {
            Debug.LogError("TargetTag: " + targetTag + " for '" + gameObject.name + "' not found!");
        }

        // Haal de AudioSource component op  
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        CheckAndExplode(collision.gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        CheckAndExplode(other.gameObject);
    }

    void CheckAndExplode(GameObject collidedObject)
    {
        // Controleer of het object de juiste tag heeft  
        if (collidedObject.CompareTag(targetTag))
        {
            // Instantieer de explosie en sla het op in een variabele  
            GameObject expl = Instantiate(effect, transform.position, transform.rotation);

            // Verwijder de explosie na 2 seconden  
            Destroy(expl, 2f);

            // Verwijder het andere GameObject waarmee de collision is geweest  
            Destroy(collidedObject, 0.1f);

            // Speel het explosiegeluid af  
            if (audioSource != null)
            {
                audioSource.Play();
            }
        }
    }
}