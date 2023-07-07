using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runa : LongRangeEnemy
{
    [SerializeField] private int maxClones;
    [SerializeField] private float cloneRadius;
    [SerializeField] public int shieldHealth;

    [SerializeField] private GameObject lite;
    public static int clonesRemaining;

    protected override void Update()
    {
        if(clonesRemaining == 0)
        {
            SummonLites();
        }

        FacePlayer();
        Shoot();
    }

    /// <summary>
    /// Summon lites surrounding player
    /// </summary>
    private void SummonLites()
    {
        float radiansPerLite = (2.0f*Mathf.PI)/(maxClones + 1);

        float startingAngle = Mathf.PI/2.0f + radiansPerLite;
        Vector3 center = player.transform.position;

        for(int i = 0; i < maxClones; i++)
        {
            float currentAngle = startingAngle + radiansPerLite * i;
            Vector3 direction = new Vector3(Mathf.Cos(currentAngle), Mathf.Sin(currentAngle));
            Instantiate(lite, center + (direction * cloneRadius), Quaternion.identity, null);
            clonesRemaining++;
        }
    }
}
