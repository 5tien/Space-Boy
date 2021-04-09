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
    public float maxBankHor = 27f;
    public float maxBankVer = 15f;
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


    
        if (canMove)
        {
            //Moves the spaceship according to the given input.
            rb.transform.position += new Vector3(Mathf.Sin(Hor * currentSpeedH), 0, Mathf.Sin(Ver * currentSpeedV));

            //Rotating/Banking movement.
            float tiltHor = 0;
            float tiltVer = 0;

            //This implements drag to the spaceship/player. 
            //The spaceship is flying fast, meaning its harder to go faster and you slow down easier.
            if (Ver < 0)
            {
                tiltVer = maxBankVer;
                currentSpeedV = startSpeed + vDrag;
            }
            else if (Ver > 0)
            {
                tiltVer = -maxBankVer;
                currentSpeedV = startSpeed - vDrag;
            }
            else
            {
                tiltVer = 0;
            }

            if (Hor < 0)           //Bank left.     
            {
                tiltHor = maxBankHor;
                bankSpeed = 75;
            }
            else if (Hor > 0)       //Bank right.
            {
                tiltHor = -maxBankHor;
                bankSpeed = 75;
            }
            else                    //Bank horizontal.
            {
                tiltHor = 0;
                bankSpeed = 85;
            }

            Quaternion targetPos = Quaternion.identity;
            targetPos.eulerAngles = new Vector3(tiltHor, 270, tiltVer);
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
