using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp {

    protected int activetime;
    protected int cooldowntime;


    public abstract void StartCooldown();

    public abstract void StartPowerUp();
}
