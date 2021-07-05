using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackableObject : MonoBehaviour, IAttackable
{
    int Hp = 10;


    [SerializeField] ScoreController sc;
    
    public void Attacked(int damage)
    {
        Hp -= damage;
        if (Hp <= 0)
        {

            sc.Score = sc.Score + 1;
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
