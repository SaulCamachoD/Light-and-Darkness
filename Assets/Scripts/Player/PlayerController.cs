using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 180f;
    public float rotation = 18f;
    private Rigidbody rb;
    public Animator animator;
    private int footLayerIndex;
    private int baseLayerIndex;
    //private bool isAttacking = false;
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
    }

    private void Update()
    {
        animationMovement();
        animationAttack();
    }


    private void FixedUpdate()
    {
        
        {
            float movsX = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(0f, 0f, movsX).normalized;

            if (Input.GetKey(KeyCode.W))
            {
                // Calculamos la dirección del movimiento en función de la rotación actual
                movement = transform.TransformDirection(movement);
                rb.velocity = movement * speed * Time.deltaTime;
            }

            // Calculamos la rotación basada en la entrada de teclado
            float rotationAmount = 0f;
            if (Input.GetKey(KeyCode.D))
            {
                rotationAmount = rotation * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                rotationAmount = -rotation * Time.deltaTime;
            }

            // Aplicamos la rotación si se está girando
            if (rotationAmount != 0f)
            {
                Quaternion deltaRotation = Quaternion.Euler(0f, rotationAmount, 0f);
                rb.MoveRotation(rb.rotation * deltaRotation);
            }
        }
        
    }

    private void animationMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {

            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
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
        //isAttacking = true;
        //animator.SetLayerWeight(footLayerIndex, 0f);
        animator.SetTrigger(triggerName);
        resetLayerWeightCoroutine = StartCoroutine(ResetLayerWeight());
    }

    private IEnumerator ResetLayerWeight()
    {
        yield return new WaitForEndOfFrame(); // Esperar al final del frame actual para asegurarse de que la animación se haya iniciado
        BladeLeft.SetActive(true);
        BladeRight.SetActive(true);
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(baseLayerIndex).length); // Esperar hasta que la animación actual termine
        //animator.SetLayerWeight(footLayerIndex, 1f);
        //isAttacking = false;
        resetLayerWeightCoroutine = null;
        BladeLeft.SetActive(false);
        BladeRight.SetActive(false);
    }

    public void DescactiveLayer()
    {
        animator.SetLayerWeight(footLayerIndex, 0f);
    }
    public void ActiveLayer()
    {
        animator.SetLayerWeight(footLayerIndex, 1f);
    }
}
