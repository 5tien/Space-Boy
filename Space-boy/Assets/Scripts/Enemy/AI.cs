using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    [SerializeField] private float shootTime = 3;

    [Header("Bullet")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletSpeed = 10;


    [Header("Path")]
    [SerializeField] private bool loop = true;
    [SerializeField] private GameObject path;
    [SerializeField] private float lerpAmount = 100;
    [SerializeField] private int currentPathPosition = 0;
    [SerializeField] private int childrenAmount;
    [SerializeField] private Vector3 pos1;
    [SerializeField] private Transform pos2;

    void Start()
    {
        if (path != null)
        {
            childrenAmount = path.transform.childCount;
        }
    }

    void setPath(int pathNumber)
    {
        pos1 = transform.position;
        pos2 = path.transform.GetChild(pathNumber);
    }

    void followPath()
    {
        if (childrenAmount > currentPathPosition - 1)
        {
            if (lerpAmount / 100 >= 1 && childrenAmount > currentPathPosition)
            {
                lerpAmount = 0;

                setPath(currentPathPosition);
                currentPathPosition += 1;
            }
            else if (currentPathPosition == childrenAmount)
            {
                if (loop == true)
                {
                    lerpAmount = 0;
                    currentPathPosition = 0;
                }
            }

            lerpAmount += 1;

            transform.position = Vector3.Lerp(pos1, pos2.position, lerpAmount / 100);
        }
    }

    void Update()
    {
        if (path != null)
        {
            followPath();
        }

        if (shootTime > 0)
        {
            shootTime -= Time.deltaTime;
        }
        else
        {
            shootTime = Random.Range(0, 4);

            GameObject newBullet = Instantiate(bullet, transform.position + new Vector3(0, 0, -1), Quaternion.identity);

            newBullet.tag = "EnemyBullet";
            newBullet.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -(bulletSpeed - bulletSpeed / 5));
        }

        transform.position += new Vector3(0, 0, -Time.deltaTime);
    }
}
