using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;

    [Header("Movement Settings")]
    [Range(0, 15)] public float startSpeed = 10f;
    [Range(0, 15)] public float vDrag = 3f;
    [SerializeField] private bool canMove = true;
    private float currentSpeedH;
    private float currentSpeedV;

    [Header("Movement animation settings")]
    public float maxBank = 30f;
    private float bankSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentSpeedH = startSpeed;
        currentSpeedV = startSpeed;
    }

    private void Update()
    {
        //Input detection
        float Hor = Input.GetAxis("Horizontal") * Time.deltaTime;
        float Ver = Input.GetAxis("Vertical") * Time.deltaTime;

        //This implements drag to the spaceship/player. 
        //The spaceship is flying fast, meaning its harder to go faster and you slow down easier.
        if (Ver > 0)
        {
            currentSpeedV = startSpeed - vDrag;
        }
        else if (Ver < 0)
        {
            currentSpeedV = startSpeed + vDrag;
        }
    
        if (canMove)
        {
            //Moves the spaceship according to the given input.
            rb.transform.position += new Vector3(Mathf.Sin(Hor * currentSpeedH), 0, Mathf.Sin(Ver * currentSpeedV));

            //Rotating/Banking movement.
            float tilt = 0;
            if (Hor < 0)           //Bank left.     
            {
                tilt = maxBank;
                bankSpeed = 75;
            }
            else if (Hor > 0)       //Bank right.
            {
                tilt = -maxBank;
                bankSpeed = 75;
            }
            else                    //Bank horizontal.
            {
                tilt = 0;
                bankSpeed = 100;
            }

            Quaternion targetPos = Quaternion.identity;
            targetPos.eulerAngles = new Vector3(tilt, 270, 0);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetPos, Mathf.Sin(Time.deltaTime * bankSpeed));
        }



        /*      Possible dash function (by Sten)
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            transform.position += new Vector3( Hor * speed * 50, 0, Ver * speed * 50);
        }
        */
    }

}
