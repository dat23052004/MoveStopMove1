﻿using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public enum Weapon
{
    Arrow = 0,
    Axe = 1,
    Boomerang =2 ,
}
public class Player : Character
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private FloatingJoystick joystick;

    [SerializeField]private LayerMask groundLayer;
    private bool isMoving = false;
    
    [SerializeField] List<Weapon> weapons;
    private Weapon currentWeapon = Weapon.Axe;
    //List<Vector3> botPositions = new List<Vector3>();

    private Coroutine shootingCoroutine;
    private bool isMovingDuringDelay = false;
    private void Start()
    {
        ChangeAnim("Idle");
        
    }
    private void Update()
    {
        
        Moving();
        CheckSight();
        
        //Debug.Log(bulletAvailable);
    }
    public void Moving()
    {
        Vector3 movement = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
        Vector3 velocity = movement * moveSpeed;
        RaycastHit hit;
        Vector3 raycastOrigin = transform.position + transform.forward * 0.7f;
        if (Physics.Raycast(raycastOrigin, Vector3.down, out hit, 5f, groundLayer))
        {
            rb.velocity = new Vector3(velocity.x, rb.velocity.y, velocity.z);
            isMoving = movement.magnitude > 0;
            ChangeAnim("Run");         
        }
        else
        {
            rb.velocity = Vector3.zero; ;
            ChangeAnim("Idle");
            
            isMoving = false;
        }

        if (movement.magnitude > 0)
        {
            transform.rotation = Quaternion.LookRotation(movement);
            isMovingDuringDelay = true;
        }
        else
        {
            isMovingDuringDelay = false;
        }

    }
    
    public void CheckSight()
    {
        if (!isMoving)
        {
            ChangeAnim("Idle");
            Debug.Log("Idle");          
            if (CheckPosition(out Vector3 botPosition))
            {
                Debug.Log(1);
                ChangeAnim("Attack");
                Debug.Log(shootingCoroutine);
                if (shootingCoroutine == null)
                {
                    Debug.Log(2);
                    Shoot(botPosition,0.2f);
                }
                else
                {
                    Debug.Log(shootingCoroutine);
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
            if ( collider.gameObject != gameObject && collider.CompareTag("Character"))
            {
                
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
        Debug.Log("Despawn1");
        bulletAvailable = true;
    }
    //public IEnumerator Shoot(Vector3 botPosition, float delay)
    //{

    //    yield return new WaitForSeconds(delay);
    //    if (bulletAvailable && !isMovingDuringDelay)
    //    {
    //        bulletAvailable = false;
    //        bulletTime = timer;
    //        Respawn(currentWeapon, botPosition);
    //        Debug.Log("Shoot");
    //        shootingCoroutine = null;
    //        Debug.Log(3);
    //    }              
    //}

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

    private IEnumerator ShootCoroutine(Vector3 botPosition, float delay)
    {
        yield return new WaitForSeconds(delay);

        if (bulletAvailable && !isMovingDuringDelay)
        {
            bulletAvailable = false;
            bulletTime = timer;
            Respawn(currentWeapon, botPosition);
            Debug.Log("Shoot");
        }

        // Coroutine đã hoàn thành, đặt biến tham chiếu thành null
        shootingCoroutine = null;
        Debug.Log(3);
    }

    private void Respawn(Weapon weaponType, Vector3 botPosition)
    {
        Debug.Log("Rsp");
        Vector3 directionToBot = (botPosition - transform.position).normalized;
        transform.rotation = Quaternion.LookRotation(directionToBot);    
        Bullet bulletObj = SimplePool.Spawn<Bullet>(GetTypeWeapon(weaponType), SpawnBullet.position, transform.rotation);
        Debug.Log("Respawn");
        bulletObj.character = this;
        bulletObj.DirectToBot = transform.forward;
        bulletObj.botPosition = botPosition;
        bulletObj.OnInit();
        StartCoroutine(DestroyBullet(bulletObj, radius));
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapon"))
        {
            UIManager.Ins.OpenUI<Lose>();
            GameManager.ChangeState(GameState.Lose);
            Time.timeScale = 1;            
        }
    }
}
