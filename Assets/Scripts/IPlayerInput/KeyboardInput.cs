using UnityEngine;

[System.Serializable]
public class KeyboardInput : IPlayerInput
{
    [SerializeField] float mouseSensitivity = 5;
    [SerializeField] Transform camera = null;

    private float rotX = 0;
    private float rotY = 0;

    private void ChangeAngle(Transform tfm)
    {
        rotX -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        rotY += Input.GetAxis("Mouse X") * mouseSensitivity;

        rotX = Mathf.Clamp(rotX, -90, 90);
        while (rotY < 0)
        {
            rotY += 360;
        }
        while (rotY > 360)
        {
            rotY -= 360;
        }
        tfm.eulerAngles = new Vector3(0, rotY, 0);

        camera.eulerAngles = new Vector3(rotX, rotY, 0);
    }

    public float MoveX()
    {
        return Input.GetAxis("Horizontal");
    }

    public float MoveY()
    {
        return Input.GetAxis("Vertical");
    }

    public Quaternion LocalLoatation(Transform tfm)
    {
        ChangeAngle(tfm);
        return tfm.rotation;
    }

    public bool LaunchWireRight()
    {
        return Input.GetMouseButtonDown(0);
    }

    public bool WindUpWireRight()
    {
        return Input.GetMouseButtonDown(1);
    }

    public bool LaunchWireLeft()
    {
        return Input.GetKeyDown(KeyCode.Alpha1);
    }

    public bool WindUpWireLeft()
    {
        return Input.GetKeyDown(KeyCode.Alpha2);
    }

    public bool GrabOrRelease(OVRInput.Controller controller)
    {
        if (controller == OVRInput.Controller.RTouch)
        {
            return Input.GetKeyDown(KeyCode.C);
        }
        else
        {
            return Input.GetKeyDown(KeyCode.Z);
        }
    }
}