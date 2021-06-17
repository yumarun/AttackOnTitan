using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class VRPlayerMove : MonoBehaviour
{
    [SerializeField] GameObject VRPlayer;
    [SerializeField] int moveSpeed = 1;
    [SerializeReference] public IInput myInput;

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
        Vector2 stickR = new Vector2(myInput.MoveX(), myInput.MoveY());
        Vector3 changePosition = new Vector3((stickR.x), 0, (stickR.y)) * 0.1f;
        Vector3 changeRotation = new Vector3(0, myInput.LocalLoatation(VRPlayer.transform).y, 0);
        if (VRPlayer.GetComponent<Rigidbody>().velocity.y == 0.0)
        {
            VRPlayer.transform.position += this.transform.rotation * (Quaternion.Euler(changeRotation) * changePosition) 
                * moveSpeed * Time.deltaTime;
        }
    }
}
