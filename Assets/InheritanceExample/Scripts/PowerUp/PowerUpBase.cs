using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpBase : MonoBehaviour
{
    protected float PowerupDuration;
    protected float StartDuration;
    [SerializeField] protected GameObject _visuals;
    [SerializeField] protected Collider _collider;

    protected abstract void PowerUp();
    protected abstract void PowerDown();
    

    private void OnTriggerEnter(Collider other)
    {
        Projectile projectile = other.GetComponent<Projectile>();
        if (projectile != null)
        {
            StartCoroutine(PowerupTime());
            if (StartDuration == PowerupDuration)
            {
                PowerDown();
                Debug.Log("powerdown");
                Destroy(gameObject);
            }
        }
    }

    private IEnumerator PowerupTime()
    {
        VisualAndCollider();
        PowerUp();
        yield return new WaitUntil(() => StartDuration == PowerupDuration);

    }
    protected void VisualAndCollider()
    {
        _visuals.SetActive(false);
        _collider.enabled = false;
    }

    private void Update()
    {
        if (StartDuration < PowerupDuration)
        {
            StartDuration += Time.deltaTime;
        }
        
    }




}
