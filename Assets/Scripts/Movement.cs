using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float thrustForce = 1000f;
    [SerializeField] float rotationSpeed = 100f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        processThrust();
        processRotation();
    }

    private void processThrust(){
        if(Input.GetKey(KeyCode.Space)){
            rb.AddRelativeForce(Vector3.up * thrustForce * Time.deltaTime);
        } 
    }

    private void processRotation(){

        if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)){
            Debug.Log("Pressed Both Rotations, Doing Nothing");
        } else if(Input.GetKey(KeyCode.A)){
            applyRotation(rotationSpeed);           
        } else if(Input.GetKey(KeyCode.D)){
            applyRotation(-rotationSpeed);
        }
    }

    private void applyRotation(float rotationSpeed){
        rb.freezeRotation = true; //Freezing rotation for manual control
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
