using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinThrower : MonoBehaviour
{
    public GameObject coinPrefab;
    public Transform target;
    public ScoreManager scoreManagerRef;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ThrowACoin()
    {
        GameObject currentCoin = Instantiate(coinPrefab, gameObject.transform.position, gameObject.transform.rotation);
        currentCoin.GetComponent<CoinJump>().scoreManagerReference = scoreManagerRef;
        currentCoin.GetComponent<CoinJump>().origin = gameObject.transform;
        currentCoin.GetComponent<CoinJump>().target = target;
        currentCoin.GetComponent<CoinJump>().Jump();
        
    }
}
