﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateController : MonoBehaviour
{
    public State currentState;
    public EnemyStats enemyStats;
    public Transform eyes;
    public List<Transform> wayPointList;
    public State remainState;

    [HideInInspector] public NavMeshAgent navMeshAgent;
    [HideInInspector] public int nextWayPoint;
    public Vector3 chaseTarget;
    [HideInInspector] public GameObject actorTarget;
    [HideInInspector] public GameObject structureTarget;
    [HideInInspector] public bool focusOnTarget;
    [HideInInspector] public SphereCollider sphereCollider;
    [HideInInspector] public ActorEquipment equipment;
    [HideInInspector] public Rigidbody rigidbodyRef;

    private bool aiActive;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        sphereCollider = GetComponent<SphereCollider>();
        equipment = GetComponent<ActorEquipment>();
        rigidbodyRef = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        SetupAI(true);
    }

    public void SetupAI(bool aiActivationFromTankManager)
    {
        aiActive = aiActivationFromTankManager;

        if (aiActive)
        {
            navMeshAgent.enabled = true;
        }
        else
        {
            navMeshAgent.enabled = false;
        }
    }

    private void Update()
    {
        if(!aiActive)
        {
            return;
        }
        else
        {
            currentState.UpdateState(this);
        }
    }

    private void OnDrawGizmos()
    {
        if(Application.isPlaying)
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawSphere(navMeshAgent.destination, 1);
            if (currentState != null)
            {
                Gizmos.color = currentState.SceneGizmoColor;
                Gizmos.DrawWireSphere(eyes.position, enemyStats.lookSphereCastRadius);
            }
        }
        
    }

    public void TransitionToState(State nextState)
    {
        if(nextState != remainState)
        {
            currentState = nextState;
        }
    }

}