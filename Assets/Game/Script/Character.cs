using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : ColorObject
{
    [SerializeField] public float moveSpeed;
    public float radius = 5;
    
    public CapsuleCollider size;

    public Transform SpawnBullet;

    [SerializeField] public float timer = 2;
    protected float bulletTime;
    protected float speedBullet = 4;

    protected string currentAnim;
    public Animator anim;

    public bool bulletAvailable = true;

    [SerializeField] Vector3 scaleIncrease = new Vector3(0.0001f, 0.0001f, 0.0001f);
    public void ChangeAnim(string animName)
    {
        if (currentAnim != animName)
        {
            if (currentAnim != null && currentAnim.Length > 0)
            {
                anim.ResetTrigger(currentAnim);
            }  
                currentAnim = animName;
                anim.SetTrigger(currentAnim);
        }                      
    }

    public void IncreaseScale()
    {
        // Tăng kích thước của đối tượng
        transform.localScale += scaleIncrease;
    }

    public void IncreaseRadius()
    {
        radius += 0.1f;
    }

}
