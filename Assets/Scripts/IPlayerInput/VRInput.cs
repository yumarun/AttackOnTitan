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

    public bool LaunchWireRight()
    {
        return OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger);
    }

    public bool WindUpWireRight()
    {
        return OVRInput.GetDown(OVRInput.RawButton.RHandTrigger);
    }

    public bool LaunchWireLeft()
    {
        return OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger);
    }

    public bool WindUpWireLeft()
    {
        return OVRInput.GetDown(OVRInput.RawButton.LHandTrigger);
    }

    public bool GrabOrRelease(OVRInput.Controller controller)
    {
        return OVRInput.GetDown(OVRInput.Button.One, controller);
    }
}