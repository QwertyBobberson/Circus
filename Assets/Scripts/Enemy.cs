using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for everything that attacks the player
/// </summary>
public class Enemy : Damageable
{
    protected GameObject player;
    protected Damageable playerHealth;
    protected int damage;

    /// <summary>
    /// Find player object, to be used by derived classes
    /// Also gets damageable component of player
    /// </summary>
    protected override void Start()
    {
        base.Start();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<Damageable>();
    }

    /// <summary>
    /// Point object towards player object
    /// </summary>
    protected void FacePlayer()
    {
        Vector3 toTarget = player.transform.position - transform.position;
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(toTarget.y, toTarget.x) * 180.0f / Mathf.PI);
    }

    /// <summary>
    /// Deal damage to player on collision
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //check if colliding with player
        if(collision.gameObject == player)
        {
            //subtract player health
            playerHealth.TakeDamage(damage, element);
        }
    }
}
