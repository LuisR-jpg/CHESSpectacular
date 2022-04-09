using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;
    bool alreadyAttacked;
    public float sightRange;
    public bool playerInSightRange, playerInAttackRange;
    public int hp = 3;
    private void Awake(){
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update(){
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        if(!playerInSightRange) Patroling();
        else ChasePlayer();
    }
    private void Patroling(){
        if(!walkPointSet) SearchWalkPoint();
        else 
        {
            agent.SetDestination(walkPoint);
        }
        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        if(distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint(){
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        if(Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }
    private void ChasePlayer() {
        agent.SetDestination(player.position);
    }   
    public void OnTriggerEnter(Collider other){
        if(other.tag == "Weapon") {
            if(--hp == 0) {
                Destroy(this.gameObject);
            }
            gameObject.transform.GetChild(0).GetComponent<Rigidbody>().AddForce(transform.up * 5f, ForceMode.Impulse);;
            GameObject weapon = GameObject.Find("PlayerSword");
            weapon.tag = "Untagged";
        }
    }
}
