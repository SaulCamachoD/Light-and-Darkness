using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 50f;
    private float fwdSpeed = 2f;
    private Rigidbody rb;
    public Animator animator;
    private int footLayerIndex;
    private Coroutine resetLayerWeightCoroutine;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        footLayerIndex = animator.GetLayerIndex("Foots");
    }

    private void Update()
    {
        animationMovement();
        animationAttack();
    }


    private void FixedUpdate()
    {
        float movsX = Input.GetAxis("Horizontal");
        float movsY = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(movsX, 0f, movsY).normalized;
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = movement * speed * fwdSpeed * Time.deltaTime;
        }
        else 
        {
            rb.velocity = movement * speed  * Time.deltaTime;
        }
    }

    private void animationMovement()
    {
        if (!Input.GetKey(KeyCode.W))
        {
            
            animator.SetFloat("fwd", 0.0f);
        }
        else
        {
            animator.SetFloat("fwd", 1.0f);
        }

        if (!Input.GetKey(KeyCode.S))
        {
            animator.SetFloat("aft", 0.0f);
        }
        else
        {
            animator.SetFloat("aft", -1.0f);
        }


        if (!Input.GetKey(KeyCode.D))
        {
            animator.SetFloat("right", 0.0f);
        }
        else
        {
            animator.SetFloat("right", 1.0f);
        }

        if (!Input.GetKey(KeyCode.A))
        {
            animator.SetFloat("left", 0.0f);
        }
        else
        {
            animator.SetFloat("left", -1.0f);
        }
    }

    private void animationAttack()
    {
        if (Input.GetMouseButton(0))
        {
            TriggerAttack("Attack1");
        }

        if (Input.GetMouseButton(1))
        {
            TriggerAttack("Attack2");
        }

        if (Input.GetKey(KeyCode.R))
        {
            TriggerAttack("Attack3");
        }

        if (Input.GetKey(KeyCode.F))
        {
            TriggerAttack("Attack4");
        }

    }

    private void TriggerAttack(string triggerName)
    {
        animator.SetLayerWeight(footLayerIndex, 0f);
        animator.SetTrigger(triggerName);

        if (resetLayerWeightCoroutine != null)
            StopCoroutine(resetLayerWeightCoroutine);

        resetLayerWeightCoroutine = StartCoroutine(ResetLayerWeight());
    }

    private IEnumerator ResetLayerWeight()
    {
        yield return new WaitForEndOfFrame(); // Esperar al final del frame actual para asegurarse de que la animación se haya iniciado

        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(footLayerIndex).length); // Esperar hasta que la animación actual termine

        animator.SetLayerWeight(footLayerIndex, 1f);
        resetLayerWeightCoroutine = null;
    }
}
