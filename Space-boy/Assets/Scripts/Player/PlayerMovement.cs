using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [Range(0, 15)] public float startSpeed = 10f;
    [Range(0, 15)] public float vDrag = 5f;

    [SerializeField] private bool canMove = true;
    private float currentSpeedH;
    private float currentSpeedV;

    private void Start()
    {
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
            transform.position += new Vector3(Mathf.Sin(Hor * currentSpeedH), 0, Mathf.Sin(Ver * currentSpeedV));
        }



        /*      Possible dash function (by Sten)
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            transform.position += new Vector3( Hor * speed * 50, 0, Ver * speed * 50);
        }
        */
    }

}
