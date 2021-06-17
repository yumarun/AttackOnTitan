using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] VRPlayerMove player = null;
    [SerializeField] VRWireController wire = null;

    [ContextMenu("UseKeyInput")]
    void ChangeToKeyInput()
    {
        Debug.Log("use keyInput");
        var keyInput = new KeyboardInput();
        player.myInput = keyInput;
        wire.myInput = keyInput;
    }

    [ContextMenu("UseVRInput")]
    void ChangeToVRInput()
    {
        Debug.Log("use VRInput");
        var vrInput = new VRInput();
        player.myInput = vrInput;
        wire.myInput = vrInput;
    }
}