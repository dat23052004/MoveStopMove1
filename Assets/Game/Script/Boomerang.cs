using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : Bullet
{
    public Transform skin;
    private Player player;
    private bool isReturning = false;
    private Vector3 initialBotPosition;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        if (player == null)
        {
            Debug.LogError("Player not found!");
            return;
        }

        initialBotPosition = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            Debug.LogError("Player not found!");
            return;
        }

        initialBotPosition = player.transform.position;
        float distanceToBot = Vector3.Distance(transform.position, initialBotPosition);
        Debug.Log(distanceToBot);

        if (distanceToBot < 0.1f)
        {
            isReturning = true;
        }

        skin.Rotate(Vector3.forward, Time.deltaTime * 300f);
    }

    public override void OnInit()
    {
        if (!isReturning)
        {
            Moving();
        }
        else
        {
            ReturnPlayer();
        }
    }

    public override void Moving()
    {
        rb.velocity = DirectToBot * speedBullet;
    }

    private void ReturnPlayer()
    {
        if (player == null)
        {
            Debug.LogError("Player not found!");
            return;
        }

        Vector3 directionToPlayer = (initialBotPosition - transform.position).normalized;
        rb.velocity = directionToPlayer * speedBullet;

        if (Vector3.Distance(transform.position, initialBotPosition) < 0.1f)
        {
            isReturning = false;
            rb.velocity = Vector3.zero;
            
        }
    }
}


