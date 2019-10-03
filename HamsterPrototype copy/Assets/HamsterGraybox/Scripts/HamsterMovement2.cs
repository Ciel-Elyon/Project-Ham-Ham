using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamsterMovement2 : MonoBehaviour
{
    
    private float speed;

    public float jumpSpeed = 20;

    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask goundLayer;


    private float ySpeed = -10;


    bool falling;

    public float acceleration;

    private float timer;


    public float MAX_SPRINT_TIME;
    public float NORMAL_SPEED = 10;
    private bool inSprint = false;
    private bool inJump = false;
    private bool inair = false;

    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        speed = NORMAL_SPEED;
    }


    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * Time.deltaTime;
        float moveVertical = Input.GetAxis("Vertical") * Time.deltaTime;
        float Jump = Input.GetAxis("Jump") * Time.deltaTime;

        


        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            inSprint = false;
            speed = NORMAL_SPEED;
            timer = 0.0f;
        }


        else if (Input.GetKey(KeyCode.LeftShift))
        {
            if (timer < MAX_SPRINT_TIME)
            {
                inSprint = true;
                speed += acceleration * Time.deltaTime;
                //speed = 4 * NORMAL_SPEED;
                timer += Time.deltaTime;
            }
            else
            {
                speed = NORMAL_SPEED;
            }

        }

        var direction = new Vector3(moveHorizontal, 0, moveVertical);
      
        transform.Translate(direction * speed);
        
           
    }

    private void FixedUpdate()
    {

         if (Input.GetKeyDown(KeyCode.Space))
        {
            if(transform.position.y < 0.8 && !inSprint)
                rb.AddForce(Vector3.up * jumpSpeed);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        
    }
}
