using UnityEngine;
using TMPro;

public class Pickup : MonoBehaviour
{
    public ScoreManager ScoreManager; // Reference to the ScoreManager  
    public int value = 10; // Score value for the pickup  

    private AudioSource audioSource; // Reference for the AudioSource  
    private ParticleSystem particleSystem; // Reference for the ParticleSystem  

    private void Start()
    {
        // Initialize AudioSource and ParticleSystem components  
        audioSource = GetComponent<AudioSource>();
        particleSystem = GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // Add score to the ScoreManager  
            ScoreManager.AddScore(value);

            // Play the audio source  
            audioSource?.Play();

            // Play the particle system  
            particleSystem?.Play();

            // Destroy the pickup after a short delay  
            GameObject.Destroy(gameObject, 0.5f);
        }
    }

    void Update()
    {
        // Any update logic (if needed)  
    }
}