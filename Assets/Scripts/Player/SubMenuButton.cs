using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubMenuButton : Button {
    public GameObject Menu;
    public GameObject SubMenu;

    public override void OnPress()
    {
        Menu.SetActive(false);
        SubMenu.SetActive(true);
    }
}
