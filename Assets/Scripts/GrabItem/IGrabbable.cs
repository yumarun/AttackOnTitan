using UnityEngine;
public interface IGrabbable
{
    void Grab(Transform handTfm, OVRInput.Controller controller);
    void Release();
}