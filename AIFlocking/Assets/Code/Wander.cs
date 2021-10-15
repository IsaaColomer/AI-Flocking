using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wander : MonoBehaviour
{
    public BoxCollider floor;
    public NavMeshAgent agent;
    public Transform goToPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Wanderer();
    }

    void Wanderer()
    {
        float radius = 20f;
        float offset = 30f;

        Vector3 localTarget = new Vector3(
        Random.Range(-1.0f, 1.0f), 0,
        Random.Range(-1.0f, 1.0f));
        localTarget.Normalize();
        localTarget *= radius;

        localTarget += new Vector3(0, 0, offset);
        Vector3 worldTarget =
            transform.TransformPoint(localTarget);
        worldTarget.y = 0f;
        if (floor.bounds.Contains(worldTarget))
        {
            agent.destination = worldTarget;
        }
        else
        {
            agent.destination = -worldTarget;
        }
        goToPoint.transform.position = worldTarget;
    }
}

