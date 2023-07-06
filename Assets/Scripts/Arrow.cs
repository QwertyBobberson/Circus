using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private int damageDealt;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

    }

    //check collisions and take away enemy health
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //get gameObject that has shadow component
        Shadow shadow = collision.gameObject.GetComponent<Shadow>();

        //if arrow is colliding with shadow
        if (shadow != null)
        {
            //subtract shadow health
            shadow.health -= damageDealt;
        }
    }
}
