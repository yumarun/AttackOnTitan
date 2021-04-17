using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRAddPowerToPlayer : MonoBehaviour
{
    public static void AddPower()
    {
        GameObject player = GameObject.Find("VRPlayer");
        Transform cameraTf = GameObject.Find("CenterEyeAnchor").transform;
        Vector3 power = player.transform.forward - player.transform.up * cameraTf.localRotation.x * 2f;
        Debug.Log(power + " " + player.transform.up * cameraTf.localRotation.x * 2f + " " + cameraTf.localRotation.x);
        Vector3 psp = player.GetComponent<Rigidbody>().velocity;
        Vector3 absPsp = new Vector3(Mathf.Abs(psp.x), 0f, Mathf.Abs(psp.z));
        player.GetComponent<Rigidbody>().AddForce(power * Values.powerToPlayer);
    }
}
