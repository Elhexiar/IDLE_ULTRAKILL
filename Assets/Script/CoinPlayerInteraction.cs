using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPlayerInteraction : MonoBehaviour
{
    public ScoreManager scoreManagerReference;
    public int amount;
    public List<AudioSource> shotSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        scoreManagerReference.RaiseTimer(amount);
        Destroy(gameObject);
        Debug.Log("YEP");
    }
}
