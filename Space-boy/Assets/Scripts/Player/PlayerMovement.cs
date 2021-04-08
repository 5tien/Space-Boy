using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [Range(0, 15)] public float startSpeed = 10f;
    [Range(0, 15)] public float vDrag = 3f;
    public float bank = 50f;

    [SerializeField] private bool canMove = true;
    private float currentSpeedH;
    private float currentSpeedV;
    private Rigidbody rb;

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
    
        //If the user can move, it will move according to the current input given.
        if (canMove)
        {
            rb.transform.position += new Vector3(Mathf.Sin(Hor * currentSpeedH), 0, Mathf.Sin(Ver * currentSpeedV));
            if (Hor != 0)
            {
                rb.transform.eulerAngles = new Vector3(rb.transform.eulerAngles.x, rb.transform.eulerAngles.y + 50, rb.transform.eulerAngles.z);
                //rb.transform.Rotate(0, 0, Mathf.Sin(-Hor * bank));
            }            
            
        }



        /*      Possible dash function (by Sten)
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            transform.position += new Vector3( Hor * speed * 50, 0, Ver * speed * 50);
        }
        */
    }

}
