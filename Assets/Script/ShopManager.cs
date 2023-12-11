using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public ScoreManager scoreManager;
    public AutoClickerManager autoClickerManager;
    public CoinThrower leftCoinThrower;
    public CoinThrower rightCoinThrower;
    public TextMeshProUGUI CoinMultiplierTextRef, coinMultiplierPriceTextRef;
    public int coinMultiplier = 1;
    public int coinMultiplierPrice = 20;

    // Start is called before the first frame update
    void Start()
    {
        CoinMultiplierTextRef.text = coinMultiplier.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuyAV1()
    {
        autoClickerManager.AutoClickers.Add(true);

    }

    public void IncreaseCoinMultiplier()
    {
        if (scoreManager.score >= coinMultiplierPrice)
        {
            scoreManager.score -= coinMultiplierPrice;
            scoreManager.UpdateUI();

            coinMultiplier++;
            CoinMultiplierTextRef.text = coinMultiplier.ToString();
            leftCoinThrower.amoutToRaise = coinMultiplier;
            rightCoinThrower.amoutToRaise = coinMultiplier;
            coinMultiplierPrice = coinMultiplierPrice + coinMultiplierPrice * coinMultiplier;
            coinMultiplierPriceTextRef.text = coinMultiplierPrice.ToString();
        }
        



    }
}
