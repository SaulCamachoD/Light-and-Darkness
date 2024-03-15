using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthAndDamage : MonoBehaviour

{
    public HudManagment hud;
    public Animator animator;
    public float health = 800;
    public float maxHealth;
    private void Awake()
    {
        maxHealth = health ;
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
        hud = GameObject.Find("HUD").GetComponent<HudManagment>();
        
    }

    private void Update()
    {
        if(health <= 0)
        {
            hud.Finished();
            animator.SetTrigger("Death");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Claws"))
        {
            health -= 5f;
            //animator.SetTrigger("GetHit");

        }

        if (other.CompareTag("ClawsStrong"))
        {
            health -= 15f;
            //animator.SetTrigger("GetHit");
        }
    }

    public void AddHealt()
    {
        health += 200f;
    }




}
