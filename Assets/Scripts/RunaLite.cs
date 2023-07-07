using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunaLite : Enemy
{
    protected override void Update()
    {
        base.Update();
        FacePlayer();
    }
}
