using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class VRPlayerMove : MonoBehaviour, IInputUser
{
    [SerializeField] GameObject VRPlayer = null;
    [SerializeField] int moveSpeed = 1;

    public IPlayerInput MyInput{ get; set; }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        move();
    }

    void move()
    {
        Vector2 stickR = new Vector2(MyInput.MoveX(), MyInput.MoveY());
        Vector3 changePosition = new Vector3((stickR.x), 0, (stickR.y)) * 0.1f;
        Vector3 changeRotation = new Vector3(0, MyInput.LocalLoatation(VRPlayer.transform).y, 0);
        if (VRPlayer.GetComponent<Rigidbody>().velocity.y == 0.0)
        {
            VRPlayer.transform.position += this.transform.rotation * (Quaternion.Euler(changeRotation) * changePosition) 
                * moveSpeed * Time.deltaTime;
        }
    }
}
