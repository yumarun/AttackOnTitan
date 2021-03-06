using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGrabber : MonoBehaviour, IInputUser
{
    [SerializeField] private Transform rayOrigin = null;
    [SerializeField] private Transform handTfm = null;
    [SerializeField] private float rayMaxLength = 1.5f;
    [SerializeField] LayerMask grabbableLayer = new LayerMask();
    [SerializeField] private OVRInput.Controller controller = OVRInput.Controller.RTouch;

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
        var ray = new Ray(rayOrigin.position, rayOrigin.forward);

        //Debug.DrawRay (rayOrigin.position, rayOrigin.forward * rayMaxLength, Color.blue, 10);

        if (Physics.SphereCast(ray, 0.3f,out var hit, rayMaxLength, grabbableLayer))
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

            hitGrabbable.Grab(handTfm, controller);
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
