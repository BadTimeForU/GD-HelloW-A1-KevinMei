using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipWeapon : MonoBehaviour
{
    public GameObject Gun;
    public Transform WeaponParent;

    void Start()
    {
        Gun.GetComponent<Rigidbody>().isKinematic = true; // Fixed typo: Getcomponent to GetComponent and isKimematic to isKinematic  
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.F)) // Fixed casing issues  
        {
            Drop(); // Added braces for the if statement  
        }
    }

    void Drop()
    {
        WeaponParent.DetachChildren();
        Gun.transform.position = new Vector3(Gun.transform.position.x, Gun.transform.position.y, Gun.transform.position.z); // Adjusted to set position correctly, but still needs review  
        Gun.GetComponent<Rigidbody>().isKinematic = false; // Fixed typo: Getcomponent to GetComponent  
        Gun.GetComponent<MeshCollider>().enabled = true; // Fixed typo: Meshcollider to MeshCollider  
    }

    void Equip()
    {
        Gun.GetComponent<Rigidbody>().isKinematic = true; // Fixed typo  

        Gun.transform.position = WeaponParent.position; // No need for .transform  
        Gun.transform.rotation = WeaponParent.rotation; // No need for .transform  

        Gun.GetComponent<MeshCollider>().enabled = false; // Fixed casing  

        Gun.transform.SetParent(WeaponParent); // Fixed casing: setParent to SetParent  
    }

    private void OnTriggerStay(Collider other) // Fixed casing: OnTriggerstay to OnTriggerStay  
    {
        if (Input.GetKey(KeyCode.E)) // Fixed casing issues  
        {
            Equip();
        }
    }
}