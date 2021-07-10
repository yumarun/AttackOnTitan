using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Bullet : MonoBehaviour
{
    public enum BulletCond
    {
        Going,
        Returning, 
        StayingPlayer,
        StayingOther
    }

    [SerializeField] private GameObject player = null;
    [SerializeField] private Transform mainCameraTransform = null;

    private Vector3 goal = new Vector3();
    private Vector3 positionOffset;

    public BulletCond bulletCond = BulletCond.StayingPlayer;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        positionOffset = transform.position - player.transform.position;
        InitializePosition();
    }

    private void Update()
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

    private void InitializePosition()
    {
        transform.position = player.transform.position + positionOffset;
    }

    private void MoveTowards(Vector3 goal)
    {
        transform.position = Vector3.MoveTowards(transform.position, goal, 100 * Time.deltaTime);
    }

    public void SetGoal(OVRInput.Controller controller)
    {
        var offset = mainCameraTransform.right;
        if (controller == OVRInput.Controller.LTouch)
        {
            offset *= -1;
        }

        goal = transform.position + (mainCameraTransform.forward * 2 + offset).normalized * 100;
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
            MoveTowards(goal);
        }
    }

    private void Return()
    {
        //Returning処理
        if (Vector3.Distance(transform.position, player.transform.position) < 1f)
        {
            InitializePosition();
            bulletCond = BulletCond.StayingPlayer;
        }
        else
        {
            MoveTowards(player.transform.position);
        }
    }

    private void StayPlayer()
    {
        //StayingPlayer処理
        InitializePosition();
    }

    private void StayOther()
    {
        //StayingOther処理
        rb.constraints = RigidbodyConstraints.FreezePosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Stage"))
        {
            bulletCond = BulletCond.StayingOther;
        }
    }
}
