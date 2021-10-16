using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    public FlocManager myManager;
    public bool can;
    public Vector3 direction;
    public static Flock instance;
    public float speed;
    public float freq = 0f;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }
        // Update is called once per frame
    public void Update()
    {
        freq += Time.deltaTime;
        if (freq > 0.1)
        {
            freq -= 0.1f;
            //ChageTheDirectionOfTheFish();
            direction = Lol();
        }
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), myManager.rotationSpeed * Time.deltaTime);
        transform.Translate((Time.deltaTime * speed), 0.0f, 0.0f);
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
    public void ChangeSpeed(float speds)
    {
        speed = speds;
    }
    public Vector3 RecalcuateDirection()
    {
        Vector3 newDistance = Vector3.zero;
        if ((myManager.transform.position - transform.position).magnitude > myManager.limit)
        {
            newDistance = (-(transform.right - (myManager.transform.position - transform.position)));
        }
        else
        {
            newDistance = ((Cohesion() + Align() + Separation()).normalized * (speed));
        }
        return newDistance;
    }
}