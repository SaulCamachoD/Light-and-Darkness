using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody rb;
    public Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!Input.GetKey(KeyCode.W))
        {
            animator.SetFloat("fwd", 0.0f);
        }
        else
        {
            animator.SetFloat("fwd", 1.0f);
        }
    }


    private void FixedUpdate()
    {
        float movsX = Input.GetAxis("Horizontal");
        float movsY = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(movsX, 0f, movsY).normalized;
        if (movement != Vector3.zero)
        {
            rb.AddForce(movement * speed * 1000f * Time.deltaTime);
        }
    }
}
