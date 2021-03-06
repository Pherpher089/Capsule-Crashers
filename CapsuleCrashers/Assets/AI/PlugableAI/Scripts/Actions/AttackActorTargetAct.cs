﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/AttackActor")]

public class AttackActorTargetAct : Action {

    float coolDown = 0;

    public override void Act(StateController controller)
    {
        AttackActor(controller);
    }

    private void AttackActor(StateController controller)
    {
        controller.navMeshAgent.stoppingDistance = controller.enemyStats.attackRange;
        controller.focusOnTarget = true;

        if (coolDown > 0)
        {
            coolDown -= 2 * Time.deltaTime;
            controller.equipment.equipedItem.GetComponent<Item>().PrimaryAction(0);
        }
        else
        {
            controller.equipment.equipedItem.GetComponent<Item>().PrimaryAction(1);
            coolDown = controller.enemyStats.attackRate;
        }
    }
}

