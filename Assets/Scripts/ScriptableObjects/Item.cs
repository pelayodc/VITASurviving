using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemStats
{
    public int armor;
    public int maxHealthPercent;
    public int healregen;
    public int expbonus;
    public int speed;

    public Sprite spr;

    internal void Sum(ItemStats stats)
    {
        armor += stats.armor;
        maxHealthPercent += stats.maxHealthPercent;
        healregen += stats.healregen;
        speed += stats.speed;
        expbonus += stats.expbonus;
    }
}

[CreateAssetMenu]
public class Item : ScriptableObject {
    public string Name;
    public ItemStats stats;

    public void Equip(Character character)
    {
        character.armor += stats.armor;
        character.maxhpbonus += stats.maxHealthPercent;
        character.hpRegenerationRate += stats.healregen;
        character.expBonus += stats.expbonus;
        character.speedBonus += stats.speed;
    }

    public void UnEquip(Character character)
    {
        character.armor -= stats.armor;
        character.maxhpbonus -= stats.maxHealthPercent;
        character.hpRegenerationRate -= stats.healregen;
        character.expBonus -= stats.expbonus;
        character.speedBonus -= stats.speed;
    }
}
