using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public enum BulletCond
    {
        Going,
        Returning, 
        StayingPlayer,
        StayingOther
    }


    public static BulletCond bulletCond = BulletCond.StayingPlayer;

    [SerializeField] GameObject player;
    [SerializeField] VRWireController wireController;
    
    void Start()
    {
        InititializePosition(player.transform.position);
    }

    void Update()
    {
        //Going処理
        if (bulletCond == BulletCond.Going && Vector3.Distance(transform.position, player.transform.position) > Values.maxStringLength)
        {
            bulletCond = BulletCond.Returning;
        }
        else if (bulletCond == BulletCond.Going)
        {
            moveTowards(Camera.main.transform.position + Camera.main.transform.forward * 100);
        }

        //Returning処理
        if (bulletCond == BulletCond.Returning && Vector3.Distance(transform.position, player.transform.position) < 1f)
        {
            InititializePosition(player.transform.position);
            bulletCond = BulletCond.StayingPlayer;
        }
        else if (bulletCond == BulletCond.Returning)
        {
            moveTowards(player.transform.position);
        }

        if (bulletCond == BulletCond.StayingPlayer)
        {
            InititializePosition(player.transform.position);
        }

        //StayingOther処理
        if (bulletCond == BulletCond.StayingOther)
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        }
        
        
    }

    public void InititializePosition(Vector3 pos)
    {
        transform.position = pos;
    }


    public void moveTowards(Vector3 gole)
    {
        transform.position = Vector3.MoveTowards(transform.position, gole, 100 * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
        {
            bulletCond = BulletCond.StayingOther;
        }
    }
}
