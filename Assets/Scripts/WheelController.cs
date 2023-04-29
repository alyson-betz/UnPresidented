

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    private GameLogic Logic;
    private Rigidbody2D rb; // rigidbody component of unicycle
    public float speed = .50f; // speed of unicycle movement
    public float rotationSpeed = 100f; // Speed of rotation in degrees per second

    // Start is called before the first frame update
    void Start()
    {
        Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<GameLogic>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        transform.Rotate(0f, 0f, -rotation);
        rb.AddForce(movement * speed);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Trigger1")
        {
            Debug.Log("I hit trigger 1");
        }
    }

    
}