using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 
public class Bullet : GameUnit
{
    public Rigidbody rb;
    public Vector3 DirectToBot;
    public Vector3 botPosition;
    public float speedBullet;
    //[NonSerialized] public Player player;
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
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Weapon"))
        {            
            OnDespawn();
            character.IncreaseRadius();
            character.IncreaseScale();
            character.bulletAvailable = true;
            Debug.Log(character.name);
            //if(character.gameObject == player.gameObject)
            //{
            //    GameManager.Ins.UserData.CurrentCoins++;
            //}
        }
          
    }
}
