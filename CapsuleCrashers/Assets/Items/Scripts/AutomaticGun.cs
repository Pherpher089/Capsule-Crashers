﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Automatic projectile machine.
/// </summary>
public class AutomaticGun : Item {

    public float rateOfFire;
    public float bulletForce;

    float rateTracker;
    GameObject bulletClone;
    Transform bulletGenPoint;

    private void Start()
    {
        bulletClone = Resources.Load("BulletPrefab") as GameObject;
        bulletGenPoint = transform.Find("Bullet_SpawnPoint");
        matIndex = 0;
    }

    public override void OnEquipt(GameObject character)
    {
        base.OnEquipt(character);

    }

    public override void OnUnequipt()
    {
        base.OnUnequipt();

    }

    public override void PrimaryAction(float input)
    {
        if(input > 0.10f)
        {
            if(rateTracker >= 1)
            {
                GameObject bullet;
                bullet = Instantiate(bulletClone, bulletGenPoint.position, bulletGenPoint.rotation);
                bullet.GetComponent<Rigidbody>().AddForce(bulletGenPoint.forward * 1000 * bulletForce);
                rateTracker = 0;
            }
            else
            {
                rateTracker += Time.deltaTime * rateOfFire;
            }
        }

        if(input <= 0.1f)
        {
            rateTracker = 1;
        }
    }
}
