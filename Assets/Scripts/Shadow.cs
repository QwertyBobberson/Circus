using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashDistance;
    private float distanceDashed;
    [SerializeField] private float attackDistance;

    [SerializeField] private float changeTargetRate;

    [SerializeField] private Vector2 wanderAreaTopLeft;
    [SerializeField] private Vector2 wanderAreaBottomRight;

    [SerializeField] private float dashCooldown;
    private float timeSinceDash;

    private float timeChasingTarget;

    [SerializeField] private GameObject player;
    private Vector3 target;

    private bool isDashing;

    void Start()
    {
        target = new Vector3(Random.Range(wanderAreaTopLeft.x, wanderAreaBottomRight.x), Random.Range(wanderAreaBottomRight.y, wanderAreaTopLeft.y), 0);
        isDashing = false;
    }


    // Update is called once per frame
    void Update()
    {
        if(!isDashing)
        {
            Wander();
        }
        else
        {
            Dash();
        }
    }

    private void Wander()
    {
        Vector3 toPlayer = transform.position - player.transform.position;

        if(toPlayer.magnitude < attackDistance)
        {
            target = player.transform.position;
        }
        else if(timeChasingTarget > changeTargetRate)
        {
            target = new Vector3(Random.Range(wanderAreaTopLeft.x, wanderAreaBottomRight.x), Random.Range(wanderAreaBottomRight.y, wanderAreaTopLeft.y), 0);
            timeChasingTarget = 0;
        }

        Vector3 toTarget = target - transform.position;

        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(toTarget.y, toTarget.x) * 180.0f / Mathf.PI);

        if(toTarget.magnitude < dashDistance/2.0f && timeSinceDash > dashCooldown)
        {
            isDashing = true;
        }

        timeSinceDash += Time.deltaTime;
        timeChasingTarget += Time.deltaTime;

        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void Dash()
    {
        transform.Translate(Vector3.right * dashSpeed * Time.deltaTime);
        distanceDashed += dashSpeed * Time.deltaTime;

        if(distanceDashed >= dashDistance)
        {
            isDashing = false;
            timeSinceDash = 0;
            distanceDashed = 0;
        }
    }
}
