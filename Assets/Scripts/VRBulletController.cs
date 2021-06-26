using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRBulletController : MonoBehaviour
{
    GameObject player;
    LineRenderer lr;

    public bool goToPlayer = false;

    void Start()
    {
        player = GameObject.Find("VRPlayer");
        lr = GameObject.Find("Line2").GetComponent<LineRenderer>();
    }

    void Update()
    {
        lr.SetPosition(1, transform.position);

        if (transform.position.y <= -10 || transform.position.y >= 500)
        {
            Destroy(gameObject);
        }

        if (Vector3.Distance(player.transform.position, transform.position) > Values.maxStringLength)
        {
            lr.SetPosition(1, player.transform.position);
            lr.enabled = false;
            Destroy(gameObject);
        }

        //2021/06/26追加
        //プレイヤーの方に向かっているとき＆プレイヤーとの距離が5m以下になったときに破壊
        if (goToPlayer && Vector3.Distance(player.transform.position, transform.position) < 5f)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            VRAddPowerToPlayer.AddPower();
            VRWireController.ColPos = transform.position;
            lr.SetPosition(1, transform.position);
            Destroy(gameObject);
        }
    }
}
