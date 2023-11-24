using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    public float forwardSpeed = 1f;
    public float horizontalSpeed = 5f;
    public float maxXPosition = 4f;
    public float minXPosition = -4f;

    private void Update()
    {
        Movement();
    }

    public void Movement()
    {
        Vector2 inputVector = new Vector2(0, 0);
        inputVector.y = 1;

        if (Input.GetKey(KeyCode.A))
        {
            inputVector.x = -1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            inputVector.x = 1;
        }

        inputVector = inputVector.normalized;

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        Vector3 newPosition = transform.position + (moveDir * Time.deltaTime * horizontalSpeed);

        newPosition.x = Mathf.Clamp(newPosition.x, minXPosition, maxXPosition);
        transform.position = newPosition;

        // İleri doğru hareket
        //transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
    }
}