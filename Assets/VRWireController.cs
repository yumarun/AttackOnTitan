using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRWireController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject bulletPref;
    [SerializeField] Transform cameraTf;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootBall();
        }
    }

    void ShootBall()
    {
        Transform tf = player.transform;
        GameObject bullet = Instantiate(bulletPref) as GameObject;
        bullet.transform.position = tf.position + tf.forward * 2 + tf.up;
        Vector3 power = tf.forward - tf.up * cameraTf.localRotation.x * 2f;
        Vector3 psp = player.GetComponent<Rigidbody>().velocity;
        Vector3 absPsp = new Vector3(Mathf.Abs(psp.x), 0f, Mathf.Abs(psp.z));
        bullet.GetComponent<Rigidbody>().AddForce(power * Values.powerToBall);
    }
}
