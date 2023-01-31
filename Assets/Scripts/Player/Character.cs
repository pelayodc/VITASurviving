using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    private int inicialHp = 100;
    private int maxHp = 100;
    private int currentHp = 100;

    //For passives (should change system)
    [HideInInspector] public int armor;
    [HideInInspector] public int maxhpbonus;
     public int expBonus;
     public int speedBonus;
    [HideInInspector] public float hpRegenerationRate = 0f;

    private float hpRegenerationTimer;

    private int level = 1;
    public int experience = 0;

    private int coins;
    private int kills;

    [SerializeField] StatusBar hpBar;
    [SerializeField] ExpBar expBar;
    [SerializeField] LevelUpManager lvlManager;
    [SerializeField] TMPro.TextMeshProUGUI coinsText;
    [SerializeField] TMPro.TextMeshProUGUI killsText;

    [SerializeField] List<UpgradeData> upgrades;
    List<UpgradeData> selectedUpgrades;
    [SerializeField]  UpgradesHUD upgradesHUD;
    List<UpgradeData> acquiredUpgrades;

    WeaponManager weaponManager;
    PassiveItems passiveItems;

    [SerializeField] UpgradeData inicialUpgrade;

    [SerializeField] List<UpgradeData> bonusLevelUp;

    private PlayerMove pMove;

    int TO_LEVEL_UP
    {
        get
        {
            return level * 1000;
        }
    }

    private void Awake()
    {
        weaponManager = GetComponent<WeaponManager>();
        passiveItems = GetComponent<PassiveItems>();
        pMove = GetComponent<PlayerMove>();
    }

    private void Start()
    {
        hpBar.SetState(currentHp, maxHp);
        expBar.UpdateExpSlider(experience, TO_LEVEL_UP);
        expBar.SetLevelText(level);
        coinsText.text = coins.ToString();
        killsText.text = kills.ToString();
        Upgrade(inicialUpgrade);
    }

    private void Update()
    {
        hpRegenerationTimer += Time.deltaTime * hpRegenerationRate;
        if(hpRegenerationTimer > 1f)
        {
            Heal(1);
            hpRegenerationTimer -= 1f;
        }
    }

    public void TakeDamage(int damage)
    {
        ApplyArmor(ref damage);

        currentHp -= damage;
        hpBar.SetState(currentHp, maxHp);

        if(currentHp < 1)
        {
            GetComponent<CharacterGameOver>().GameOver();
        }
    }

    private void ApplyArmor(ref int damage)
    {
        damage -= armor;
        if(damage < 0) { damage = 0; } //TODO should be 0 or 1 the min damage recieved
    }

    public void Heal(int amount)
    {
        if(currentHp < 1) { return; }

        currentHp += amount;
        if (currentHp > maxHp)
        {
            currentHp = maxHp;
        }
        hpBar.SetState(currentHp, maxHp);
    }

    public void updateStats()
    {
        pMove.modSpeed(speedBonus);
        float mul = 1 + (maxhpbonus / 100);
        maxHp = (int)(inicialHp * mul);
        hpBar.SetState(currentHp, maxHp);
    }

    public void AddExperience(int amount)
    {
        float mul = 1 + (expBonus / 100);
        Debug.Log((expBonus / 100));
        experience += (int)(amount * mul);
        CheckLevelUp();
        expBar.UpdateExpSlider(experience, TO_LEVEL_UP);
    }

    public void CheckLevelUp()
    {
        if(experience >= TO_LEVEL_UP)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        if (selectedUpgrades == null) { selectedUpgrades = new List<UpgradeData>(); }
        selectedUpgrades.Clear();
        selectedUpgrades.AddRange(GetUpgrades(3));

        lvlManager.Open(selectedUpgrades);
        experience -= TO_LEVEL_UP;
        level += 1;
        expBar.SetLevelText(level);
    }

    public List<UpgradeData> GetUpgrades(int count)
    {
        List<UpgradeData> toUpgrade = new List<UpgradeData>();

        if (upgrades.Count == 0) { return bonusLevelUp; }

        if(count > upgrades.Count)
        {
            count = upgrades.Count;
        }

        for(int i=0; i<count;i++)
        {
            UpgradeData u = upgrades[Random.Range(0, upgrades.Count)];
            while (toUpgrade.Contains(u)) { u = upgrades[Random.Range(0, upgrades.Count)]; }
            toUpgrade.Add(u);
        }

        return toUpgrade;
    }

    public void Upgrade(int upgradeId)
    {
        UpgradeData uData = selectedUpgrades[upgradeId];

        if (acquiredUpgrades == null) { acquiredUpgrades = new List<UpgradeData>(); }

        switch (uData.upgradeType)
        {
            case UpgradeType.WeaponUpgrade:
                weaponManager.UpgradeWeapon(uData);
                upgradesHUD.UpdateWeapon(weaponManager.GetWeaponPos(uData), uData.Icon);
                break;
            case UpgradeType.ItemUpgrade:
                passiveItems.UpgradeItem(uData);
                upgradesHUD.UpdatePassive(passiveItems.GetPassivePos(uData), uData.Icon);
                break;
            case UpgradeType.WeaponUnlock:
                weaponManager.AddWeapon(uData.weaponData);
                upgradesHUD.SetWeapon(weaponManager.GetWeaponsCount()-1, uData.weaponData.weaponBaseSpr);
                break;
            case UpgradeType.ItemUnlock:
                passiveItems.Equip(uData.item);
                upgradesHUD.SetPassive(passiveItems.GetPassiveCount() - 1, uData.item.stats.spr);
                break;
            case UpgradeType.Coins:
                AddCoins(25);
                break;
            case UpgradeType.Heal:
                Heal(25);
                break;
        }

        foreach (UpgradeData u in uData.upgrades)
        {
            upgrades.Add(u);
        }

        acquiredUpgrades.Add(uData);
        upgrades.Remove(uData);
    }

    public void Upgrade(UpgradeData uData)
    { 
        if (acquiredUpgrades == null) { acquiredUpgrades = new List<UpgradeData>(); }

        switch (uData.upgradeType)
        {
            case UpgradeType.WeaponUpgrade:
                weaponManager.UpgradeWeapon(uData);
                upgradesHUD.UpdateWeapon(weaponManager.GetWeaponPos(uData), uData.Icon);
                break;
            case UpgradeType.ItemUpgrade:
                passiveItems.UpgradeItem(uData);
                upgradesHUD.UpdatePassive(passiveItems.GetPassivePos(uData), uData.Icon);
                break;
            case UpgradeType.WeaponUnlock:
                weaponManager.AddWeapon(uData.weaponData);
                upgradesHUD.SetWeapon(weaponManager.GetWeaponsCount() - 1, uData.weaponData.weaponBaseSpr);
                break;
            case UpgradeType.ItemUnlock:
                passiveItems.Equip(uData.item);
                upgradesHUD.SetPassive(passiveItems.GetPassiveCount() - 1, uData.item.stats.spr);
                break;
        }

        foreach (UpgradeData u in uData.upgrades)
        {
            upgrades.Add(u);
        }

        acquiredUpgrades.Add(uData);
        upgrades.Remove(uData);
    }

    public int getLevel()
    {
        return level;
    }

    public void AddCoins(int amount)
    {
        coins += amount;
        coinsText.text = coins.ToString();
    }

    public void addKill()
    {
        kills++;
        killsText.text = kills.ToString();
    }
}
