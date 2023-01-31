using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUpObject : MonoBehaviour,IPickUpObject {

    [SerializeField] int coinAmount = 1;

    public void OnPickUp(Character character)
    {
        character.AddCoins(coinAmount);
    }
}
