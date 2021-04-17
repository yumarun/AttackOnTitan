using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRAddPowerToPlayer : MonoBehaviour
{
    public static void AddPower()
    {
        GameObject player = GameObject.Find("VRPlayer");
        Transform cameraTf = GameObject.Find("OVRCameraRig").transform;
        Vector3 power = player.transform.forward - player.transform.up * cameraTf.localRotation.x * 2f;
        Debug.Log(power);
        player.GetComponent<Rigidbody>().AddForce(-power * Values.powerToPlayer);
    }
}
