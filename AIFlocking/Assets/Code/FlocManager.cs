using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FlocManager : MonoBehaviour
{
    [Header("Flock Manager")]
    [SerializeField] private GameObject fishPrefab;
    public int numFish;
    public int limit;
    public int limitMin;
    public float initialY;
    public float sphereLimit;
    public GameObject wanderer;
    [Header("Flock")]
    public GameObject[] allFish;
    public float neighbourDistance;
    public float speed;
    public float rotationSpeed;
    public float distanceToShark;
    public bool evading;

    [Header("Timer")]
    public float timeCount;
    public float timeMax;

    public Vector3 swimLimits;
    bool bounded;
    bool randomize;
    bool followLider;
    [SerializeField] GameObject lider;

    public float[] yPos;
    [Range(0f, 5f)]
    public float minSpeed;
    [Range(0f, 5f)]
    public float maxSpeed;
    [Range(0f, 5f)]
    public float NeighbourDistance;
    [Range(0f, 5f)]
    public float RotationSpeed;

    private NavMeshAgent agent;
    public GameObject acumulator;

    // Start is called before the first frame update
    void Start()
    {
        allFish = new GameObject[numFish];
        yPos = new float[numFish];
        for (int i = 0; i < numFish; ++i)
        {
            Vector3 pos = this.transform.position + new Vector3(Random.Range(0, swimLimits.x)- swimLimits.x/2, Random.Range(0, swimLimits.y)- swimLimits.y/2, Random.Range(0, swimLimits.z)- swimLimits.z/2); // random position
            Vector3 randomize = new Vector3(Random.Range(1,2), Random.Range(1,2), Random.Range(1,2)).normalized; // random vector direction
            allFish[i] = (GameObject)Instantiate(fishPrefab, pos, Quaternion.LookRotation(randomize), acumulator.transform);
            yPos[i] = allFish[i].transform.position.y;
            allFish[i].GetComponent<Flock>().myManager = this;
        }
        agent = GetComponent<NavMeshAgent>();
        timeCount = timeMax;
        wanderer = GameObject.FindGameObjectWithTag("Shark");
    }

    // Update is called once per frame
    void Update()
    {
        speed = Flock.instance.speed;
        //Recalculate();
        Evade();
        //Hello();
        Debug.Log((fShark.instance.transform.position - transform.position).magnitude);
    }

    void Recalculate()
    {

    }
    void Evade()
    {
        if((fShark.instance.transform.position - transform.position).magnitude <= distanceToShark)
        {
            evading = true;
            Vector3 targetDir = transform.position - (wanderer.transform.position - transform.position);
            float lookAhead = targetDir.magnitude / agent.speed;
            agent.destination = (-wanderer.transform.position - wanderer.transform.forward * lookAhead);
        }
        else
        {
            evading = false;
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
