using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HamsterMovement : MonoBehaviour
{
    enum PlayerState
    {
        aLive,
        Dead
    };

    public AudioSource legobricksound;
    public AudioSource SprintWhoosh;

    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    Collider[] withinRange;
    bool isTouchingGround;

    private float speed;


    public float jumpSpeed = 20;


    public float acceleration;

    public float deacceleration;
    private float timer;


    public float MAX_SPRINT_TIME;
    public float MAX_SPEED_CAP;
    public float NORMAL_SPEED ;
    private bool inSprint = false;
    private bool inTransit = false;

    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        speed = NORMAL_SPEED;
    }

    // Update is called once per frame
   void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        float Jump = Input.GetAxis("Jump");

               
        Vector3 movement = new Vector3(moveHorizontal, 0.0f , moveVertical);
       
        rb.AddForce(movement * speed);


        if (Input.GetKeyDown(KeyCode.Space) && isTouchingGround) //Jump
        {
            rb.AddForce(Vector3.up * jumpSpeed);
        }

       if (rb.velocity.magnitude < .05)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }



    }

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * Time.deltaTime;
        float moveVertical = Input.GetAxis("Vertical") * Time.deltaTime;
        float Jump = Input.GetAxis("Jump") * Time.deltaTime;


        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            SprintWhoosh.Play();
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (timer < MAX_SPRINT_TIME)
            {
                speed = NORMAL_SPEED + acceleration;
                timer += Time.deltaTime;
            }

            else
            {
                rb.velocity = Vector3.zero;
            }


        }

        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            rb.velocity = Vector3.zero;
            timer = 0.0f;
        }
        else
        {
            speed = NORMAL_SPEED;
        }

        withinRange= Physics.OverlapSphere(groundCheckPoint.position, groundCheckRadius);
        
        for(int i = 0; i < withinRange.Length; i++)
        {
            if (withinRange[i].gameObject.CompareTag("Ground"))
            {
                isTouchingGround = true;
                return;
            }
            isTouchingGround = false;
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("toyblock"))
        {
            legobricksound.Play();
        }

        else if (collision.gameObject.CompareTag("Collectables"))
        {
            //TODO:
            //prompt the plaher to pick up the object and put it in its inventory

            //if the player choses to pick up the object
            // put it in the inventory first
            collision.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Edible"))
        {
            //player consumes the object automatically
            other.gameObject.SetActive(false);
        }
    }

}
