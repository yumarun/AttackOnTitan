using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableObject : MonoBehaviour, IGrabbable
{
    [SerializeField] Vector3 positionOffset = new Vector3();
    [SerializeField] Vector3 rotationOffset = new Vector3();

    private LayerMask grabbableLayer;

    private void Awake()
    {
        grabbableLayer = gameObject.layer;
    }

    public void Grab(Transform handTfm)
    {
        transform.parent = handTfm;
        transform.position = handTfm.position + positionOffset;
        transform.rotation = handTfm.rotation;
        transform.Rotate(rotationOffset);

        // ignoreRayCast
        gameObject.layer = 2;

        Debug.Log($"grab : {gameObject.name}");
    }

    public void Release()
    {
        transform.parent = null;

        gameObject.layer = grabbableLayer;

        Debug.Log($"release : {gameObject.name}");
    }
}
