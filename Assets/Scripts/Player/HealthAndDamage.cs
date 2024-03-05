using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthAndDamage : MonoBehaviour

{
    public Animator animator;
    public float health = 100f;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Claws"))
        {
            health -= 5f;
            
        }

        if (other.CompareTag("ClawsStrong"))
        {
            health -= 15f;
        }
    }

    




}
