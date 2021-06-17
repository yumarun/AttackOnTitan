using UnityEngine;

public interface IInput
{
    float MoveX();
    float MoveY();
    Quaternion LocalLoatation(Transform transform);
    bool LaunchWire();
    bool WindUpWire();
}