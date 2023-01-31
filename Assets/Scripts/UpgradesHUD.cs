using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesHUD : MonoBehaviour {

    [SerializeField] List<Image> imgWeapons;
    [SerializeField] List<Image> imgPassives;

    public void SetPassive(int pos, Sprite spr)
    {
        imgPassives[pos].gameObject.SetActive(true);
        imgPassives[pos].sprite = spr;
    }

    public void UpdatePassive(int pos, Sprite spr)
    {
        imgPassives[pos].sprite = spr;
    }

    public void SetWeapon(int pos, Sprite spr)
    {
        imgWeapons[pos].gameObject.SetActive(true);
        imgWeapons[pos].sprite = spr;
    }

    public void UpdateWeapon(int pos, Sprite spr)
    {
        imgWeapons[pos].sprite = spr;
    }
}
