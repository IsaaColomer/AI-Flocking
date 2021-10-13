using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlocManager : MonoBehaviour
{
    [Header("Flock Manager")]
    [SerializeField] private GameObject fishPrefab;
    public int numFish;
    public GameObject Cyl;

    public int distanceToCenter;
    [Header("Flock")]
    public GameObject[] allFish;
    public float neighbourDistance;
    public float speed;
    public float rotationSpeed;

    [Header("Timer")]
    public float timeCount;
    public float timeMax;

    public Vector3 swimLimits;
    bool bounded;
    bool randomize;
    bool followLider;
    [SerializeField] GameObject lider;

    [Range(0f, 5f)]
    public float minSpeed;
    [Range(0f, 5f)]
    public float maxSpeed;
    [Range(0f, 5f)]
    public float NeighbourDistance;
    [Range(0f, 5f)]
    public float RotationSpeed;

    public GameObject acumulator;

    // Start is called before the first frame update
    void Start()
    {
        allFish = new GameObject[numFish];
        for (int i = 0; i < numFish; ++i)
        {
            Vector3 pos = this.transform.position + new Vector3(Random.Range(0, swimLimits.x)- swimLimits.x/2, Random.Range(0, swimLimits.y)- swimLimits.y/2, Random.Range(0, swimLimits.z)- swimLimits.z/2); // random position
            Vector3 randomize = new Vector3(Random.Range(1,2), Random.Range(1,2), Random.Range(1,2)).normalized; // random vector direction
            allFish[i] = (GameObject)Instantiate(fishPrefab, pos, Quaternion.LookRotation(randomize),acumulator.transform);
            allFish[i].GetComponent<Flock>().myManager = this;

        }
        timeCount = timeMax;
    }

    // Update is called once per frame
    void Update()
    {
        //Recalculate();

        Hello();
    }

    void Recalculate()
    {

    }

    public void Hello()
    {
        timeCount -= Time.deltaTime;
        if (timeCount < 0)
        {
            for(int i = 0; i< allFish.Length; i++)
            {
                allFish[i].GetComponent<Flock>().speed = speed;

            }
                


            timeCount = timeMax;
        }
    }
    //public GameObject fishPrefab;
    //public int numFish = 20;
    //public GameObject[] allFish;
    //public Vector3 swimLimits = new Vector3(5, 5, 5);
    //public float neighbourDistance;
    //public float rotationSpeed;
    //public GameObject acum;
    //[Header("Fish Settings")]
    //[Range(0.0f, 5.0f)]
    //public float minSpeed;
    //[Range(0.0f, 5.0f)]
    //public float maxSpeed;

    //// Use this for initialization
    //void Start()
    //{
    //    allFish = new GameObject[numFish];
    //    for (int i = 0; i < numFish; i++)
    //    {
    //        Vector3 pos = this.transform.position + new Vector3(Random.Range(-swimLimits.x, swimLimits.x),
    //                                                              Random.Range(-swimLimits.y, swimLimits.y),
    //                                                              Random.Range(-swimLimits.z, swimLimits.z));
    //        allFish[i] = (GameObject)Instantiate(fishPrefab, pos, Quaternion.identity, acum.transform);
    //        allFish[i].GetComponent<Flock>().myManager = this;
    //    }

    //}

    // Update is called once per frame
    //void Update()
    //{

    //}
}
