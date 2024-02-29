using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float attackRange = 1f; 
    [SerializeField] private Animator animator;
    private Rigidbody rb;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 PlayerPosition = player.transform.position;
        Vector3 direction = (PlayerPosition - transform.position).normalized;
        transform.LookAt(PlayerPosition);

        float distanceToPlayer = Vector3.Distance(transform.position, PlayerPosition);

        if(distanceToPlayer > attackRange)
        {
            //rb.AddForce(direction * speed * Time.deltaTime);
            animator.SetBool("Walk",true);
            rb.MovePosition(transform.position + direction * speed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("Walk", false);
            animator.SetTrigger("Attack");
        }
    }

    
}
