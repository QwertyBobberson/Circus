using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunaLite : LongRangeEnemy
{
    //variables
    [SerializeField]
    public float max;

    [SerializeField]
    public float min;

    protected override void Start()
    {
        base.Start();
        RandomFireRate();
    }

    protected override void Update()
    {
        base.Update();
        FacePlayer();

        if(Shoot())
        {
            RandomFireRate();
        }
    }

    protected void RandomFireRate()
    {
        fireSpeed = Random.Range(max, min);
    }

}
