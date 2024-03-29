using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IState<Bot>
{
    private float patrolDuration = 3f; // Time to patrol in seconds
    private float patrolTimer;
    private bool ingame = GameManager.IsState(GameState.Gameplay);
    public void OnEnter(Bot bot)
    {
        // Initialize patrol behavior
        bot.walkPointSet = false;
        patrolTimer = 0f;

        // Start patrolling
        if (ingame)
        {
            Patrol(bot);
        }

    }

    public void OnExecute(Bot bot)
    {
        // Continue patrolling
        Patrol(bot);

        patrolTimer += Time.deltaTime;
        if (patrolTimer >= patrolDuration)
        {
            //bot.isMovingDuringDelay = false;
            bot.ChangeState(new IdleState());
        }
    }

    public void OnExit(Bot bot)
    {

    }

    private void Patrol(Bot bot)
    {
        if (!bot.walkPointSet)
        {
            SearchWalkPoint(bot);
        }
        else
        {
            bot.navMeshAgent.SetDestination(bot.walkPoint);
            if (Vector3.Distance(bot.transform.position, bot.walkPoint) < 1f)
            {
                bot.walkPointSet = false;
            }
                
            // Check if the bot is moving
            if (bot.navMeshAgent.velocity.magnitude > 0.1f)
            {
                bot.isMoving = true;
                bot.ChangeAnim(Constant.ANIM_RUN);
            }
            else
            {
                bot.isMoving = false;
                bot.ChangeAnim(Constant.ANIM_IDLE);
            }
        }
    }

    private void SearchWalkPoint(Bot bot)
    {
        // Generate random walk point within range
        float randomX = Random.Range(-bot.walkPointRange, bot.walkPointRange);
        float randomZ = Random.Range(-bot.walkPointRange, bot.walkPointRange);

        bot.walkPoint = new Vector3(bot.transform.position.x + randomX, bot.transform.position.y, bot.transform.position.z + randomZ);

        bot.navMeshAgent.SetDestination(bot.walkPoint);
        bot.walkPointSet = true;
    }
}
