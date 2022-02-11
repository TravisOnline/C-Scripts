using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControls : MonoBehaviour
{
    public GameObject thePlayer;
    public bool isMoving;
    public float horizontalMove;
    public float verticalMove;
    public float moveSpeed;
    public float runSpeed;
    public bool isRunning;

    void Update()
    {
        if (Input.GetButton("Fire3"))
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
        if (Input.GetButton("Horizontal") || (Input.GetButton("Vertical")))
        {
            //movement values
            isMoving = true;
            if (isRunning == false)
            {
                horizontalMove = Input.GetAxis("Horizontal") * Time.deltaTime * 150;
                verticalMove = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
            }
            else
            {
                horizontalMove = Input.GetAxis("Horizontal") * Time.deltaTime * 150;
                if (Input.GetAxis("Vertical") >= 0)
                {
                    verticalMove = Input.GetAxis("Vertical") * Time.deltaTime * runSpeed;
                }
                else
                {
                    verticalMove = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
                }
            }
             thePlayer.transform.Rotate(0, horizontalMove, 0);
             thePlayer.transform.Translate(0, 0, verticalMove);

            //animations
             if (Input.GetAxis("Vertical") >= 0)
             {
                    if (isRunning == false && Input.GetAxis("Vertical") != 0) {
                        thePlayer.GetComponent<Animator>().Play("Armature|Walk");
                    }
                    else if (isRunning == true && Input.GetAxis("Vertical") != 0)
                    {
                    
                        thePlayer.GetComponent<Animator>().Play("Armature|Run");
                    }
                else
                {
                    thePlayer.GetComponent<Animator>().Play("Armature|Stand");
                }
             }
             else
             {
                    isRunning = false;
                    thePlayer.GetComponent<Animator>().Play("Armature|Walk Backwards");
             }
        }
        else
        {
                isMoving = false;
                thePlayer.GetComponent<Animator>().Play("Armature|Stand");
        }
 
    }
}
