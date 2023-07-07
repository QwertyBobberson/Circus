using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tables
{
    /// <summary>
    /// Damage multipliers for element combinations
    /// </summary>
    /// <value></value>
    static public float[,] damageTable = new float[,]
    {
        //          Light       Shadow          Fire     Smoke
        /*Light */  {1.0f,      0.5f,           1.0f,     2.0f  },
        /*Shadow*/  {2.0f,      1.0f,           2.0f,     1.0f  },
        /*Fire*/    {1.0f,      1.0f,           1.0f,     1.0f  },
        /*smoke*/   {0.5f,      1.0f,           1.0f,     0.0f  }
    };
}
