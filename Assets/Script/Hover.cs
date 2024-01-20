using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    public Vector3 origin;
    public float amplitude; 
    public float speed;
    public float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        origin = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(origin.x, origin.y + amplitude * Mathf.Sin(Time.time * speed), origin.z);
        gameObject.transform.Rotate(0, rotationSpeed, 0);
    }
}
