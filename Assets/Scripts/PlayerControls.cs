using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : Damageable
{
    //variables
    public float speed;


    [SerializeField]
    private float fireSpeed;

    [SerializeField]
    private GameObject arrow;

    private float timeSinceLastShot;

    [SerializeField]
    private float projectileStartDistance;

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        Movement();
        Shoot();
    }

    /// <summary>
    /// Handle movement and rotation of player
    /// </summary>
    private void Movement()
    {
        Vector2 movement = new Vector2();

        //if player presses W
        if (Input.GetKey(KeyCode.W))
        {
            //player will move on y axis by speed
            movement.y += 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement.y += -1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement.x += -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement.x += 1;
        }

        //make sure that no matter what direction you move in, you move at the same speed
        //* delta time so that regurdless of framerate, you move at the same speed
        movement = movement.normalized * speed * Time.deltaTime;

        //move player
        transform.Translate(movement, Space.World);

        if (movement != Vector2.zero)
        {
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(movement.y, movement.x) * 180.0f / Mathf.PI);
        }
    }

    /// <summary>
    /// Handle spawning projectiles
    /// </summary>
    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0) && timeSinceLastShot > fireSpeed)
        {
            //get rotation player is facing + store radians
            float radians = transform.rotation.eulerAngles.z / 180 * Mathf.PI;

            //get direction the arrows will spawn and go in
            Vector3 direction = new Vector3(Mathf.Cos(radians), Mathf.Sin(radians));

            //create and spawn arrow in correct direction
            Instantiate(arrow, transform.position + direction * projectileStartDistance, transform.rotation, null);

            //reset time for firing speed
            timeSinceLastShot = 0;
        }

        //keep track of time passed since last arrow was shot
        timeSinceLastShot += Time.deltaTime;
    }

}
