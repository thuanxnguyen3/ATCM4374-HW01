using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charger : EnemyBase
{
    [SerializeField] protected GameObject RF;

    protected override void OnHit()
    {
        // increase speed when hit
        MoveSpeed *= 2;

    }

    public override void Kill()
    {
        if (RF != null)
        {
            Instantiate(RF, transform.position, Quaternion.identity);
        }
        base.Kill();
    }

}
