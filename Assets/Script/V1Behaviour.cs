using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class V1Behaviour : MonoBehaviour
{
    public float timeBeforeAutoDestruct;
    public bool destroy = false;
    public bool leftSide = false;
    public bool rightSide = false;
    public Transform target;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AutoDie());
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed);
    }

     public IEnumerator AutoDie()
    {
        while (true)
        {
            if (destroy == true)
            {
                Destroy(gameObject);
            }
            destroy = true;
            yield return new WaitForSeconds(timeBeforeAutoDestruct);
        }
        
    }
}
