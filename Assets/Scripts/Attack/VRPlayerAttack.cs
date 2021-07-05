using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRPlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        var attacktarget = collision.collider.gameObject.GetComponent<IAttackable>();

        Debug.Log("あったった " + attacktarget);

        if (attacktarget != null)
        {
            attacktarget.Attacked(10);
        }    
    }
}
