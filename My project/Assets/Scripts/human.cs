using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.AI;


public class human : MonoBehaviour
{
     private float timer = 0f;
    private float interval = 5f; //Random.Range(1,3);
    public NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.SetDestination(new UnityEngine.Vector3 (Random.Range(-20f,20f),0f,Random.Range(-20f,20f) ));
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
            agent.SetDestination(new UnityEngine.Vector3 (Random.Range(0f,10f),0f,Random.Range(0f,10f) ));
            //agent.SetDestination(RandomNavmeshLocation(10000f));
            timer = 0f;
        }
    }


public UnityEngine.Vector3 RandomNavmeshLocation(float radius) {
        UnityEngine.Vector3 randomDirection = Random.insideUnitCircle * radius;
        randomDirection += transform.position;
        NavMeshHit hit;
        UnityEngine.Vector3 finalPosition = UnityEngine.Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1)) {
            finalPosition = hit.position;
        }
        return finalPosition;
    }
}