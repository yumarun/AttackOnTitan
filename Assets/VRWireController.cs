using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRWireController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject bulletPref;
    [SerializeField] Transform cameraTf;
    [SerializeField] GameObject Line2;

    public static SpringJoint PlayerSpringJoint;

    void Start()
    {
        PlayerSpringJoint = player.GetComponent<SpringJoint>();
    }

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            ShootBall();
        }

        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            Line2.GetComponent<LineRenderer>().enabled = false;
            PlayerSpringJoint.spring = 0;
        }

        Line2.GetComponent<LineRenderer>().SetPosition(0, player.transform.position - player.transform.up * 0.5f);

        Debug.Log(player.transform.forward);
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

        Line2.GetComponent<LineRenderer>().enabled = true;
        Line2.GetComponent<LineRenderer>().SetPosition(0, tf.position);
        Line2.GetComponent<LineRenderer>().SetPosition(1, bullet.transform.position);
    }
}
