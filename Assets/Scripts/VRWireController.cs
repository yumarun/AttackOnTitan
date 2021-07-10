using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRWireController : MonoBehaviour, IInputUser
{
    [SerializeField] Rigidbody player = null;
    [SerializeField] bool autoWindUp = false;

    [SerializeField] Bullet bullet = null;
    [SerializeField] LineRenderer wire = null;
    [SerializeField] OVRInput.Controller controller = OVRInput.Controller.RTouch;

    private Vector3 bulletInitialLocalPos;

    public IPlayerInput MyInput { get; set; }
    public static Vector3 ColPos = default;

    private void Awake()
    {
        bulletInitialLocalPos = bullet.transform.position - player.transform.position;
    }

    private void Update()
    {
        wire.SetPosition(0, player.transform.position + bulletInitialLocalPos);
        wire.SetPosition(1, bullet.gameObject.transform.position);

        if (MyInput.LaunchWire(controller))
        {
            if (bullet.bulletCond != Bullet.BulletCond.StayingOther)
            {
                bullet.SetGoal(controller);
                // Debug.DrawLine(bullet.transform.position, bullet.transform.position + (Camera.main.transform.forward * 2 + Camera.main.transform.right).normalized * 100, Color.red, 10f);
                bullet.bulletCond = Bullet.BulletCond.Going;
            }
            else
            {
                bullet.bulletCond = Bullet.BulletCond.Returning;
            }
        }

        if (MyInput.WindUpWire(controller))
        {
            bullet.bulletCond = Bullet.BulletCond.Returning;
            ColPos = player.transform.position;
        }

        // どこに書くのがいいんだろう?
        // ワイヤー巻取り
        if (MyInput.MoveToBullet(controller) && (bullet.bulletCond == Bullet.BulletCond.StayingOther) 
            || (autoWindUp && (bullet.bulletCond == Bullet.BulletCond.StayingOther)))
        {
            VRAddPowerToPlayer.AddPower();
            bullet.bulletCond = Bullet.BulletCond.Returning;
        }

        if (Vector3.Distance(player.transform.position, ColPos) > Values.maxStringLength)
        {
            player.velocity = Vector3.zero;
            ColPos = player.transform.position;
        }
    }
}
