using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody rb;
    public float speed = 20f;
    public GameManager gameManager;
    public ParticleSystem jet;

    private void FixedUpdate()
    {

        if(Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(transform.up * speed);
            jet.startLifetime = 0.75f;

        }
        else
        {
            jet.startLifetime = Mathf.Lerp(1.15f, 0.5f, 10);
        }

    }



    private void OnTriggerEnter(Collider other)
    {
        //End the game
        gameManager.EndGame();
    }

}
