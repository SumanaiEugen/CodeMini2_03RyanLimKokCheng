using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movecube : MonoBehaviour
{
    float forwardSpeed = 5f;
    float zlimit = 27.5f;
    float zlimit2 = 6f;
    bool hitwall = false;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.position.z < zlimit && hitwall == false)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * forwardSpeed);
        }
        if (transform.position.z > zlimit)
        {
            hitwall = true;
        }
        if (hitwall == true)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * -forwardSpeed);
        }
        if (transform.position.z < zlimit2)
        {
            hitwall = false;
        }

    }
    /*
    //parent for the player rmb to tick on trigger in collider
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            Player.transform.parent = transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
        {
            Player.transform.parent = null;
        }
    }
    */
    //collision
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == Player)
        {
            Player.transform.parent = transform;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == Player)
        {
            Player.transform.parent = null;
        }
    }
}
