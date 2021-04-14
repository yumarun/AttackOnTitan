using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float power;

    bool okJump = true;

    void Update()
    {

        okJump = player.GetComponent<Rigidbody>().velocity.y == 0f;
        if (Input.GetKeyDown(KeyCode.Space) && okJump)
        {
            player.GetComponent<Rigidbody>().AddForce(0f, power, 0f);
        }
    }
}
