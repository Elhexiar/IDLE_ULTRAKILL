using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoClickerManager : MonoBehaviour
{
    public ScoreManager ScoreManagerReference;
    public List<bool> AutoClickers;
    public List<Ennemie> EnnemiesList;
    public List<EnnemieClicker> EnnemieClickerList;

    public int autoClickAmount;
    public float autoClickTimer;
    public CoinThrower leftCoinThrower;
    public CoinThrower rightCoinThrower;
    public float timeOffset;
    public bool alternate;
    public bool leftSideSelected;
    public bool rightSideSelected;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Autoclick(autoClickAmount, autoClickTimer, timeOffset));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Autoclick(int amount, float timeToWait, float timeOffset)
    {
        while (true)
        {
            //Debug.Log("Yo !");
            foreach (var autoclick in AutoClickers) {
                if (autoclick == true)
                {
                    int selector = Random.Range(0, 2);
                    
                    //ScoreManagerReference.RaiseTimer(amount);

                    Debug.Log("Sending V1");
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
    

