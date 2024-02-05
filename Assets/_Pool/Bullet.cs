using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 
public class Bullet : GameUnit
{
    public Rigidbody rb;
    public Vector3 DirectToBot;
    public Vector3 botPosition;
    public float speedBullet;

    public Character character;
    private void Update()
    {
        
    }
    public virtual void OnInit()
    {
        
    }

    public virtual void Moving()
    {
        rb.velocity = DirectToBot * speedBullet;
        
    }
    public void OnDespawn()
    {
        SimplePool.Despawn(this);
        //Debug.Log("Despawn");
    }


    private void OnTriggerEnter(Collider other)
    {
        
        OnDespawn();
        character.IncreaseScale();       
        character.IncreaseRadius();
        character.bulletAvailable = true;
     

        //ParticlePool.Play(ParticleType.Hit, transform.position, Quaternion.identity);
    }
}
