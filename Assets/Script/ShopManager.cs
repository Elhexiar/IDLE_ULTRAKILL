using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public ScoreManager scoreManager;
    public AutoSenderManager autoClickerManager;
    public CoinThrower leftCoinThrower;
    public CoinThrower rightCoinThrower;
    public TextMeshProUGUI CoinMultiplierTextRef, coinMultiplierPriceTextRef;
    public int coinMultiplier = 1;
    public int coinMultiplierPrice = 20;

    public int shotgunInitialPrice;
    public int nailGunInitialPrice;
    public int railgunInitialPrice;
    public int cannonGunInitialPrice;

    public GameObject ShopUI;
    public GameObject EnnemieUI;

    public CameraBehaviour cameraRef;

    // Start is called before the first frame update
    void Start()
    {
        CoinMultiplierTextRef.text = coinMultiplier.ToString();
        leftCoinThrower.amoutToRaise = coinMultiplier;
        rightCoinThrower.amoutToRaise = coinMultiplier;

        ShopUI.SetActive(false);
    }

    void Update()
    {

        // I know it's not good habit to have it in the update but i'm too lazy to think of an alternative rn
        if(cameraRef.isPlaying == true)
        {
            EnnemieUI.SetActive(false);
            ShopUI.SetActive(false);
        }
        else
        {
            if(cameraRef.onShop == true)
            {
                ShopUI.SetActive(true);
            }
            else
            {
                EnnemieUI.SetActive(true);
                UpdateMultUI();
            }
        }
    }

    public void BuyAV1()
    {
        if(scoreManager.score >= 20)
        {
            scoreManager.score -= 20;
            autoClickerManager.autoSendersList.Add(true);
            scoreManager.UpdateUI();
        }
        

    }

    public void CheckToIncreaseMult(int amount)
    {
        if (scoreManager.score >= coinMultiplierPrice)
        {
            IncreaseCoinMultiplier(amount);
            scoreManager.score -= coinMultiplierPrice;
            coinMultiplierPrice = coinMultiplierPrice + coinMultiplierPrice * coinMultiplier;
        }
    }
    public void IncreaseCoinMultiplier(int amount)
    {     
            
            scoreManager.UpdateUI();

            coinMultiplier += amount;
            CoinMultiplierTextRef.text = coinMultiplier.ToString();
            leftCoinThrower.amoutToRaise = coinMultiplier;
            rightCoinThrower.amoutToRaise = coinMultiplier;
            coinMultiplierPriceTextRef.text = coinMultiplierPrice.ToString();
        
    }

    public void UpdateMultUI()
    {
        CoinMultiplierTextRef.text = coinMultiplier.ToString();
        coinMultiplierPriceTextRef.text = coinMultiplierPrice.ToString();
    }
}
