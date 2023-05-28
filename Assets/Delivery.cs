using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(35, 255, 42, 255);
    [SerializeField] Color32 hasNoPackageColor = new Color32(255, 255, 255, 255);

    bool hasPackage;
    SpriteRenderer spriteRenderer;
    [SerializeField] float destroyDelay = 1f;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();    
    }
    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Ouch!");
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        //Debug.Log("What was that?");
        if(other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Got it");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, destroyDelay);
        }

        if(other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Here you go");
            spriteRenderer.color = hasNoPackageColor;
            hasPackage = false;

        }
    }
}
