using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FM3 : MonoBehaviour
{
    [SerializeField] private GameObject fishPrefab;

    [Range(3f, 10f)]
    public float tankSize = 70f;
    public int numfish = 1;
    public GameObject[] allFish;

    public Vector3 goalPos = Vector3.zero;
    public Transform acumulator;
    // Start is called before the first frame update
    void Start()
    {
        goalPos = this.transform.position;
        allFish = new GameObject[numfish];
        for (int i = 0; i < numfish; i++)
        {
            Vector3 pos = new Vector3(
                Random.Range(-tankSize, tankSize),
                Random.Range(-tankSize, tankSize),
                Random.Range(-tankSize, tankSize));
            allFish[i] = (GameObject)Instantiate(fishPrefab,pos,Quaternion.identity);

            allFish[i].GetComponent<fShark>().myManager = this.gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {

       if (Random.Range(0,100) < 2)
       {
            goalPos = new Vector3(
                Random.Range(-tankSize, tankSize),
                Random.Range(-tankSize, tankSize),
                Random.Range(-tankSize, tankSize));
       }
    }
}
