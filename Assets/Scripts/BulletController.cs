using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    void Update()
    {
        if (transform.position.y <= -10)
        {
            Destroy(gameObject);
        }    
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag != "Player")
        {
            WireController.isShooting = true;
            WireController.bulletColPos = transform.position;
            WireController.springPower = Values.springPower;
            Destroy(gameObject);
        }    
    }
}
