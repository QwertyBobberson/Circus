using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Automatically add components necessary for collision
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
/// <summary>
/// Class for all objects that can collide
/// </summary>
public class Collideable : MonoBehaviour
{
    /// <summary>
    /// Disable gravity and dissallow collideables from pushing each other
    /// </summary>
    protected virtual void Start()
    {
        //Disable gravity and dissallow collideables from pushing each other
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;

        Collider2D collider = GetComponent<Collider2D>();
        collider.isTrigger = true;
    }
}
