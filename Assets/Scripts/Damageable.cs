using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for all objects that can take damage
/// </summary>
public class Damageable : Collideable
{
    [SerializeField] protected int health;
    [SerializeField] public Element element;

    /// <summary>
    /// Function called when health hits 0
    /// Default: Destroy gameobject
    /// </summary>
    public virtual void Die()
    {
        //Destroy the
        Destroy(gameObject);
    }

    /// <summary>
    /// Check for health reaching 0, call Die
    /// </summary>
    protected virtual void Update()
    {
        if(health <= 0)
        {
            Die();
        }
    }

    /// <summary>
    /// Take health from damageable object
    /// </summary>
    /// <param name="damage">Base damage of attacking object</param>
    /// <param name="attackElement">Element of attacking object</param>
    public virtual void TakeDamage(int damage, Element attackElement)
    {
        float attackMultiplier = Tables.damageTable[(int)element, (int)attackElement];
        health -= damage;
    }
}
