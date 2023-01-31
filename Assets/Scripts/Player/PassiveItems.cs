using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveItems : MonoBehaviour {

    List<Item> items;
    Character character;

    private void Awake()
    {
        character = GetComponent<Character>();
    }

    public void Equip(Item itemToEquip)
    {
        if(items == null)
        {
            items = new List<Item>();
        }
        items.Add(itemToEquip);
        itemToEquip.Equip(character);
        character.updateStats();
    }

    public void UnEquip(Item itemToUnequip)
    {

    }

    public void UpgradeItem(UpgradeData udata)
    {
        Item i = items.Find(it => it.Name == udata.item.Name);
        i.UnEquip(character);
        i.stats.Sum(udata.ItemUpgradeStats);
        i.Equip(character);
        Debug.Log(character);
        character.updateStats();
    }

    public int GetPassiveCount()
    {
        return items.Count;
    }

    public int GetPassivePos(UpgradeData udata)
    {
        return items.FindIndex(it => it.Name == udata.item.Name);
    }
}
