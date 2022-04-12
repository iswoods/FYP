using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    bool foundPlayer = false;
    

    NavMeshAgent agent;
    Animator anim;

    public Transform target;
    float speed;
    float distance;

    public Transform[] wayPoints;
    int wayPointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        foundPlayer = false;
        
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        speed = 0;



    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(target.transform.position, this.transform.position);
        if(distance < 3f)
        {
            anim.Play("Attack01");
        }

        speed = agent.speed;
        anim.SetFloat("speed",speed);



       /* RaycastHit hit;
        if (Physics.SphereCast(es.eyes.position, es.radius, es.eyes.forward, out hit, es.maxDistance) && hit.collider.CompareTag("Player"))
        {
            foundPlayer = true;
        }
        */
        if (foundPlayer == false)
        {                                
            Patrol();                     
            
        }
        if(foundPlayer == true)
        {
            agent.destination = target.position;
            agent.stoppingDistance = 3f;
        }
        
    }

    void Patrol()
    {
        if(wayPoints.Length == 0)
        {
            return;
        }

        agent.destination = wayPoints[wayPointIndex].position;

        if(agent.remainingDistance < 4f && !agent.pathPending)
        {
           
            wayPointIndex = (wayPointIndex + 1) % wayPoints.Length;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            foundPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            foundPlayer = false;
        }
        
    } 

    public void PlayDeath()
    {
        anim.SetBool("Death", true);
        agent.enabled = false;
        this.enabled = false;
    }
}
