using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPowerToPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;

    public static void AddPower()
    {
        GameObject player = GameObject.Find("Player");
        GameObject camera = GameObject.Find("Camera");
        Vector3 power = player.transform.forward - player.transform.up * camera.transform.localRotation.x * 2f;
        player.GetComponent<Rigidbody>().AddForce(power * Values.powerToPlayer);
    }
}
