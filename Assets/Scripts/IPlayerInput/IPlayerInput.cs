using UnityEngine;

// 新しい入力を追加する場合は、ここに関数を追加してください。
// その後、このインターフェースを継承しているKeyboardInput, VRInputにそれぞれの入力で実装してください。
public interface IPlayerInput
{
    float MoveX();
    float MoveY();
    Quaternion LocalLoatation(Transform transform);
    bool LaunchWire();
    bool WindUpWire();
    bool LaunchWireLeft();
    bool WindUpWireLeft();
}