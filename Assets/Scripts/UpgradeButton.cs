using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour {

    [SerializeField] Image icon;

    public void Set(UpgradeData uData)
    {
        if(uData==null) { return; }
        icon.sprite = uData.Icon;
    }

    internal void Clean()
    {
        icon.sprite = null;
    }
}
