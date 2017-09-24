using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    
    void Effect();
    void Damage(Stat hlth);
}

public class Weapon : IWeapon
{
    public Weapon(float dmg)
    {
        WDamage = dmg;
    }

    public float WDamage; // Урон оружия

    public void Damage(Stat hlth)
    {
        hlth.DealDamage(WDamage);
    }
    public void Effect()
    {

    }
}
