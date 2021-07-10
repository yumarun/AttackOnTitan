using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRPlayerAttack : MonoBehaviour
{
    private void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        var attackTarget = collision.collider.gameObject.GetComponent<IAttackable>();

        Debug.Log("あったった " + attackTarget);

        if (attackTarget != null)
        {
            attackTarget.Attacked(10);
        }    
    }
}
