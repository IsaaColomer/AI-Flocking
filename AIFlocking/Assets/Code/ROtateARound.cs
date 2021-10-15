using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ROtateARound : MonoBehaviour
{
    public static ROtateARound instance;
    public float speed;
    public Transform center;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(center.position, new Vector3(0, 1, 0), -(45 * Time.deltaTime * speed));
    }
}
