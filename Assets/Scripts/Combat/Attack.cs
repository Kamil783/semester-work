﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    int damage;
    bool critical;
    public Attack(int damage,bool critical)
    {
        this.damage = damage;
        this.critical = critical;
    }
    public int Damage {
        get { return damage; }
    }
    public bool IsCritical {
        get { return critical; }
    }
}
