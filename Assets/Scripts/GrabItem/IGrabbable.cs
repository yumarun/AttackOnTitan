using UnityEngine;
public interface IGrabbable
{
    void Grab(Transform handTfm);
    void Release();
}