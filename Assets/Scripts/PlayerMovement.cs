﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public enum Color { Red, Blue, Yellow, Purple }

    public bool Red;
    public bool Blue;
    public bool Yellow;
    public bool Purple;

    public float score;

    public float moveSpeed;

    public float rotationRate = 90;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHor = Input.GetAxis("Horizontal");
        float moveVer = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * moveVer * moveSpeed);
        transform.Translate(Vector3.right * moveHor * moveSpeed);

        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, rotationRate * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, -rotationRate * Time.deltaTime, 0);
        }
    }
}
