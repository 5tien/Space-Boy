using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : PlayerController
{
    protected override void Update()
    {
        base.Update();

        //Gun switcher.
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (CurrentGun < 2)     //This is the amount of guns it will switch between.
            {
                CurrentGun = CurrentGun + 1;
            }
            else
            {
                CurrentGun = 1;
            }
        }

        switch (CurrentGun)
        {
            case 1:
                MachineShot();      //Just a simple gun, shoot a lot of bullets in a short amount of time.
                break;
            case 2:
                SingleShot();       //A gun which will shoot 1 bullet at a time on cooldown. Hold longer for a bigger blast which does more damage.
                break;
        }
    }

    void SingleShot()
    {
        if (delayTimer >= shootDelaySingle)
        {
            if (Input.GetKey(KeyCode.Mouse0) || Input.GetKey(KeyCode.Space))
            {
                if (Charge < 1)
                {
                    Charge += Time.deltaTime;
                }
                else
                {
                    Charge = 1;
                }
            }
            else if (Input.GetKeyUp(KeyCode.Mouse0) || Input.GetKeyUp(KeyCode.Space))
            {
                GameObject newBullet = Instantiate(bullet, transform.position + new Vector3(0, 0, 2), Quaternion.identity);

                if (Charge >= 0)
                {
                    newBullet.transform.localScale = new Vector3(singleBNSize + Charge, singleBNSize + Charge, singleBNSize + Charge);
                    newBullet.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, singleBNSpeed - Charge * chargeDrag);
                }

                Charge = 0;
                delayTimer = 0;
            }
        }
        else if(delayTimer < shootDelaySingle)
        {
            delayTimer = delayTimer + 1 * Time.deltaTime;
        }
    }

    void MachineShot()
    {
        if (delayTimer >= shootDelayMachine)
        {

            if (Input.GetKey(KeyCode.Mouse0) || Input.GetKey(KeyCode.Space))
            {
                GameObject newBullet = Instantiate(bullet, transform.position + new Vector3(-0.5f, 0, 1.5f), Quaternion.identity);
                GameObject newBullet2 = Instantiate(bullet, transform.position + new Vector3(0.5f, 0, 1.5f), Quaternion.identity);

                if (Charge >= 0)
                {
                    newBullet.transform.localScale = new Vector3(singleBNSize + Charge, singleBNSize, singleBNSize);
                    newBullet.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, singleBNSpeed);
                    newBullet2.transform.localScale = new Vector3(singleBNSize + Charge, singleBNSize, singleBNSize);
                    newBullet2.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, singleBNSpeed);
                }
                delayTimer = 0;
            }
        }
        else if (delayTimer < shootDelayMachine)
        {
            delayTimer = delayTimer + 1 * Time.deltaTime;
        }
    }
}
