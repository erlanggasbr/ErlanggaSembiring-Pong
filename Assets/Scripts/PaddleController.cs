using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public int speed;
    private Rigidbody2D rb;

    public KeyCode upKey;
    public KeyCode downKey;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //move object
        MoveObject(GetInput());
    }

    private Vector2 GetInput()
    {
        if (Input.GetKey(upKey)) //up
        {
            return Vector2.up * speed;
        }
        else if (Input.GetKey(downKey)) //down
        {
            return Vector2.down * speed;
        }
        
        return Vector2.zero;
    }

    private void MoveObject(Vector2 movement)
    {
        rb.velocity = movement;
    }
}