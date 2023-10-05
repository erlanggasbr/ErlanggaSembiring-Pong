using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public int speed;
    private Rigidbody2D rb;

    public KeyCode upKey;
    public KeyCode downKey;

    private Vector3 paddleLength;
    private float timer;
    [SerializeField] private float duration;
    public PUPadLengthUp powerUpLength;

    private int normalSpeed;
    public PUPadSpeedUp powerUpSpeed;

    //private string paddleSide;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //PaddleSide();
        paddleLength = transform.localScale;
        normalSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        //move object
        MoveObject(GetInput());
        PaddleLengthPowerUpDuration();
        PaddleSpeedPowerUpDuration();
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
        //Debug.Log("Kecepatan paddle "+paddleSide+" = "+ movement);
        rb.velocity = movement;
    }

    /*private void PaddleSide()
    {
        switch (upKey)
        {
            case KeyCode.W:
                paddleSide = "kiri";
                break;
            case KeyCode.UpArrow:
                paddleSide = "kanan";
                break;
            default:
                paddleSide = "";
                break;
        }
    }*/

    public void ActivatePUPaddleLengthUp(Vector3 paddleIncrement)
    {
        transform.localScale += paddleIncrement;
    }

    private void PaddleLengthPowerUpDuration()
    {
        if (paddleLength.y < transform.localScale.y)
        {
            timer += Time.deltaTime;
            if (timer >= duration)
            {
                transform.localScale -= powerUpLength.paddleIncrement;
                timer -= duration;
            }
        }
    }

    public void ActivatePUPaddleSpeedUp(int speedUp)
    {
        speed *= speedUp;
    }

    private void PaddleSpeedPowerUpDuration()
    {
        if (normalSpeed < speed)
        {
            timer += Time.deltaTime;
            if (timer >= duration)
            {
                speed /= powerUpSpeed.speedUp;
                timer -= duration;
            }
        }
    }
}
