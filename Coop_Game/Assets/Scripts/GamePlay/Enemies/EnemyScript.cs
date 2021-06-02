using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyScript : MonoBehaviour
{
    public float currenthealth = 100;

    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsPlayer, whatIsGround;

    public float RotationSpeed;

    public Vector3 walkPoint;
    public bool walkPointSet;
    public float walkPointRange;

    public float AttackCooldown;
    bool alreadyAttacked;


    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange = false;

    private void Awake()
    {
        player = GameObject.Find("GarryArmed").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();
        if (walkPointSet) agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }

    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if(Physics.Raycast(walkPoint, Vector3.down, 25f , whatIsGround)) walkPointSet = true;
    }

    private void ChasePlayer()
    {
        Vector3 SelfPosition = transform.position;
        Vector3 distanceToPlayer = transform.position - player.position;

        //if (SelfPosition != distanceToPlayer)
        //{
        //    this.transform.Rotate(SelfPosition,)
        //}
        
        agent.SetDestination(player.position);
       

    }
    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);
         
    }

    private void Death()
    {
        if (currenthealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        if (!playerInSightRange && !playerInAttackRange)
        {
            Patroling();
        }
        if (playerInSightRange && !playerInAttackRange) 
        { 
            ChasePlayer(); 
        }
        if (playerInSightRange && playerInAttackRange)
        {
            AttackPlayer();
        }

        //Debug.Log(walkPoint);
        //Debug.Log(walkPointSet);
        Death();
    }








}