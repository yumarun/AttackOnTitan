using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRWireController : MonoBehaviour, IInputUser
{
    [SerializeField] GameObject player = null;
    [SerializeField] GameObject bulletPref = null;
    [SerializeField] Transform cameraTf = null;
    [SerializeField] GameObject Line2 = null;
    [SerializeField] GameObject Line2_left = null;
    [SerializeField] Bullet bullet_right;
    [SerializeField] Bullet bullet_left;

    public IPlayerInput MyInput { get; set; }
    public static Vector3 ColPos = default;

    [SerializeField] bool autoWindUp = false;

    void Start()
    {

    }

    void Update()
    {
        Line2.GetComponent<LineRenderer>().SetPosition(0, player.transform.position - player.transform.up * 0.5f);
        Line2.GetComponent<LineRenderer>().SetPosition(1, bullet_right.gameObject.transform.position);

        Line2_left.GetComponent<LineRenderer>().SetPosition(0, player.transform.position - player.transform.up * 0.5f);
        Line2_left.GetComponent<LineRenderer>().SetPosition(1, bullet_left.gameObject.transform.position);

        if (MyInput.LaunchWire())
        {
            if (bullet_right.bulletCond != Bullet.BulletCond.StayingOther)
            {
                bullet_right.SetGole((Camera.main.transform.forward * 2 + Camera.main.transform.right).normalized * 100);
                bullet_right.bulletCond = Bullet.BulletCond.Going;
            }
            else
            {
                bullet_right.bulletCond = Bullet.BulletCond.Returning;
            }
        }

        if (MyInput.LaunchWireLeft())
        {
            if (bullet_left.bulletCond != Bullet.BulletCond.StayingOther)
            {
                bullet_left.SetGole((Camera.main.transform.forward * 2 + (-1) * Camera.main.transform.right).normalized * 100);
                bullet_left.bulletCond = Bullet.BulletCond.Going;
            }
            else
            {
                bullet_left.bulletCond = Bullet.BulletCond.Returning;
            }
        }

        if (MyInput.WindUpWire())
        {
            bullet_right.bulletCond = Bullet.BulletCond.Returning;
            ColPos = player.transform.position;
        }

        if (MyInput.WindUpWireLeft())
        {
            bullet_left.bulletCond = Bullet.BulletCond.Returning;
            ColPos = player.transform.position;
        }


        //autoWindUpがtrueの時は自動で巻き取るように
        if (autoWindUp && (bullet_right.bulletCond == Bullet.BulletCond.StayingOther))
        {
            VRAddPowerToPlayer.AddPower();
            bullet_right.bulletCond = Bullet.BulletCond.Returning;
        }
        if (autoWindUp && (bullet_left.bulletCond == Bullet.BulletCond.StayingOther))
        {
            VRAddPowerToPlayer.AddPower();
            bullet_left.bulletCond = Bullet.BulletCond.Returning;
        }

        // どこに書くのがいいんだろう?
        if (Input.GetKeyDown(KeyCode.Q) && (bullet_right.bulletCond == Bullet.BulletCond.StayingOther))
        {
            VRAddPowerToPlayer.AddPower();
        }
        if (Input.GetKeyDown(KeyCode.Q) && (bullet_left.bulletCond == Bullet.BulletCond.StayingOther))
        {
            VRAddPowerToPlayer.AddPower();
        }

        //Line2のonとoff
        if (bullet_right.bulletCond != Bullet.BulletCond.StayingPlayer)
        {
            Line2.GetComponent<LineRenderer>().enabled = true;
        }
        else
        {
            Line2.GetComponent<LineRenderer>().enabled = false;
        }
        if (bullet_left.bulletCond != Bullet.BulletCond.StayingPlayer)
        {
            Line2_left.GetComponent<LineRenderer>().enabled = true;
        }
        else
        {
            Line2_left.GetComponent<LineRenderer>().enabled = false;
        }

        if (Vector3.Distance(player.transform.position, ColPos) > Values.maxStringLength)
        {
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            ColPos = player.transform.position;
        }
    }
    
}
