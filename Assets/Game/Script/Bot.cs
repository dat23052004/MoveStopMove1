using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UIElements;

public class Bot : Character
{
    private NavMeshAgent navMeshAgent;
    
    public Level level;
    
    private bool isMoving = false;
    private Weapon currentWeapon = Weapon.Arrow;

    private bool isRandomMovementActive = true;
        
    private void Start()
    {
        
        ChangeAnim("Idle");
        navMeshAgent = GetComponent<NavMeshAgent>();
        StartCoroutine(MovingToTarget());
        StartCoroutine(RandomMovement());      
    }   

    private void Update()
    {
        CheckSight();
    }

    private IEnumerator MovingToTarget()
    {
        Debug.Log(level.pointList.Count);

        for (int i = 0; i < level.pointList.Count; i++)
        {
            Debug.Log(level.pointList[i]);
            
            // Di chuyển bot đến điểm đó
            navMeshAgent.SetDestination(level.pointList[i]);

            // Chờ đợi cho đến khi bot đến điểm đích
            while (navMeshAgent.pathPending || navMeshAgent.remainingDistance > navMeshAgent.stoppingDistance)
            {
                ChangeAnim("Run");
                isMoving =false;
                yield return null;
            }

            yield return new WaitForSeconds(1);
            StopRandomMovement();
            //isMoving = false;
        }
        isRandomMovementActive = false;
    }
    private IEnumerator RandomMovement()
    {
        while (isRandomMovementActive)
        {
            if (isMoving)
            {
                // Tính thời gian ngẫu nhiên để đứng lại (từ 4 đến 6 giây)
                float standStillTime = Random.Range(4f, 6f);

                // Đứng lại
                isMoving = false;

                // Chờ thời gian đứng lại (1.5 giây)
                yield return new WaitForSeconds(1.5f);

                // Tiếp tục di chuyển
                isMoving = true;

                // Chờ thời gian di chuyển (tính từ thời gian đứng lại)
                yield return new WaitForSeconds(standStillTime - 1.5f);
            }
            else
            {
                // Nếu không di chuyển, chờ một lúc trước khi kiểm tra lại
                yield return new WaitForSeconds(0.1f);
            }
        }
    }


    private void StopRandomMovement()
    {
        isRandomMovementActive = false;
    }
    public void CheckSight()
    {
        if (!isMoving)
        {

            //Debug.Log("!Moving");
            if (CheckPosition(out Vector3 botPosition))
            {

                Shoot();
                //Debug.Log("Shoot");
            }
            else
            {
                ChangeAnim("Idle");
            }
        }
    }
    public bool CheckPosition(out Vector3 position)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        position = Vector3.zero;
        foreach (Collider collider in colliders)
        {
            if ( collider.gameObject != gameObject  && collider.CompareTag("Character"))
            {
                //Debug.LogWarning("Bot");
                position = collider.transform.position;
                //botPositions.Add(position);
                return true;  // Trả về true nếu tìm thấy bot
            }
        }

        return false;
    }
    private IEnumerator DestroyBullet(Bullet bulletObj, float maxDistance)
    {
        Vector3 initialPosition = bulletObj.transform.position;

        while (Vector3.Distance(initialPosition, bulletObj.transform.position) < maxDistance)
        {
            yield return null;
        }
        SimplePool.Despawn(bulletObj);
        //Debug.Log("Despawn");
        bulletAvailable = true;
    }
    public void Shoot()
    {
        if (bulletAvailable)
        {
            bulletAvailable = false;
            bulletTime = timer;
            ChangeAnim("Attack");
            Respawn(currentWeapon);

            //Debug.Log("Shoot");
        }

    }


    private void Respawn(Weapon weaponType)
    {
        Vector3 directionToBot = Vector3.zero;
        if (CheckPosition(out Vector3 botPosition))
        {
            directionToBot = (botPosition - transform.position).normalized;

        }
        else
        {
            return;
        }
        transform.rotation = Quaternion.LookRotation(directionToBot);
        //Quaternion bulletRotation = Quaternion.LookRotation(directionToBot);
        Bullet bulletObj = SimplePool.Spawn<Bullet>(GetTypeWeapon(weaponType), SpawnBullet.position, transform.rotation);
        bulletObj.character = this;
        ChangeAnim("Attack");
        bulletObj.DirectToBot = transform.forward;
        bulletObj.botPosition = botPosition;
        bulletObj.OnInit();
        //bulletObj.Moving(directionToBot, speedBullet);
        StartCoroutine(DestroyBullet(bulletObj, radius));
        //Debug.Log("Respawn");

    }

    private PoolType GetTypeWeapon(Weapon weaponType)
    {
        switch (weaponType)
        {
            case Weapon.Arrow:
                return PoolType.Arrow;
            case Weapon.Axe:
                return PoolType.Axe;
            case Weapon.Boomerang:
                return PoolType.Boomerang;
            default:
                return 0;
        }
    }

    void OnDrawGizmos()
    {
        // Vẽ hình cầu để hiển thị vùng không gian
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
