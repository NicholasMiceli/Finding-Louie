using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RangedEnemyController : MonoBehaviour
{
    public float lookRadius = 6;
    // public Transform[] waypoints;
    //public int cur = 0;
    public GameObject Bullet;
    public GameObject Emitter;
    public GameObject FloatingTextPrefab;
    public Transform[] points;
    private int destPoint = 0;
    public int enemyHealth = 5;
    public float speed = 10.01f;
    public bool firing = false;
    Gun childScript;
    Transform target;
    NavMeshAgent agent;

    public Animator RangedAnim;

    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        childScript = GetComponent<Gun>();
        // GotoNextPoint();
    }

    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            RangedAnim.SetBool("isREnemyIdle", false);
            RangedAnim.SetBool("isREnemyRunning", true);

            Emitter.GetComponent<Gun>().enabled = true;

            if (distance <= agent.stoppingDistance)
            {
                FaceTarget();

            }
        }
        else
        {
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
                GotoNextPoint();
            Emitter.GetComponent<Gun>().enabled = false;
            RangedAnim.SetBool("isREnemyIdle", true);
            RangedAnim.SetBool("isREnemyRunning", false);
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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            enemyHealth -= 1;

            if (FloatingTextPrefab && enemyHealth > 0)
            {
                ShowFloatingText();
            }

            if (enemyHealth == 0)
            {
                gameObject.SetActive(false);
                Destroy(gameObject);
                Debug.Log("ouch");
            }
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

    void ShowFloatingText()
    {
        var go = Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity, transform);
        go.GetComponent<TextMesh>().text = enemyHealth.ToString();
    }
}
