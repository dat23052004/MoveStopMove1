using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UIElements;

public class Bot : Character
{
    public NavMeshAgent navMeshAgent;
 
    private WeaponType currentWeapon = WeaponType.Arrow;
    private IState<Bot> currentState;
    public Vector3 walkPoint;      // Vi tri di chuyen den
    public bool walkPointSet;      
    public float walkPointRange;   // Pham vi di chuyen 

    private void Start()
    {
        OnInit();
    }   

    protected override void Update()
    {
        if (!isDead && currentState != null && GameManager.IsState(GameState.Gameplay))
        {
            if (currentState != null)
            {
                currentState.OnExecute(this);
            }
            if (bulletAvailable)
            {
                weaponInstance.gameObject.SetActive(true);
            }
            currentWeapon = weaponData.weaponType;
            CheckSight();
        }        
    }


    public void CheckSight()
    {
        if (!isMoving)
        {
            if (CheckPosition(out Vector3 enemyPosition))
            {
                Vector3 directionToBot = (enemyPosition - transform.position).normalized;
                transform.rotation = Quaternion.LookRotation(directionToBot);
                ChangeAnim(Constant.ANIM_ATTACK);
                if (canShoot == false)
                {
                    canShoot = true;
                    StartCoroutine(ShootCoroutine(enemyPosition, 0.2f));
                }
            }
        }
    }
    public bool CheckPosition(out Vector3 position)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        position = Vector3.zero;
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject != gameObject && collider.CompareTag("Character"))
            {
                position = collider.transform.position;

                return true;  // Trả về true nếu tìm thấy bot
            }
        }

        return false;
    }
    public IEnumerator ShootCoroutine(Vector3 botPosition, float delay)
    {
        yield return new WaitForSeconds(delay);
        weaponInstance.gameObject.SetActive(false);
        if (bulletAvailable )
        {
            bulletAvailable = false;
            bulletTime = timer;
            Respawn(currentWeapon, botPosition);
        }

        yield return new WaitForSeconds(1.5f);
        canShoot = false;
    }
    private void Respawn(WeaponType weaponType, Vector3 botPosition)
    {
        SoundManager.Ins.Sound.GunPlayAt();
        Bullet bulletObj = SimplePool.Spawn<Bullet>(GetTypeWeapon(weaponType), SpawnBullet.position, transform.rotation);
        bulletObj.character = this;
        bulletObj.DirectToBot = transform.forward;
        bulletObj.botPosition = botPosition;
        bulletObj.OnInit();
        StartCoroutine(DestroyBullet(bulletObj, radius));
    }

    private IEnumerator DestroyBullet(Bullet bulletObj, float maxDistance)
    {
        Vector3 initialPosition = bulletObj.transform.position;

        while (Vector3.Distance(initialPosition, bulletObj.transform.position) < maxDistance)
        {
            yield return null;
        }
        SimplePool.Despawn(bulletObj);

        bulletAvailable = true;
    }


    private PoolType GetTypeWeapon(WeaponType weaponType)
    {
        switch (weaponType)
        {
            case WeaponType.Arrow:
                return PoolType.Arrow;
            case WeaponType.Axe:
                return PoolType.Axe;
            case WeaponType.Boomerang:
                return PoolType.Boomerang;
            default:
                return 0;
        }
    }

    public override void OnInit()
    {
        GetRandomWeapon();
        GetRandomHat();
        GetRandomPant();
        ChangeState(new PatrolState());
    }

    private void GetRandomWeapon()
    {
        int randWeapIndex = Random.Range(0, DataManager.Ins.weaponData.Length);
        weaponData = DataManager.Ins.weaponData[randWeapIndex];
        if (weaponInstance == null)
        {
            weaponInstance = Instantiate(weaponData.weapon, weaponHoldingPos.position, weaponHoldingPos.rotation, weaponHoldingPos);
        }
        else
        {
            Destroy(weaponInstance.gameObject);
            weaponInstance = Instantiate(weaponData.weapon, weaponHoldingPos.position, weaponHoldingPos.rotation, weaponHoldingPos);
        }
    }

    private void GetRandomHat()
    {
        int randHatIndex = Random.Range(0, DataManager.Ins.hairData.Length);
        hairData = DataManager.Ins.hairData[randHatIndex];

        if (hairInstance == null)
        {
            hairInstance = Instantiate(hairData.hairPrefab, hairPos.position, hairPos.rotation, hairPos);
        }
        else
        {
            Destroy(hairInstance.gameObject);
            hairInstance = Instantiate(hairData.hairPrefab, hairPos);
        }

    }

    private void GetRandomPant()
    {
        int randPantIndex = Random.Range(0, DataManager.Ins.pantData.Length);
        pantData = DataManager.Ins.pantData[randPantIndex];

        if (pantInstance == null)
        {
            pantInstance.material = pantData.PantMaterial;
        }
        else
        {
            pantInstance.material = pantData.PantMaterial;
        }
    }

    private IEnumerator AnimDie()
    {
        ChangeAnim(Constant.ANIM_DIE);
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(Constant.WeaponTag))
        {
            SoundManager.Ins.Sound.DeadPlayAt();
            isDead = true;
            isMoving = false;
            StartCoroutine(AnimDie());
            
            LevelManager.Ins.botList.Remove(gameObject);         
        }    
    }
    void OnDrawGizmos()
    {
        // Vẽ hình cầu để hiển thị vùng không gian
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    public void ChangeState(IState<Bot> state)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);
        }

        currentState = state;

        if (currentState != null)
        {
            currentState.OnEnter(this);
        }
    }
}
