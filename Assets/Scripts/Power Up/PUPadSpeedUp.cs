using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUPadSpeedUp : MonoBehaviour
{
    public Collider2D ball; 
    public GameObject paddleLeft;
    public GameObject paddleRight;
    public int speedUp;
    public PowerUpManager manager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {
            if (ball.GetComponent<Rigidbody2D>().velocity.x > 0)
            {
                paddleLeft.GetComponent<PaddleController>().ActivatePUPaddleSpeedUp(speedUp);
                manager.RemovePowerUp(gameObject);
            }
            else
            {
                paddleRight.GetComponent<PaddleController>().ActivatePUPaddleSpeedUp(speedUp);
                manager.RemovePowerUp(gameObject);
            }
        }
    }
}
