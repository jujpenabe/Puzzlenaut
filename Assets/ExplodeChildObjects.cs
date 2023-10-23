using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeChildObjects : MonoBehaviour
{
    // Make explosion with child objects, origin parent location, then destroy the parent after a delay
    public float explosionForce = 100f;
    public float explosionRadius = 10f;
    public float explosionUpward = 1f;
    public float delay = 1f;
    void Start()
    {   
        Invoke(nameof(Explode), delay);
    }
    
    // Disatach child object and apply random explosion force to each child object then destroy the parent
    private void Explode()
    {
        foreach (Transform child in transform)
        {
            Rigidbody rb = child.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpward);
            }
        }
        // Wait to destroy parent object
    }
}
