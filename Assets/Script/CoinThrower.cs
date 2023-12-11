using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinThrower : MonoBehaviour
{
    public GameObject coinPrefab;
    public Transform target;
    public ScoreManager scoreManagerRef;
    public int amoutToRaise = 1;
    public Transform correspondingSpawn, correspondingTarget;

    public TextMeshProUGUI coinMultiplierText;
    
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
        currentCoin.GetComponent<CoinBehavior>().scoreManagerReference = scoreManagerRef;
        currentCoin.GetComponent<CoinPlayerInteraction>().scoreManagerReference = scoreManagerRef;
        currentCoin.GetComponent<CoinPlayerInteraction>().amount = amoutToRaise;
        currentCoin.GetComponent<CoinBehavior>().origin = gameObject.transform;
        currentCoin.GetComponent<CoinBehavior>().target = target;
        currentCoin.GetComponent<CoinBehavior>().Jump();
        
        
    }

    public void SendV1()
    {
        GameObject V1 = Instantiate(V1Prefab);
        V1.GetComponent<V1Behaviour>().target = correspondingTarget;
    }
}
