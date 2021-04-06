using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject car;
    public float speed;
    public float rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            car.gameObject.transform.Translate(car.transform.forward * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            car.gameObject.transform.Translate(car.transform.forward * -speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            car.gameObject.transform.Rotate(car.transform.forward * -speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            car.gameObject.transform.Rotate(car * speed);
        }
    }
}
