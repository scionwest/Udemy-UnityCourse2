using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] float thrustAmount = 1200.0f;
    [SerializeField] float rotationSpeed = 200.0f;

    private Rigidbody rigidBody;
    private AudioSource audioSource;
     
    // Start is called before the first frame update
    void Start()
    {
        this.rigidBody = this.GetComponent<Rigidbody>();
        this.audioSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ThrustShip();
        RotateShip();
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Friendly":
                print("Ok");
                break;
            case "Fuel":
                print("Fuel");
                break;
            default:
                print("dead");
                break;
        }
    }

    private void ThrustShip()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddRelativeForce(Vector3.up * this.thrustAmount * Time.deltaTime);

            if (!this.audioSource.isPlaying)
            {
                this.audioSource.Play();
            }
        }
        else
        {
            this.audioSource.Stop();
        }
    }

    private void RotateShip()
    {
        this.rigidBody.freezeRotation = true;
        var rotationAmountForFrame = this.rotationSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationAmountForFrame);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * rotationAmountForFrame);
        }

        this.rigidBody.freezeRotation = false; // Enable/Disable the physics based rotation applied by Rigid Body.
    }
}