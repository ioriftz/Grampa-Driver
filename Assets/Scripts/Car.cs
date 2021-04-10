using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public Rigidbody rb;
    public float forward, reverse, maxSpeed;

    private float speedInput, turnInput, turnForce = 180;

    public float gravityForce;
    public bool grounded;
    public LayerMask ground;
    public float groundRayLenght = .5f;
    public Transform groundedRayPoint;

    public float currentDrag;

    // Start is called before the first frame update
    void Start()
    {
        rb.transform.parent = null;
        currentDrag = rb.drag;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Vertical") > 0){
            speedInput = Input.GetAxis("Vertical") * forward * 1000f;
        } else if(Input.GetAxis("Vertical") < 0){
            speedInput = Input.GetAxis("Vertical") * reverse * 1000f;
        }

        turnInput = Input.GetAxis("Horizontal");

        if(grounded){
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, turnInput * turnForce * Time.deltaTime * Input.GetAxis("Vertical"), 0));
        }

        transform.position = rb.transform.position;
    }

    private void FixedUpdate() {
        grounded = false;
        RaycastHit hit;
        if(Physics.Raycast(groundedRayPoint.position, -transform.up, out hit, groundRayLenght, ground)){
            grounded = true;
        }

        if(grounded){
            rb.drag = currentDrag;
            if(Mathf.Abs(speedInput) > 0){
                rb.AddForce(transform.forward * speedInput);
            }
        } else {
            rb.drag = 0.1f;
            rb.AddForce(Vector3.up * -gravityForce * 100f);
        }
    }
}
