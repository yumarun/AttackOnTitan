using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRBulletController : MonoBehaviour
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
        if (collision.gameObject.tag != "Player")
        {
            VRAddPowerToPlayer.AddPower();
            VRWireController.PlayerSpringJoint.anchor = collision.contacts[0].point;
            VRWireController.PlayerSpringJoint.spring = Values.springPower;
            Destroy(gameObject);
        }
    }
}
