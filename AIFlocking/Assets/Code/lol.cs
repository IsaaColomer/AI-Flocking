using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lol : MonoBehaviour
{
    public Camera main;
    public GameObject center;
    private float time0;
    // Start is called before the first frame update
    void Start()
    {
        time0 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //time0 += Time.deltaTime;
        //if(time0 < 10f)
        //{
        //    Camera.main.transform.RotateAround(center.transform.position, new Vector3(0, -1, 0), Time.deltaTime * 50);
        //}
        //if(time0 > 10f)
        //{
        //    Camera.main.transform.RotateAround(center.transform.position, new Vector3(1, 0, 0), Time.deltaTime * 50);
        //}
        //if (time0 > 20f)
        //{
        //    Camera.main.transform.RotateAround(center.transform.position, new Vector3(0, 0, 1), Time.deltaTime * 50);
        //}
        //if(time0 > 30f)
        //{
        //    Application.Quit();
        //}
    }
}
