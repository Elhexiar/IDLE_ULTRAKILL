using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehavior : MonoBehaviour
{
    public Transform origin;
    public Transform target;
    public float jumpForce;
    public float autoDestructionTimer;
    public ScoreManager scoreManagerReference;
    public int value =  1;
    public float randomLowHeightOffset = -5f;
    public float randomHighHeightOffset = 5f;

    public void Jump()
    {
        // Launching a new coroutine to destroy each coin is not good for performance with a lot of coins
        // i should store the coins in a list and just destroy them by wave each time a new coin wave is thrown
        StartCoroutine(destryCoin(autoDestructionTimer));
        Vector3 jumpVector = (origin.position - (target.position + Vector3.up * Random.Range(randomLowHeightOffset, randomHighHeightOffset))).normalized;
        gameObject.GetComponent<Rigidbody>().AddForce(jumpVector * jumpForce);
    }

    public IEnumerator destryCoin(float timeBeforeDestruction)
    {
        yield return new WaitForSeconds(timeBeforeDestruction);
        Destroy(gameObject);

    }

}
