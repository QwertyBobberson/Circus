using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongRangeEnemy : Enemy
{
    //variables
    [SerializeField]
    protected GameObject projectile;

    [SerializeField]
    protected float fireSpeed;

    private float timeSinceLastShot;

    /// <summary>
    /// long range enemy shoot
    /// </summary>
    protected virtual bool Shoot()
    {
        if (timeSinceLastShot > fireSpeed)
        {
            //get rotation enemy is facing + store radians
            float radians = transform.rotation.eulerAngles.z / 180 * Mathf.PI;

            //get direction the projectiles will spawn and go in
            Vector3 direction = new Vector3(Mathf.Cos(radians), Mathf.Sin(radians));

            //create and spawn projectile in correct direction
            Instantiate(projectile, transform.position + direction, transform.rotation, null);

            timeSinceLastShot = 0;

            return true;
        }

        timeSinceLastShot += Time.deltaTime;

        return false;
    }
}
