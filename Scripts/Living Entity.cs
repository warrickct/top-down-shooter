using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour, IDamageable {

    public float startingHealth;
    protected bool dead;
    protected float health;
    //wont be available to other classes or inspector but derived classes (player/enemy) will still have access


    public event System.Action OnDeath;  //void and takes no params. The way of notifying the spawner that the enemies have died

    protected virtual void Start() //virtual keyword prevents the subclass enemy.cs start method from replacing this start method so the enemy will have health. Paired with override keyword in enemy class
    {
        health = startingHealth;
    }

    public void TakeHit(float damage, RaycastHit hit)
    {
        //will do stuff with the hit variable for dyanmic particle effect later.
        TakeDamage(damage);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0 && !dead)
        {
            Die();
        }
    }

    protected void Die()
    {
        dead = true;
        if (OnDeath != null)
        {
            OnDeath();
        }
        GameObject.Destroy(gameObject);
    }

}
