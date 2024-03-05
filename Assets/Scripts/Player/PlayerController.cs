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
    private int baseLayerIndex;
    private bool isAttacking = false;
    private Coroutine resetLayerWeightCoroutine;
    private bool attack1Pressed = false;
    private bool attack2Pressed = false;
    private bool attack3Pressed = false;
    private bool attack4Pressed = false;
    public GameObject BladeLeft;
    public GameObject BladeRight;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        footLayerIndex = animator.GetLayerIndex("Foots");
        baseLayerIndex = animator.GetLayerIndex("Base Layer");
    }

    private void Update()
    {
        animationMovement();
        animationAttack();
    }


    private void FixedUpdate()
    {
        if (!isAttacking)
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
                rb.velocity = movement * speed * Time.deltaTime;
            }
        }

        else
        {
            rb.velocity = Vector3.zero;
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
        if (Input.GetMouseButton(0) && !attack1Pressed)
        {
            attack1Pressed = true;
            TriggerAttack("Attack1");
        }
        else if (!Input.GetMouseButton(0))
        {
            attack1Pressed = false;
        }

        if (Input.GetMouseButton(1) && !attack2Pressed)
        {
            attack2Pressed = true;
            TriggerAttack("Attack2");
        }
        else if (!Input.GetMouseButton(1))
        {
            attack2Pressed = false;
        }

        if (Input.GetKey(KeyCode.R) && !attack3Pressed)
        {
            attack3Pressed = true;
            TriggerAttack("Attack3");
        }
        else if (!Input.GetKey(KeyCode.R))
        {
            attack3Pressed = false;
        }

        if (Input.GetKey(KeyCode.F) && !attack4Pressed)
        {
            attack4Pressed = true;
            TriggerAttack("Attack4");
        }
        else if (!Input.GetKey(KeyCode.F))
        {
            attack4Pressed = false;
        }

    }

    private void TriggerAttack(string triggerName)
    {   
        isAttacking = true;
        animator.SetLayerWeight(footLayerIndex, 0f);
        animator.SetTrigger(triggerName);
        resetLayerWeightCoroutine = StartCoroutine(ResetLayerWeight());
    }

    private IEnumerator ResetLayerWeight()
    {
        yield return new WaitForEndOfFrame(); // Esperar al final del frame actual para asegurarse de que la animación se haya iniciado
        BladeLeft.SetActive(true);
        BladeRight.SetActive(true);
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(baseLayerIndex).length); // Esperar hasta que la animación actual termine
        print(animator.GetCurrentAnimatorStateInfo(footLayerIndex).length);
        animator.SetLayerWeight(footLayerIndex, 1f);
        isAttacking = false;
        resetLayerWeightCoroutine = null;
        BladeLeft.SetActive(false);
        BladeRight.SetActive(false);
    }
}
