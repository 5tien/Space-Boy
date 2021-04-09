using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    private Renderer renderer;

    void OnCollisionEnter(Collision collision)
    {
        if ((collision.transform.CompareTag("Enemy") && transform.tag == "PlayerBullet") || (collision.transform.CompareTag("Player") && transform.tag == "EnemyBullet"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else
        {
            Physics.IgnoreCollision(GetComponent<Collider>(), collision.transform.GetComponent<Collider>());
        }
    }

    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        if (renderer.isVisible == false)
        {
            Destroy(gameObject);
        }
    }
}
