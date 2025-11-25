using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Core.Singleton;

public class ItemManager : Singleton<ItemManager>
{
 
    public int coins;
    public TextMeshProUGUI UITextCoins;

   
    private void Start()
    {
        Reset();        
    }

    private void Reset()
    {
        coins = 0;
        UpdateUI();
    }

    public void AddCoins(int amount=1)
    {
        coins+= amount;
        UpdateUI();
    }

    private void UpdateUI()
    {
        UITextCoins.text = coins.ToString();
    }
}
