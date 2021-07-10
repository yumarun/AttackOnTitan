using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableObject : MonoBehaviour, IGrabbable
{
    [SerializeField] private Vector3 positionOffset = new Vector3();
    [SerializeField] private Vector3 rotationOffset = new Vector3();

    private LayerMask grabbableLayer;
    private Transform myTfm = null;

    private void Start()
    {
        grabbableLayer = gameObject.layer;
        myTfm = transform;
    }

    public void Grab(Transform handTfm, OVRInput.Controller controller)
    {
        myTfm.parent = handTfm;

        if (controller == OVRInput.Controller.RTouch)
        {
            myTfm.localPosition = positionOffset;
            myTfm.rotation = handTfm.rotation;
            myTfm.Rotate(rotationOffset);
        }
        else if (controller == OVRInput.Controller.LTouch)
        {
            myTfm.localPosition = new Vector3(-positionOffset.x, -positionOffset.y, positionOffset.z);
            myTfm.rotation = handTfm.rotation;
            myTfm.Rotate(-rotationOffset);
        }
        else
        {
            Debug.Log("Grab : InvalidControllerType");
        }
        
        // ignoreRayCastに設定
        gameObject.layer = 2;
    }

    public void Release()
    {
        transform.parent = null;

        gameObject.layer = grabbableLayer;
    }
}
