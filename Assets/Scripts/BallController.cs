using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Vector2 speed;
    public Vector2 resetPosition;

    private Rigidbody2D rb;

    private int speedUpCounter;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = speed;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(speed * Time.deltaTime);
    }

    public void ResetBall(int ballDirection)
    {
        rb.velocity = speed * ballDirection;
        transform.position = new Vector2(resetPosition.x, resetPosition.y);

        speedUpCounter = 0;
    }

    public void ActivatePUSpeedUp(float magnitude)
    {
        if (speedUpCounter < 3)
        {
            rb.velocity *= magnitude;
            speedUpCounter++;
        }
    }
}
