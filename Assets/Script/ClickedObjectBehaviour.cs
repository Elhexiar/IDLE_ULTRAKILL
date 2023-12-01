using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickedObjectBehaviour : MonoBehaviour
{
    public  ScoreManager scoreManagerReference;
    public int clickValue;
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
        scoreManagerReference.RaiseTimer(clickValue);
    }
}
