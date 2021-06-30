using UnityEngine;
using UnityEngine.XR;
using System.Collections.Generic;

public class InputManager : MonoBehaviour
{
    [SerializeField] List<GameObject> users;

    [Header("Inputs")]
    [SerializeField] KeyboardInput keyInput = new KeyboardInput();
    [SerializeField] VRInput vrInput = new VRInput();

    private void Awake()
    {
        if (IsConnectingDevice())
        {
            ChangeToVRInput();
        }
        else
        {
            ChangeToKeyInput();
        }
    }

    public static bool IsConnectingDevice()
    {
        var xrDisplaySubsystems = new List<XRDisplaySubsystem>();
        SubsystemManager.GetInstances(xrDisplaySubsystems);
        foreach (var xrDisplay in xrDisplaySubsystems)
        {
            Debug.Log(xrDisplay);
            if (xrDisplay.running)
            {
                return true;
            }
        }
        return false;
    }

    [ContextMenu("UseKeyInput")]
    void ChangeToKeyInput()
    {
        Debug.Log("use keyInput");
        Cursor.lockState = CursorLockMode.Locked;
        foreach (var user in users)
        {
            var inputUsable = user.GetComponent<IInputUser>();
            inputUsable.MyInput = keyInput;
        }
    }

    [ContextMenu("UseVRInput")]
    void ChangeToVRInput()
    {
        Debug.Log("use VRInput");
        foreach (var user in users)
        {
            var inputUsable = user.GetComponent<IInputUser>();
            inputUsable.MyInput = vrInput;
        }
    }

    private void OnValidate()
    {
        // IInputUsableを継承していない, null, 重複している場合は外す
        List<GameObject> validList = new List<GameObject>();
        foreach (var user in users)
        {
            if (user == null)
            {
                continue;
            }

            var inputUsable = user.GetComponent<IInputUser>();
            if (inputUsable == null)
            {
                Debug.LogError($"{user.name} は IInputUsableを継承していません");
                continue;
            }

            if (validList.Contains(user))
            {
                continue;
            }

            validList.Add(user);
        }

        users = validList;
    }
}