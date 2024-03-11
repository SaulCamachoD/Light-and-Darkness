using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField] protected float speed = 5f;
    [SerializeField] protected float attackRange = 1f;
    [SerializeField] protected float hitForce = 2f;
    [SerializeField] private float health = 120f;
    [SerializeField] protected Animator animator;
    protected bool isDeath = false;
    protected Rigidbody rb;
    protected GameObject player;
    protected CountZombieDeaths countDies;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
        countDies = GameObject.Find("Dies").GetComponent<CountZombieDeaths>();
    }

    protected virtual void Update()
    {
        if (!isDeath)
        {
            Vector3 playerPosition = player.transform.position;
            Vector3 direction = (playerPosition - transform.position).normalized;
            transform.LookAt(playerPosition);

            float distanceToPlayer = Vector3.Distance(transform.position, playerPosition);

            if (distanceToPlayer > attackRange)
            {
                animator.SetBool("Walk", true);
                rb.MovePosition(transform.position + direction * speed * Time.deltaTime);
            }
            else
            {
                animator.SetBool("Walk", false);
                animator.SetTrigger("Attack");
            }
        }
    }

    public virtual void AttackControl()
    {
        // Implementar en clases derivadas si es necesario
    }

    public virtual void StopAttack()
    {
        // Implementar en clases derivadas si es necesario
    }

    public virtual void ApplyHitForce(Vector3 hitDirection)
    {
        rb.AddForce(hitDirection * hitForce, ForceMode.Impulse);
    }

    public virtual void Die()
    {
        isDeath = true;
        
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Blades"))
        {
            health -= 5f;
            if (health <= 0)
            {
                StartCoroutine(DeathRutine());

            }
        }
    }
    private IEnumerator DeathRutine()
    {
        animator.SetTrigger("Death");
        Die();

        yield return new WaitForSeconds(3);

        Destroy(gameObject);
        countDies.ZombieDies();
    }
}

