using UnityEngine;

// 新しい入力を追加する場合は、ここに関数を追加してください。
// その後、このインターフェースを継承しているKeyboardInput, VRInputにそれぞれの入力で実装してください。
public interface IPlayerInput
{
    float MoveX();
    float MoveY();
    Quaternion LocalRotation(Transform transform);
    bool LaunchWire(OVRInput.Controller controller);
    bool WindUpWire(OVRInput.Controller controller);
    bool GrabOrRelease(OVRInput.Controller controller);
    /// <summary>
    /// 一時的な入力。いつか直したい
    /// </summary>
    /// <param name="controller"></param>
    /// <returns></returns>
    bool MoveToBullet(OVRInput.Controller controller);
}