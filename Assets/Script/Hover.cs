using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    public Vector3 origin;
    public float amplitude; 
    // Start is called before the first frame update
    void Start()
    {
        origin = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(origin.x, origin.y, origin.z + amplitude* Mathf.Sin(Time.time));
    }
}
