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

    [SerializeField] GameObject player = null;

    Vector3 goal = new Vector3();
    Vector3 positionOffset;

    public BulletCond bulletCond = BulletCond.StayingPlayer;
    
    void Start()
    {
        positionOffset = transform.position - player.transform.position;
        InititializePosition();
    }

    void Update()
    {
        switch (bulletCond)
        {
            case BulletCond.Going:
                Go();
                break;
            case BulletCond.Returning:
                Return();
                break;
            case BulletCond.StayingPlayer:
                StayPlayer();
                break;
            case BulletCond.StayingOther:
                StayOther();
                break;
            default:
                Debug.Log("不正な値");
                break;
        }
    }

    public void InititializePosition()
    {
        transform.position = player.transform.position + positionOffset;
    }

    public void moveTowards(Vector3 goal)
    {
        transform.position = Vector3.MoveTowards(transform.position, goal, 100 * Time.deltaTime);
    }

    public void SetGoal(OVRInput.Controller controller)
    {
        Vector3 offset = Camera.main.transform.right;
        if (controller == OVRInput.Controller.LTouch)
        {
            offset *= -1;
        }

        goal = (Camera.main.transform.forward * 2 + offset).normalized * 100;
    }

    private void Go()
    {
        //Going処理
        if (Vector3.Distance(transform.position, player.transform.position) > Values.maxStringLength)
        {
            bulletCond = BulletCond.Returning;
        }
        else
        {
            moveTowards(goal);
        }
    }

    private void Return()
    {
        //Returning処理
        if (Vector3.Distance(transform.position, player.transform.position) < 1f)
        {
            InititializePosition();
            bulletCond = BulletCond.StayingPlayer;
        }
        else
        {
            moveTowards(player.transform.position);
        }
    }

    private void StayPlayer()
    {
        //StayingPlayer処理
        InititializePosition();
    }

    private void StayOther()
    {
        //StayingOther処理
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Stage")
        {
            bulletCond = BulletCond.StayingOther;
        }
    }
}
