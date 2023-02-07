using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : EnemyBase
{
    private float _resetTime; 

    protected override void OnHit()
    {
        StartCoroutine(PauseOnHit());
    }

    public IEnumerator PauseOnHit()
    {
        MoveSpeed = 0f;
        _resetTime = 0;
        yield return new WaitUntil(() => _resetTime >= 1);
        MoveSpeed = 0.05f;

    }

    private void Update()
    {
        if (_resetTime <= 1)
        {
            _resetTime += Time.deltaTime;
        }
    }









}
