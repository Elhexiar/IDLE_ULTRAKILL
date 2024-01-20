using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AutoSenderManager : MonoBehaviour
{
    public ScoreManager ScoreManagerReference;
    public List<bool> autoSendersList;
    
    public float autoSendTimer;
    public float timeOffset;
    public CoinThrower leftCoinThrower;
    public CoinThrower rightCoinThrower;
    

    public bool leftSideSelected;
    public bool rightSideSelected;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AutoSend(autoSendTimer, timeOffset));
    }


    public IEnumerator AutoSend(float timeToWait, float timeOffset)
    {
        while (true)
        {
            // each time i buy a V1 i add a new boolean into this list, i then check here to see if it is active
            // if so then i send a V1 which in turn sends a coin. its done this way in case i wanted to keep track of the coins and if i wanted to, deactivate them
            // the addition of new booleans is done in the ShopManager and should have been done here in indsight
            foreach (var autoclick in autoSendersList) {
                if (autoclick == true)
                {
                    int selector = Random.Range(0, 2);

                    if (selector == 0) { leftSideSelected = true; leftCoinThrower.SendV1(); }
                    if (selector == 1) { leftSideSelected = false; rightCoinThrower.SendV1(); }
                    
                    StartCoroutine(CoinSendingRoutine(timeOffset, selector));
                    
                }
            }
            
            yield return new WaitForSeconds(timeToWait);
        }

    }

    public IEnumerator CoinSendingRoutine(float timeOffset, int selector)
    {

        yield return new WaitForSeconds(timeOffset);

        if (selector == 0) { leftSideSelected = true; leftCoinThrower.ThrowACoin(); }
        if (selector == 1) { leftSideSelected = false; rightCoinThrower.ThrowACoin(); }
    }


     
}
    

