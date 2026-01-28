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
    
    //Apply damage or heal (BattleManager calls this)
    public void TakeDamage(int amount)
    {
        int finalDamage = Mathf.RoundToInt(amount*defenseMultiplier);
        currentHP = Mathf.Max(currentHP-finalDamage,0);

        OnHealthChanged?.Invoke(currentHP,maxHP);

        if (currentHP <= 0)
        {
            OnDeath?.Invoke();
        }

    }

    //Healing (for items and abilities)
    public void Heal(int amount)
    {
        currentHP = currentHP+amount;
        
        if(currentHP>maxHP)
            currentHP=maxHP;

        OnHealthChanged?.Invoke(currentHP,maxHP);
    }
}
