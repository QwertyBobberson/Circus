using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaise : Enemy
{
    [SerializeField] private float dodgeSpeed;
    [SerializeField] private float dodgeLength;

    [SerializeField] private float timeStationary;
    [SerializeField] private float dodgeTime;

    private int direction;

    private float timeSinceDodge;
    private float timeSpentDodging;

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        LongRange();
    }


    //blaise dodges back and forth horizontally
    //tracking fireballs
    //fire wall
    private void LongRange()
    {
        //dodging
        if(timeSinceDodge > timeStationary)
        {
            if(direction == 0)
            {
                float xPos = Camera.main.WorldToViewportPoint(transform.position).x;
                float distanceToEdge = Mathf.Abs(0.5f - xPos);
                if(distanceToEdge > 0.4f)
                {
                    direction = -(Mathf.RoundToInt(xPos) * 2 - 1);
                }
                else
                {
                    direction = (Random.Range(0, 2) * 2) - 1;
                }
            }

            if(timeSpentDodging < dodgeTime)
            {
                //determine if he will dodge left or right
                transform.Translate(direction * dodgeSpeed * Time.deltaTime, 0, 0);
                timeSpentDodging += Time.deltaTime;
            }
            else
            {
                timeSpentDodging = 0;
                timeSinceDodge = 0;
                direction = 0;
            }
        }

        timeSinceDodge += Time.deltaTime;

        //shoot fireballs

    }

}
