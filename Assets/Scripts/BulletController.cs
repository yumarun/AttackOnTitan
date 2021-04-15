using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    void Update()
    {
        GameObject.Find("Line2").GetComponent<LineRenderer>().SetPosition(1, transform.position);
        if (transform.position.y <= -10)
        {
            Destroy(gameObject);
        }    
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag != "Player")
        {
            GameObject.Find("Line2").GetComponent<LineRenderer>().enabled = false;
            AddPowerToPlayer.AddPower();
            WireController.isShooting = true;
            WireController.bulletColPos = transform.position;
            WireController.springPower = Values.springPower;
            Destroy(gameObject);
        }    
    }
}
