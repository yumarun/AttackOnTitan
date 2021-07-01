using UnityEngine;
using UnityEngine.XR;

public class VRInput : IPlayerInput
{
    public float MoveX()
    {
        return OVRInput.Get(OVRInput.RawAxis2D.LThumbstick).x;
    }

    public float MoveY()
    {
        return OVRInput.Get(OVRInput.RawAxis2D.LThumbstick).y;
    }

    public Quaternion LocalLoatation(Transform transform)
    {
        return InputTracking.GetLocalRotation(XRNode.Head);
    }

    public bool LaunchWire(OVRInput.Controller controller)
    {
        return OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, controller);
    }

    public bool WindUpWire(OVRInput.Controller controller)
    {
        return OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, controller);
    }

    public bool GrabOrRelease(OVRInput.Controller controller)
    {
        return OVRInput.GetDown(OVRInput.Button.One, controller);
    }
}