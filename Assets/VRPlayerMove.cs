using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class VRPlayerMove : MonoBehaviour
{
    [SerializeField] GameObject VRPlayer;

    void Start()
    {
        
    }

    void Update()
    {
        move();
    }

    void move()
    {
        Vector2 stickR = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick);
        Vector3 changePosition = new Vector3((stickR.x), 0, (stickR.y)) * 0.1f;
        Vector3 changeRotation = new Vector3(0, InputTracking.GetLocalRotation(XRNode.Head).eulerAngles.y, 0);
        if (VRPlayer.GetComponent<Rigidbody>().velocity.y == 0.0)
        {
            VRPlayer.transform.position += this.transform.rotation * (Quaternion.Euler(changeRotation) * changePosition);
        }
    }
}
