using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock2 : MonoBehaviour
{

    float speed;
    float rotationSpeed = 5.0f;
    Vector3 averageHeading;
    Vector3 averagePosition;
    float neighbourDistance = 3.0f;

    public GameObject myManager;
    private FM2 manager;

    public enum std
    {
        OUT,
        IN
    };

    public std state;

    // Start is called before the first frame update
    void Start()
    {
        state = std.OUT;
        speed = Random.Range(0.5f, 1f);
        manager = myManager.GetComponent<FM2>();
    }

    // Update is called once per frame
    void Update()
    {

        switch (state)
        {
            case std.OUT:

                Vector3 direction = manager.gameObject.transform.position - transform.position;
                transform.rotation = Quaternion.Slerp(transform.rotation,
                        Quaternion.LookRotation(direction),
                        rotationSpeed * Time.deltaTime);
                if (Vector3.Distance(transform.position, manager.gameObject.transform.position) < manager.tankSize)
                {
                    speed = (Random.Range(1f, 3f));
                    state = std.IN;
                }


                break;
            case std.IN:
                
                if (Random.Range(0, 5) < 1)
                    ApplyRules();
                if (Vector3.Distance(transform.position, manager.gameObject.transform.position) >= manager.tankSize)
                {
                    speed = Random.Range(0.5f, 1f);
                    state = std.OUT;
                }
                break;
            default:
                break;
        }

        transform.Translate(0, 0, (Time.deltaTime * speed));

    }


    private void ApplyRules()
    {
        GameObject[] gos;
        gos = manager.allFish;

        Vector3 vcentre = manager.gameObject.transform.position;
        Vector3 vavoid = Vector3.zero;
        float gSpeed = 0.1f;

        Vector3 goalPos = manager.goalPos;

        float dist;
        int groupSize = 0;
        foreach (GameObject go in gos)
        {
            if(go != this.gameObject)
            {
                dist = Vector3.Distance(go.transform.position, this.transform.position);
                if (dist < neighbourDistance)
                {
                    vcentre += vavoid + (this.transform.position - go.transform.position);
                }
                Flock2 anotherFlock = go.GetComponent<Flock2>();
                gSpeed = gSpeed + anotherFlock.speed;
            }
        }

        if (groupSize > 0)
        {
            vcentre = vcentre / groupSize + (goalPos - this.transform.position);
            speed = gSpeed / groupSize;

            Vector3 direction = (vcentre + vavoid) - transform.position;
            if (direction != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation,
                    Quaternion.LookRotation(direction),
                    rotationSpeed* Time.deltaTime);
            }
        }
    }
    
}
