using UnityEngine;
using System;

public class DroneStats : MonoBehaviour
{

    public int maxHP=100,currentHP;
    public float defenseMultiplier=1f;//shields etc
    public Action<int,int> OnHealthChanged;
    Action OnDeath;

    void Awake()
    {
        currentHP=maxHP;
    }
    
    //Apply damage (BattleManager calls this)
}
