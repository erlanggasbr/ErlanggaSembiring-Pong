using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUPadLengthUp : MonoBehaviour
{
    public Collider2D ball;
    public GameObject paddleLeft;
    public GameObject paddleRight;
    public Vector3 paddleIncrement;
    public PowerUpManager manager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {
            if (ball.GetComponent <Rigidbody2D>().velocity.x > 0)
            {
                paddleLeft.GetComponent<PaddleController>().ActivatePUPaddleLengthUp(paddleIncrement);
                manager.RemovePowerUp(gameObject);
            }
            else
            {
                paddleRight.GetComponent<PaddleController>().ActivatePUPaddleLengthUp(paddleIncrement);
                manager.RemovePowerUp(gameObject);
            }
        }
    }
}
