using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float speed = 10f;
    float gravityModifier = 3f;
    bool isgrounded;
    Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        float VerticalInput = Input.GetAxis("Vertical");
        //float HorizontalInput = Input.GetAxis("Horziontal");

        //movement of player
        transform.Translate(Vector3.forward * Time.deltaTime * VerticalInput * speed);
        //transform.Translate(Vector3.right * Time.deltaTime * HorizontalInput * speed);
        
        Jumpplayer();
    }
    void Jumpplayer()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isgrounded == true)
        {
            playerRb.AddForce(Vector3.up * 10, ForceMode.Impulse);
            isgrounded = false;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("StartCube"))
        {
            isgrounded = true;
        }
        if (collision.gameObject.CompareTag("MoveCube"))
        {
            isgrounded = true;
        }
    }

}
