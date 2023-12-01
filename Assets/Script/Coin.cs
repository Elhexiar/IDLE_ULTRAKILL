using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinJump : MonoBehaviour
{
    public Transform origin;
    public Transform target;
    public float jumpForce;
    public float autoDestructionTimer;
    // Start is called before the first frame update
    void Start()
    {
        
            

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Jump()
    {
        StartCoroutine(destryCoin(autoDestructionTimer));
        Vector3 jumpVector = (origin.position - target.position).normalized;
        gameObject.GetComponent<Rigidbody>().AddForce(jumpVector * jumpForce);
    }

    public IEnumerator destryCoin(float timeBeforeDestruction)
    {
        yield return new WaitForSeconds(timeBeforeDestruction);
        Destroy(gameObject);

    }


}
