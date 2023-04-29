using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    public Canvas canvas;
    public GameLogic Logic;
    public float height;
    public float width;
    public float speed = 2f;
    private Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<GameLogic>();
        height = canvas.GetComponent<RectTransform>().rect.height;
        width = canvas.GetComponent<RectTransform>().rect.width;
        body = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        speed = width / (Logic.levelTime * 60) ;
        body.transform.position = new Vector3(transform.position.x + speed, transform.position.y, 0);
    }
}
