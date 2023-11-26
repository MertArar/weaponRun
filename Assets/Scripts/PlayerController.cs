using System;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public bool isDead;
    public GameManager managerGame;
    public GameObject bulletPrefab; 
    public Transform firePoint; 
    public float bulletForce = 70f; 
    public float forwardSpeed = 1f;
    public float horizontalSpeed = 5f;
    public float maxXPosition = 4f;
    public float minXPosition = -4f;

    private void Start()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {
        Movement();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireBullet();
        }
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

        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
    }

    void FireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse); 
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag(tag = "GreenDoor"))
        {
            managerGame.UpdateScore();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("RedDoor"))
        {
            isDead = true;
            Time.timeScale = 0;
            
        }
    }
}