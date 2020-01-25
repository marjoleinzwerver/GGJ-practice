using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    private Rigidbody2D catRigidbody;
    private Vector2 catVelocity;
    public float maxWalkSpeed = 5.0f;
    public float jumpSpeed = 5.0f;
    private bool isMoving = false;
    private bool isGrounded = true;
    private Animator catAnimator;

    // Start is called before the first frame update
    void Start()
    {
        catRigidbody = GetComponent<Rigidbody2D>();
        catVelocity = Vector2.zero;
        catAnimator = GetComponent<Animator>();
         print("start");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        catVelocity.x = Input.GetAxis("Horizontal") * maxWalkSpeed;
        if (Input.GetButton("Fire1") && isGrounded)
        {
            catVelocity.y = jumpSpeed;
        }
        else
        {
            catVelocity.y = catRigidbody.velocity.y;
        }
        if (catVelocity != Vector2.zero)
        {
            catAnimator.SetBool("is_moving", true);
        }
        else
        {
            catAnimator.SetBool("is_moving", false);
        }
        catRigidbody.velocity = catVelocity;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        print("collision");
        if (col.gameObject.CompareTag("Solid"))
        {
            isGrounded = true;
            print("grounded");
        }
    }

    void OnCollisionExit2D(Collision2D col) {
        if (col.gameObject.CompareTag("Solid"))
        {
            isGrounded = false;
            print("ungrounded");
        }
    }
}