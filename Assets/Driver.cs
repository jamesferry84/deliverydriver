using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{

    [SerializeField] float steerSpeed = 300f;
    [SerializeField] float ySpeed = 10f;
    [SerializeField] float slowSpeed = 1f;
    [SerializeField] float boostSpeed = 15f; 
    [SerializeField] float boostTimer = 2f;
    bool boostActivated = false;


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

        if (boostActivated) {
            boostTimer -= Time.deltaTime;
            Debug.Log(boostTimer);
            if (boostTimer <= 0.0f) {
                boostActivated = false;
                ySpeed = 10f;
                boostTimer = 2f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag.Equals("Boost") && !boostActivated) {
            ySpeed = boostSpeed;
            boostActivated = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        ySpeed = slowSpeed;
    }

    private void OnCollisionExit2D(Collision2D other) {
        ySpeed = 10f;
    }



}
