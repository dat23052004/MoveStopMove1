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
    private Coroutine shootingCoroutine;
    //private bool isRandomMovementActive = true;
    private IState<Bot> currentState;
    public Vector3 walkPoint;
    public bool walkPointSet;
    public float walkPointRange;
    private void Start()
    {
        //navMeshAgent = GetComponent<NavMeshAgent>();
        //StartCoroutine(MovingToTarget());
        //StartCoroutine(RandomMovement());
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
                if (shootingCoroutine == null)
                {
                    Shoot(enemyPosition, 0.3f);  // 0.3f là thời gian delay để changeaim
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
    public void Shoot(Vector3 botPosition, float delay)
    {
        // Kiểm tra xem có coroutine nào đang chạy hay không
        if (shootingCoroutine == null)
        {
            // Khởi tạo coroutine và gán tham chiếu vào biến
            shootingCoroutine = StartCoroutine(ShootCoroutine(botPosition, delay));
        }
        else
        {
            Debug.Log("Coroutine is already running");
        }
    }

    public IEnumerator ShootCoroutine(Vector3 botPosition, float delay)
    {
        yield return new WaitForSeconds(delay);
        weaponInstance.gameObject.SetActive(false);
        if (bulletAvailable)
        {
            bulletAvailable = false;
            bulletTime = timer;
            Respawn(currentWeapon, botPosition);
        }

        // Coroutine đã hoàn thành, đặt biến tham chiếu thành null
        yield return new WaitForSeconds(2f);
        shootingCoroutine = null;
    }

    private void Respawn(WeaponType weaponType, Vector3 botPosition)
    {
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
        if(other.CompareTag("Weapon"))
        {
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

    //private IEnumerator MovingToTarget()
    //{
    //    while (isRandomMovementActive)
    //    {
    //        Vector3 randomDestination = GetRandomDestination();
    //        // Di chuyển bot đến điểm đó
    //        navMeshAgent.SetDestination(randomDestination);

    //        // Chờ đợi cho đến khi bot đến điểm đích
    //        while (navMeshAgent.pathPending || navMeshAgent.remainingDistance > navMeshAgent.stoppingDistance)
    //        {               
    //            isMoving = true;
    //            yield return null;  
    //        }
    //        isMoving = false;
    //        yield return new WaitForSeconds(1);
    //        //StopRandomMovement();
    //        //isMoving = false;
    //    }
    //    isRandomMovementActive = true;
    //}

    //private Vector3 GetRandomDestination()
    //{
    //    if (level.pointList.Count > 0)
    //    {
    //        int randomIndex = Random.Range(0, level.pointList.Count);
    //        return level.pointList[randomIndex];
    //    }
    //    else
    //    {
    //        Debug.LogError("No points available in the level.pointList.");
    //        // Nếu không có điểm nào trong danh sách, trả về vị trí hiện tại của bot
    //        return transform.position;
    //    }
    //}
    //private IEnumerator RandomMovement()
    //{
    //    while (isRandomMovementActive)
    //    {
    //        if (isMoving)
    //        {
    //            // Tính thời gian ngẫu nhiên để đứng lại (từ 4 đến 6 giây)
    //            float standStillTime = Random.Range(2f, 4f);

    //            // Đứng lại
    //            isMoving = false;

    //            // Chờ thời gian đứng lại (1.5 giây)
    //            yield return new WaitForSeconds(1.5f);

    //            // Tiếp tục di chuyển
    //            isMoving = true;

    //            // Chờ thời gian di chuyển (tính từ thời gian đứng lại)
    //            yield return new WaitForSeconds(standStillTime - 1.5f);
    //        }
    //        else
    //        {
    //            // Nếu không di chuyển, chờ một lúc trước khi kiểm tra lại
    //            yield return new WaitForSeconds(0.1f);
    //        }
    //    }
    //}