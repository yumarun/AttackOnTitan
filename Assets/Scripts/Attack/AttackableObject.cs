using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackableObject : MonoBehaviour, IAttackable
{
    private int hp = 10;

    [SerializeField] ScoreController sc;
    
    public void Attacked(int damage)
    {
        hp -= damage;
        if (hp <= 0)
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
