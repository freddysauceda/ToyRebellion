using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemButton : Button {

    public bool sword;
    public Transform swordObject;

    public override void OnPress()
    {
        swordObject.gameObject.SetActive(sword);
    }
}
