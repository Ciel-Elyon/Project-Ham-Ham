using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPadScript : MonoBehaviour
{
    public Rigidbody playerRb;
    public float jumpforce;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerHam"))
        {
            playerRb.AddForce(Vector3.up * jumpforce);
        }
    }
}
