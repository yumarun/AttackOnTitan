using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.XR;

public class VRPlayerMove : MonoBehaviour, IInputUser
{
    [SerializeField] Rigidbody vrPlayer = null;
    [SerializeField] private int moveSpeed = 1;

    public IPlayerInput MyInput{ get; set; }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 stickR = new Vector2(MyInput.MoveX(), MyInput.MoveY());
        Vector3 changePosition = new Vector3((stickR.x), 0, (stickR.y)) * 0.1f;
        Vector3 changeRotation = new Vector3(0, MyInput.LocalRotation(vrPlayer.transform).y, 0);
        if (vrPlayer.velocity.y == 0.0)
        {
            vrPlayer.transform.position += transform.rotation * (Quaternion.Euler(changeRotation) * changePosition) * (moveSpeed * Time.deltaTime);
        }
    }
}
