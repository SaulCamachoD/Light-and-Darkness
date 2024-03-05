using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.UIElements.ToolbarMenu;

public class ZombieHealth : MonoBehaviour
{   
    public Animator animator;
    private ZombieController zombieController;
    public float health = 120f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        zombieController = GetComponent<ZombieController>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Blades"))
        {
            health -= 5f;
            if(health <= 0)
            {
                StartCoroutine(DeathRutine());
                
            }
        }
    }
    private IEnumerator DeathRutine()
    {
        animator.SetTrigger("Death");
        zombieController.Die();

        yield return new WaitForSeconds(3);

        Destroy(gameObject);
    }
}
