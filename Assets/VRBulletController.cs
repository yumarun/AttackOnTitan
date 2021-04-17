using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRBulletController : MonoBehaviour
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
        if (collision.gameObject.tag != "Player")
        {
            VRAddPowerToPlayer.AddPower();
            Destroy(gameObject);
        }
    }
}
