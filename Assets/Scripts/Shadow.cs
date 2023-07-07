using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : Enemy
{
    [SerializeField] private float speed;
    [SerializeField] AnimationCurve dashSpeedCurve;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashDistance;
    [SerializeField] private float dashTime;
    private float timeDashed;
    [SerializeField] private float attackDistance;

    [SerializeField] private float changeTargetRate;

    [SerializeField] private Vector2 wanderAreaTopLeft;
    [SerializeField] private Vector2 wanderAreaBottomRight;

    [SerializeField] private float dashCooldown;
    private float timeSinceDash;

    private float timeChasingTarget;
    private Vector3 target;

    private bool isDashing;

    protected override void Start()
    {
        base.Start();
        target = new Vector3(Random.Range(wanderAreaTopLeft.x, wanderAreaBottomRight.x), Random.Range(wanderAreaBottomRight.y, wanderAreaTopLeft.y), 0);
        isDashing = false;
    }


    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
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
        //Find distance to player, target player if close enough
        Vector3 toPlayer = transform.position - player.transform.position;

        if(toPlayer.magnitude < attackDistance)
        {
            target = player.transform.position;
        }
        //If not targeting player, and chasing fake target for too long, find new fake target
        else if(timeChasingTarget > changeTargetRate)
        {
            target = new Vector3(Random.Range(wanderAreaTopLeft.x, wanderAreaBottomRight.x), Random.Range(wanderAreaBottomRight.y, wanderAreaTopLeft.y), 0);
            timeChasingTarget = 0;
        }

        //Turn towards target and move forwards
        Vector3 toTarget = target - transform.position;

        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(toTarget.y, toTarget.x) * 180.0f / Mathf.PI);

        transform.Translate(Vector3.right * speed * Time.deltaTime);

        //If close enough to target, begin dashing
        if(toTarget.magnitude < dashDistance/2.0f && timeSinceDash > dashCooldown)
        {
            isDashing = true;
        }

        //Increment timer for dash cooldown and fake target time
        timeSinceDash += Time.deltaTime;
        timeChasingTarget += Time.deltaTime;
    }

    private void Dash()
    {
        //Move forwards at dash speed
        transform.Translate(Vector3.right * dashSpeed * Time.deltaTime * dashSpeedCurve.Evaluate(timeDashed/dashTime));

        //Keep track of how much distance has been covered by the dash
        timeDashed += Time.deltaTime;

        //End the dash and reset counters if moved far enough
        if(timeDashed >= dashTime)
        {
            isDashing = false;
            timeSinceDash = 0;
            timeDashed = 0;
        }
    }

}
