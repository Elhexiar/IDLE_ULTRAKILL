using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinThrower : MonoBehaviour
{
    public GameObject coinPrefab;
    public Transform target;
    public ScoreManager scoreManagerRef;
    public int amoutToRaise = 1;
    public Transform correspondingSpawn;
    public GameObject V1Prefab;

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
        currentCoin.GetComponent<CoinPlayerInteraction>().scoreManagerReference = scoreManagerRef;
        currentCoin.GetComponent<CoinPlayerInteraction>().amount = amoutToRaise;
        currentCoin.GetComponent<CoinJump>().origin = gameObject.transform;
        currentCoin.GetComponent<CoinJump>().target = target;
        currentCoin.GetComponent<CoinJump>().Jump();
        
        
    }

    public void SendV1()
    {
        GameObject V1 = Instantiate(V1Prefab, correspondingSpawn);
    }
}
