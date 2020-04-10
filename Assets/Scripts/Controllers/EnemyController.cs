using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;

    // public Transform[] waypoints;
    //public int cur = 0;
    public GameObject Bullet;
    public Transform[] points;
    private int destPoint = 0;
    public int enemyHealth = 5;
    public float speed = 10.01f;

    Transform target;
    NavMeshAgent agent;

    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        GotoNextPoint();
    }

    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if(distance <= lookRadius)
        {
            agent.SetDestination(target.position);

            if(distance <= agent.stoppingDistance)
            {

            }
        }
        else
        {
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
                GotoNextPoint();
        }

       
    }


    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }



    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }

    void OnTriggerEnter(Collider Bullet)
    {
        enemyHealth -= 1;

        if(enemyHealth == 0)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    /* void Waypointer()
     {
         if (transform.position != waypoints[cur].position)
         {

             Vector3 p = Vector3.MoveTowards(transform.position, waypoints[cur].position, speed);
             GetComponent<Rigidbody>().MovePosition(p);

         }
         else cur = (cur + 1) % waypoints.Length;
     }*/
}
