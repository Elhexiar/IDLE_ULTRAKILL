using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class V1Behaviour : MonoBehaviour
{
    public float timeBeforeAutoDestruct;
    public bool destroy = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AutoDie());
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
