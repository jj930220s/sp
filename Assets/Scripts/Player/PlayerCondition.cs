using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{
    void TakePhysicalDamage(int damage);
}


public class PlayerCondition : MonoBehaviour, IDamagable
{
    public UICondition uiContition;

    Condition health { get { return uiContition.health; } }
    Condition hunger { get { return uiContition.hunger; } }
    Condition stamina { get { return uiContition.stamina; } }

    public float noHungerHealthDecay;

    public event Action onTakeDamage;


    // Update is called once per frame
    void Update()
    {
        hunger.Subtract(hunger.passiveValue * Time.deltaTime);
        stamina.Add(stamina.passiveValue * Time.deltaTime);
    
        if(hunger.curValue<=0f)
        {
            health.Subtract(noHungerHealthDecay * Time.deltaTime);
        }
    
        if(health.curValue<=0f)
        {
            Die();
        }
    }
    
    public void Heal(float amount)
    {
        health.Add(amount);
    }
    public void Eat(float amount)
    {
        hunger.Add(amount);
    }


    void Die()
    {
        Debug.Log("Á×À½");
    }

    public void TakePhysicalDamage(int damage)
    {
        health.Subtract(damage);
        onTakeDamage?.Invoke();
    }

    public bool UseStamina(float amount)
    {
        if(stamina.curValue-amount<0)
        {
            return false;
        }

        stamina.Subtract(amount);
        return true;
    }
}
