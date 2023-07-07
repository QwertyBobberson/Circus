using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Collideable
{
    [SerializeField] protected int damage;
    [SerializeField] protected float speed;
    [SerializeField] public Element element;

    /// <summary>
    /// Move forwards every frame
    /// </summary>
    protected virtual void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    /// <summary>
    /// Deal damage to damageable
    /// Should be overriden to add unique effects
    /// </summary>
    /// <param name="damageable"></param>
    protected virtual void HitDamageable(Damageable damageable)
    {
        damageable.TakeDamage(damage, element);
    }

    /// <summary>
    /// Deal damage to any damageable hit
    /// </summary>
    /// <param name="collision"></param>
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        //get gameObject that has shadow component
        Damageable damageable = collision.gameObject.GetComponent<Damageable>();
        //if arrow is colliding with shadow
        if (damageable != null)
        {
            //subtract shadow health
            HitDamageable(damageable);
        }
    }
}
