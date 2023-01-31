using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpPickUpObject : MonoBehaviour, IPickUpObject
{
    [SerializeField] int expAmount = 250;

    public void OnPickUp(Character character)
    {
        character.AddExperience(expAmount);
    }
}
