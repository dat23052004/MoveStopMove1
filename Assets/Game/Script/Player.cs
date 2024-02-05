using System.Collections;
using System.Collections.Generic;
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
    [SerializeField] private LayerMask groundLayer;
    private bool isMoving = false;
    
    [SerializeField] List<Weapon> weapons;
    private Weapon currentWeapon = Weapon.Axe;
    List<Vector3> botPositions = new List<Vector3>();
   
   


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

        }

    }
    
    public void CheckSight()
    {
        if (!isMoving)
        {
            ChangeAnim("Idle");
            
            //Debug.Log("!Moving");
            if (CheckPosition(out Vector3 botPosition))
            {
                
                Shoot();
                //Debug.Log("Shoot");
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
                Debug.LogWarning("Bot");
                position = collider.transform.position;
                Debug.Log(position);
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
        Debug.Log("Despawn");
        bulletAvailable = true;
    }
    public void Shoot()
    {
        if (bulletAvailable)
        {
            bulletAvailable = false;
            bulletTime = timer;
            
            StartCoroutine(SpawnBulletDelayed(currentWeapon, 0.3f));
      
            Debug.Log("Shoot");
        }
                
    }

    private IEnumerator SpawnBulletDelayed(Weapon weaponType, float delay)
    {
        yield return new WaitForSeconds(delay);

        Respawn(weaponType);

        Debug.Log("Bullet Spawned after delay");
    }
    private void Respawn(Weapon weaponType)
    {
        if(!isMoving)
        {
            
            Debug.Log(1);
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
            ChangeAnim("Attack");
            bulletObj.character = this;
            bulletObj.DirectToBot = transform.forward;
            bulletObj.botPosition = botPosition;
            bulletObj.OnInit();
            //bulletObj.Moving(directionToBot, speedBullet);
            StartCoroutine(DestroyBullet(bulletObj, radius));
            Debug.Log("Respawn");
        }
       
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
