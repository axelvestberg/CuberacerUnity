using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;

    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;

    public void moveLeftPC()
    {
        rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }

    public void moveRightPC()
    {
        rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }

    public void moveLeftMobile()
    {
        rb.AddForce((-sidewaysForce / 2) * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }

    public void moveRightMobile()
    {
        rb.AddForce((sidewaysForce / 2) * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }
    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKey("a"))
        {
            moveLeftPC();
        }
        if (Input.GetKey("d"))
        {
            moveRightPC();
        }

        foreach (Touch touch in Input.touches)
        {
            if (touch.position.x < Screen.width / 2)
            {

                moveLeftMobile();
            }
            else if (touch.position.x > Screen.width / 2)
            {
                moveRightMobile();
            }
        }

        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
