using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaise : Enemy
{
    [SerializeField] private float dodgeSpeed;
    [SerializeField] private float dodgeLength;

    [SerializeField] private float dodgeTime;

    private int direction;

    private float timeSinceDodge;

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
        if(timeSinceDodge > dodgeTime)
        {
            //determine if he will dodge left or right 
            direction = Random.Range(1, 3);

            if (direction == 1)
            {
                transform.Translate(-dodgeLength, 0, 0);
            }
            else
            {
                transform.Translate(dodgeLength, 0, 0);
            }

            timeSinceDodge = 0;
        }

        timeSinceDodge += Time.deltaTime;

        //shoot fireballs

    }

}
