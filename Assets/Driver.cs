using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{

    [SerializeField] float steerSpeed = 150f;
    [SerializeField] float ySpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = (Input.GetAxis("Horizontal") * steerSpeed) * Time.deltaTime;
        float speed = (Input.GetAxis("Vertical") * ySpeed) * Time.deltaTime;
        transform.Rotate(0,0,-steerAmount);
        transform.Translate(0f,speed,0f);
    }

}
