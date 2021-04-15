using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject line1;
    [SerializeField] GameObject bulletPref;
    [SerializeField] Transform cameraTf;
    public GameObject line2;


    public static float springPower = 10f;
    public static Vector3 bulletColPos = default;
    public static bool isShooting = false;

    SpringJoint sj;

    void Start()
    {
        sj = player.GetComponent<SpringJoint>();
    }

    void Update()
    {

        if (springPower == Values.springPower)
        {
            line1.GetComponent<LineRenderer>().enabled = true;
        }

        if (Input.GetMouseButtonDown(0))
        {
            ShootBall();
        }

        if (Input.GetMouseButtonDown(1))
        {
            ResetWire();
        }

        if (Vector3.Distance(player.transform.position, sj.connectedAnchor) <= 10.0f)
        {
            ResetWire();
            
        }

        line1.GetComponent<LineRenderer>().SetPosition(0, player.transform.position);
        line1.GetComponent<LineRenderer>().SetPosition(1, bulletColPos);
        line2.GetComponent<LineRenderer>().SetPosition(0, player.transform.position);

        sj.connectedAnchor = bulletColPos;

        SetWire();
        if (isShooting)
        {
            line1.GetComponent<LineRenderer>().enabled = true;
        }
        else
        {
            line1.GetComponent<LineRenderer>().enabled = false;
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
        line2.GetComponent<LineRenderer>().enabled = true;
        bullet.GetComponent<Rigidbody>().AddForce(power * Values.powerToBall + absPsp);
    }

    void SetWire()
    {
        sj.spring = springPower;
    }

    void ResetWire()
    {
        springPower = 0f;
        isShooting = false;
    }

}
