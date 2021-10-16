using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FlocManager : MonoBehaviour
{
    [Header("Flock Manager")]
    [SerializeField] private GameObject fishPrefab;
    public int numFish;
    [Range(1f, 10f)]
    public int limit;
    public int limitMin;
    [Header("Flock")]
    public GameObject[] allFish;
    public float neighbourDistance;
    public float speed;
    public float rotationSpeed;

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
            allFish[i] = (GameObject)Instantiate(fishPrefab, pos, Quaternion.LookRotation(randomize), acumulator.transform);
            allFish[i].GetComponent<Flock>().myManager = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < numFish; ++i)
        {
            speed = Flock.instance.speed;
        }        
    }

}
