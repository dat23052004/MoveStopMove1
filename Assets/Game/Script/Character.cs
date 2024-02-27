using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : ColorObject
{
    [SerializeField] public float moveSpeed;
    [SerializeField] Animator anim;
    [SerializeField] public float timer = 2;
    protected float bulletTime;
    protected float speedBullet = 4;
    public float radius = 5;
    public Transform SpawnBullet;

    public bool isDead = false;
    public bool isMoving = false;  
    public bool canShoot = false;
    public bool bulletAvailable = true;
    protected string currentAnim;

    [SerializeField] GameObject Sight_Can_Shoot;
    [SerializeField] Vector3 scaleIncrease = new Vector3(0.01f, 0.01f, 0.01f);
    [SerializeField] Vector3 scaleSight= new Vector3(0.08f, 0.08f, 0.08f);

    [SerializeField] protected Transform weaponHoldingPos;
    [SerializeField] protected WeaponData weaponData;
    [SerializeField] protected PantData pantData;
    [SerializeField] protected HairData hairData;
    protected Weapon weaponInstance;
    public GameObject hairInstance;
    public Transform hairPos;
    public SkinnedMeshRenderer pantInstance;

    protected virtual void Update()
    {
        
    }
    public virtual void OnInit()
    {
        //this.gameObject.layer = charLayerNumber;
        isDead = false;
        ChangeAnim(Constant.ANIM_IDLE);
        if (weaponData != null)
        {
            ChangeWeapon();           
        }
        if (hairData != null)
        {
            ChangeHair();
        }
        if (pantData != null)
        {
            ChangePant();
        }
    }

    public void ChangeWeapon()
    {
        weaponData = DataManager.Ins.GetWeaponData(GameManager.Ins.UserData.EquippedWeapon);

        if (weaponInstance != null)
        {
            Destroy(weaponInstance.gameObject);
        }  
        weaponInstance = Instantiate(weaponData.weapon, weaponHoldingPos.position, weaponHoldingPos.rotation, weaponHoldingPos);  
    }

    public void TryHair(int index)
    {
        hairData = DataManager.Ins.hairData[index];
        if (hairInstance != null)
        {
            Destroy(hairInstance.gameObject);
        }
        hairInstance = Instantiate(hairData.hairPrefab, hairPos.position, hairPos.rotation, hairPos);
    }

    public void ChangeHair()
    {        
        hairData = DataManager.Ins.GetHatData(GameManager.Ins.UserData.EquippedHat);
        if (hairInstance != null)
        {
            Destroy(hairInstance.gameObject);
        }
        hairInstance = Instantiate(hairData.hairPrefab, hairPos.position, hairPos.rotation, hairPos);
               
    }

    public void TryPant(int index)
    {
        pantData = DataManager.Ins.pantData[index];
        pantInstance.material = pantData.PantMaterial;
    }
    public void ChangePant()
    {
       
        pantData = DataManager.Ins.GetPantData(GameManager.Ins.UserData.EquippedPant);      
        pantInstance.material = pantData.PantMaterial;
    }

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
    protected virtual void OnDespawn()
    {
        LevelManager.Ins.finishedLevel = false;
        LevelManager.Ins.OnLose();
    }
    public void IncreaseScale()
    {
        // Tăng kích thước của đối tượng
        transform.localScale += scaleIncrease;

    }

    public void IncreaseRadius()
    {
        radius += 0.1f;

        Sight_Can_Shoot.transform.localScale += scaleSight; 
       
    }

}
