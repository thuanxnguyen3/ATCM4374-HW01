using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidFire : PowerUpBase
{
    private TurretController TC;

    private void Start()
    {
        TC = FindObjectOfType<TurretController>();
    }


    protected override void PowerUp()
    {
        PowerupDuration = 2f;
        TC.FireCooldown /= 2;
    }

    protected override void PowerDown()
    {
        Debug.Log("Powerdown");
        TC.FireCooldown *= 2;
    }
}
