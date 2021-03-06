﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthManager))]

public class LogMaterial : RawMaterial
{

    public GameObject yeildObj;
    int yeildQuantity = 3;
    HealthManager healthManager;
    private void Start()
    {
        healthManager = GetComponent<HealthManager>();
        healthManager.m_onDeath.AddListener(Kill);
        matIndex = 2;
    }

    public void Kill()
    {
        Vector3 dropPos = Vector3.forward;
        for (int i = 0; i < yeildQuantity; i++)
        {
            Instantiate(yeildObj, transform.position + dropPos, transform.rotation, null);
            dropPos += -Vector3.forward;
        }
        Destroy(this.gameObject);
    }


    public override void OnEquipt(GameObject character)
    {
        base.OnEquipt(character);
    }

    public override void OnUnequipt()
    {
        base.OnUnequipt();
    }

}
