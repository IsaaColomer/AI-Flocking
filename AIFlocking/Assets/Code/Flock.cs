using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    public FlocManager myManager;
    public Vector3 direction;
    public float speed;
    public float timeCount;
    public float timeMax;
    public Vector3 d;
    // Start is called before the first frame update
    void Start()
    {
        timeCount = timeMax;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-(Time.deltaTime * speed), 0.0f, 0.0f);

        if (Vector3.Distance(transform.position, Vector3.zero) >= myManager.distanceToCenter)
        {
            Vector3 directionD = Vector3.zero - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(directionD), myManager.rotationSpeed * Time.deltaTime);
        }
        else
        {
            direction = (Cohesion() + Align() + Separation()).normalized * speed;
        }

        Debug.Log((transform.position - myManager.transform.position).magnitude);
    }

    public Vector3 Cohesion()
    {
        Vector3 cohesion = Vector3.zero;
        int num = 0;
        foreach (GameObject go in myManager.allFish)
        {
            if (go != this.gameObject)
            {
                float distance = Vector3.Distance(go.transform.position,
                                                  transform.position);
                if (distance <= myManager.neighbourDistance)
                {
                    cohesion += go.transform.position;
                    num++;
                }
            }
        }
        if (num > 0)
            cohesion = (cohesion / num - transform.position).normalized * speed;

        return cohesion;
    }
    public Vector3 Align()
    {
        Vector3 align = Vector3.zero;
        int num = 0;
        foreach (GameObject go in myManager.allFish)
        {
            if (go != this.gameObject)
            {
                float distance = Vector3.Distance(go.transform.position,
                                                  transform.position);
                if (distance <= myManager.neighbourDistance)
                {
                    align += go.GetComponent<Flock>().direction;
                    num++;
                }
            }
        }
        if (num > 0)
        {
            align /= num;
            speed = Mathf.Clamp(align.magnitude, myManager.minSpeed, myManager.maxSpeed);
        }

        return align;
    }
    public Vector3 Separation()
    {
        Vector3 separation = Vector3.zero;
        foreach (GameObject go in myManager.allFish)
        {
            if (go != this.gameObject)
            {
                float distance = Vector3.Distance(go.transform.position,
                                                  transform.position);
                if (distance <= myManager.neighbourDistance)
                    separation -= (transform.position - go.transform.position) /
                                  (distance * distance);
            }
        }

        return separation;
    }
    public void Hello()
    {
        timeCount -= Time.deltaTime;
        if (timeCount < 0)
        {
            foreach (GameObject go in myManager.allFish)
            {
                direction = (Cohesion() + Align() + Separation()).normalized * speed;
            }
            timeCount = timeMax;
        }
    }

    //public FlocManager myManager;
    //float speed;

    //// Use this for initialization
    //void Start()
    //{
    //    speed = Random.Range(myManager.minSpeed,
    //                            myManager.maxSpeed);

    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    transform.Translate(-Time.deltaTime * speed, 0, 0);
    //    ApplyRules();

    //}
    //void ApplyRules()
    //{
    //    GameObject[] gos;
    //    gos = myManager.allFish;

    //    Vector3 vcentre = Vector3.zero;
    //    Vector3 vavoid = Vector3.zero;
    //    float gSpeed = 0.01f;
    //    float nDistance;
    //    int groupSize = 0;

    //    foreach (GameObject go in gos)
    //    {
    //        if (go != this.gameObject)
    //        {
    //            nDistance = Vector3.Distance(go.transform.position, this.transform.position);
    //            if (nDistance <= myManager.neighbourDistance)
    //            {
    //                vcentre += go.transform.position;
    //                groupSize++;

    //                if (nDistance < 1.0f)
    //                {
    //                    vavoid = vavoid + (this.transform.position - go.transform.position);
    //                }

    //                Flock anotherFlock = go.GetComponent<Flock>();
    //                gSpeed = gSpeed + anotherFlock.speed;
    //            }
    //        }
    //    }

    //    if (groupSize > 0)
    //    {
    //        vcentre = vcentre / groupSize;
    //        speed = gSpeed / groupSize;

    //        Vector3 direction = (vcentre + vavoid) - transform.position;
    //        if (direction != Vector3.zero)
    //            transform.rotation = Quaternion.Slerp(transform.rotation,
    //                                                  Quaternion.LookRotation(direction),
    //                                                  myManager.rotationSpeed * Time.deltaTime);

    //    }
    //}
}
