using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinThrower : MonoBehaviour
{
    public ScoreManager scoreManagerRef;

    public GameObject coinPrefab;
    public GameObject v1Prefab;

    public Transform target, correspondingSpawn, correspondingTarget;
    
    public int amoutToRaise = 1;

    public TextMeshProUGUI coinMultiplierText;

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
        GameObject V1 = Instantiate(v1Prefab);
        V1.GetComponent<V1Behaviour>().target = correspondingTarget;
    }
}
