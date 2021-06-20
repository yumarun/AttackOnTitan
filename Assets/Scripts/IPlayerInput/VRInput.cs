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

    public bool LaunchWire()
    {
        return OVRInput.GetDown(OVRInput.Button.One);
    }

    public bool WindUpWire()
    {
        return OVRInput.GetDown(OVRInput.Button.Two);
    }
}