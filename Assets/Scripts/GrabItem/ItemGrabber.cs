using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGrabber : MonoBehaviour, IInputUser
{
    [SerializeField] Transform rayOrigin = null;
    [SerializeField] Transform handTfm = null;
    [SerializeField] int rayMaxLength = 2;
    [SerializeField] LayerMask grabbableLayer = new LayerMask();
    [SerializeField] OVRInput.Controller controller = OVRInput.Controller.RTouch;

    private IGrabbable grabbingItem = null;

    public IPlayerInput MyInput { get; set; }

    private void Awake()
    {
        if (InputManager.IsConnectingDevice())
        {
            handTfm.localPosition = Vector3.zero;
        }
        else
        {
            rayOrigin = Camera.main.transform;
        }
    }

    private void Update()
    {
        if (MyInput.GrabOrRelease(controller))
        {
            if (grabbingItem == null)
            {
                Grab();
            }
            else
            {
                Release();
            }
        }
    }

    private void Grab()
    {
        Ray ray = new Ray(rayOrigin.position, rayOrigin.forward);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, rayMaxLength, grabbableLayer))
        {
            var hitObject = hit.collider.gameObject;

            // 早期リターン
            if (hitObject == null)
            {
                return;
            }

            var hitGrabbable = hitObject.GetComponent<IGrabbable>();
            if (hitGrabbable == null)
            {
                return;
            }

            hitGrabbable.Grab(handTfm);
            grabbingItem = hitGrabbable;
        }
    }

    private void Release()
    {
        if (grabbingItem == null)
        {
            return;
        }

        grabbingItem.Release();
        grabbingItem = null;
    }
}
