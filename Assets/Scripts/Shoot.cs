using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject prefab; // De bullet prefab  

    void Update()
    {
        // Controleer of de linker Ctrl-toets is ingedrukt  
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            ShootBullet();
        }
    }

    void ShootBullet()
    {
        // Instantieer de bullet prefab  
        GameObject ob = Instantiate(prefab);

        // Geef de bullet dezelfde rotatie als de speler  
        ob.transform.rotation = transform.rotation;

        // Plaats de bullet iets voor de speler  
        ob.transform.position = transform.position + transform.forward; // Of een andere richting  

        // Vernietig de bullet na 3 seconden  
        Destroy(ob, 3f);
    }
}