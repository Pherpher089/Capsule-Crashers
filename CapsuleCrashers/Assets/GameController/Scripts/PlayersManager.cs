﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersManager : MonoBehaviour {

    public List<ThirdPersonUserControl> playerList = new List<ThirdPersonUserControl>();

    void Start()
    {
        GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("Player");

        for (int i = 0; i < playerObjects.Length; i++)
        {
            foreach (GameObject playerObject in playerObjects)
            {
                if (playerObject.GetComponent<ThirdPersonUserControl>().playerPos == i+1)
                {
                    playerList.Add(playerObject.GetComponent<ThirdPersonUserControl>());
                }
            }
        }
    }
}
