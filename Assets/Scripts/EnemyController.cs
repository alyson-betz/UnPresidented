using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    
    private GameObject president;
    private GameLogic Logic;
    public float speed;
    private Vector2 target;
    private Vector2 position;
    private Camera cam;

    void Start()
    {
        target = new Vector2(0.0f, 0.0f);
        position = gameObject.transform.position;
        president = GameObject.FindGameObjectWithTag("President");
        cam = Camera.main;
        Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<GameLogic>();
        
    }

    void FixedUpdate()
    {

        float step = speed * Time.deltaTime;
        target = president.transform.position;
        // move sprite towards the target location
        transform.position = Vector2.MoveTowards(transform.position, target, step);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "President")
        {
            Debug.Log("I have hit the president");
            Destroy(gameObject);
            //Logic.gameOver();
        }
        if (collision.gameObject.tag == "Bullet")
        {
            HitByBullet();
        }
    }

    private void HitByBullet()
    {
        Debug.Log("I have been hit by a bullet");
        Destroy(gameObject);
        Logic.addScore(1);
    }
}
