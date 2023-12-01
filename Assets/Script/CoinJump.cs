using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinJump : MonoBehaviour
{
    public Transform origin;
    public Transform target;
    public float jumpForce;
    public float autoDestructionTimer;
    public ScoreManager scoreManagerReference;
    public int value =  1;
    public float randomLowHeightOffset = -5f;
    public float randomHighHeightOffset = 5f;

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
        Vector3 jumpVector = (origin.position - (target.position + Vector3.up * Random.Range(randomLowHeightOffset, randomHighHeightOffset))).normalized;
        gameObject.GetComponent<Rigidbody>().AddForce(jumpVector * jumpForce);
    }

    public IEnumerator destryCoin(float timeBeforeDestruction)
    {
        yield return new WaitForSeconds(timeBeforeDestruction);
        Destroy(gameObject);

    }

    private void OnMouseDown()
    {
        scoreManagerReference.RaiseTimer(value);
        Destroy(gameObject);
    }


}
