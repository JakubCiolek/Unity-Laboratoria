using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class human : MonoBehaviour
{
     private float timer = 0f;
    private float interval = 2f; //Random.Range(1,3);
    public NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
        move();
    }

    void move()
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            agent.SetDestination(RandomNavmeshLocation(1000f));
            timer = 0f;
        }
    }


public Vector3 RandomNavmeshLocation(float radius) {
        Vector3 randomDirection = Random.insideUnitCircle * radius;
        randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1)) {
            finalPosition = hit.position;
        }
        return finalPosition;
    }
}
