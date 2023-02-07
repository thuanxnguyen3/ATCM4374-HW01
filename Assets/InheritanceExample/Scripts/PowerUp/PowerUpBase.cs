using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpBase : MonoBehaviour
{
    protected float PowerupDuration = 0f;
    [SerializeField] protected GameObject _visuals;
    [SerializeField] protected Collider _collider;
    protected abstract void PowerUp();
    protected abstract void PowerDown();

    private void OnTriggerEnter(Collider other)
    {
        Projectile projectile = other.GetComponent<Projectile>();
        if (projectile != null)
        {

            VisualAndCollider();
            Debug.Log("start powerup");
            PowerUp();
            Invoke("TrackPowerUp", PowerupDuration);

        }
    }

    private void TrackPowerUp()
    {

        PowerDown();
        Destroy(gameObject);

    }

    protected void VisualAndCollider()
    {
        _visuals.SetActive(false);
        _collider.enabled = false;
    }





}




