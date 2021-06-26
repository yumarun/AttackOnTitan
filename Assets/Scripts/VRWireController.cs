using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRWireController : MonoBehaviour, IInputUser
{
    [SerializeField] GameObject player = null;
    [SerializeField] GameObject bulletPref = null;
    [SerializeField] Transform cameraTf = null;
    [SerializeField] GameObject Line2 = null;
    [SerializeField] GameObject bullet_right;

    public IPlayerInput MyInput { get; set; }
    public static Vector3 ColPos = default;

    

    void Start()
    {

    }

    void Update()
    {
        Line2.GetComponent<LineRenderer>().SetPosition(0, player.transform.position - player.transform.up * 0.5f);
        Line2.GetComponent<LineRenderer>().SetPosition(1, bullet_right.transform.position);

        if (MyInput.LaunchWire())
        {
            if (Bullet.bulletCond != Bullet.BulletCond.StayingOther)
            {
                Bullet.bulletCond = Bullet.BulletCond.Going;
            }
            else
            {
                Bullet.bulletCond = Bullet.BulletCond.Returning;
            }
        }

        if (MyInput.WindUpWire())
        {
            Bullet.bulletCond = Bullet.BulletCond.Returning;
            ColPos = player.transform.position;
        }


        // どこに書くのがいいんだろう?
        if (Input.GetKeyDown(KeyCode.Q) && (Bullet.bulletCond == Bullet.BulletCond.StayingOther))
        {
            VRAddPowerToPlayer.AddPower();
        }

        //Line2のonとoff
        if (Bullet.bulletCond != Bullet.BulletCond.StayingPlayer)
        {
            Line2.GetComponent<LineRenderer>().enabled = true;
        }
        else
        {
            Line2.GetComponent<LineRenderer>().enabled = false;
        }

        if (Vector3.Distance(player.transform.position, ColPos) > Values.maxStringLength)
        {
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            ColPos = player.transform.position;
        }
    }

    /*
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
    */
    
    //2021/06/27追加
    void ShootBullet(Vector3 gole)
    {
        bullet_right.GetComponent<Bullet>().moveTowards(gole);
    }
}
