using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {
    Rigidbody rigidBody;
    AudioSource audioSource;
    [SerializeField]float thrustForce;
    [SerializeField]float rotationSpeed;

	// Use this for initialization
	void Start () 
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        Thrust();
        Rotate();
		
	}


    private void Thrust()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddRelativeForce(Vector3.up * thrustForce);

            if (!audioSource.isPlaying) // so it doesn't layer
            {
                audioSource.Play();
            }

        }
        else
        {
            audioSource.Stop();
        }
    }

    private void Rotate()
    {
        rigidBody.freezeRotation = true; //take manual control of rotation

        float rotationThisFrame = rotationSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationThisFrame);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.back * rotationThisFrame);
        }

        rigidBody.freezeRotation = false; // resume physics control 
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                print ("Ok");
                break;
            case "Unfriendly":
                print("Dead");
                break;
            default:
                print("Probably Dead");
                break;
        }
    }
}
 