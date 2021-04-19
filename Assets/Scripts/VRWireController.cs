using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRWireController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject bulletPref;
    [SerializeField] Transform cameraTf;
    [SerializeField] GameObject Line2;

    public static bool IsShooting = false;
    public static Vector3 ColPos = default;

    void Start()
    {

    }

    void Update()
    {
        Line2.GetComponent<LineRenderer>().SetPosition(0, player.transform.position - player.transform.up * 0.5f);

        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            IsShooting = true;
            ShootBall();
        }

        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            IsShooting = false;
            Line2.GetComponent<LineRenderer>().enabled = false;
        }

        if (!IsShooting)
        {
            ColPos = player.transform.position;
        }

        if (Vector3.Distance(player.transform.position, ColPos) > Values.maxStringLength)
        {
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            ColPos = player.transform.position;
        }
    }

    void ShootBall()
    {
        Transform tf = player.transform;

        Line2.GetComponent<LineRenderer>().enabled = true;

        GameObject bullet = Instantiate(bulletPref) as GameObject;
        bullet.transform.position = tf.position + tf.forward * 2 + tf.up;
        Vector3 start = player.transform.position;
        Vector3 gole = Camera.main.transform.position + Camera.main.transform.forward * 10;
        bullet.GetComponent<Rigidbody>().AddForce((gole - start) * Values.powerToBall);

        Line2.GetComponent<LineRenderer>().enabled = true;
        Line2.GetComponent<LineRenderer>().SetPosition(0, tf.position);
    }
}
