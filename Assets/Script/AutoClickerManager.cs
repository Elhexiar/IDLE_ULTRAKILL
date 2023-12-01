using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoClickerManager : MonoBehaviour
{
    public ScoreManager ScoreManagerReference;
    public List<bool> AutoClickers;
    public int autoClickAmount;
    public float autoClickTimer;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Autoclick(autoClickAmount, autoClickTimer));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public IEnumerator Autoclick(int amount, float timeToWait)
    {
        while (true)
        {
            Debug.Log("Yo !");
            foreach (var autoclick in AutoClickers) {
                if (autoclick == true)
                {
                    ScoreManagerReference.RaiseTimer(amount);
                }
            }
            
            yield return new WaitForSeconds(timeToWait);
        }

    }
}
    

