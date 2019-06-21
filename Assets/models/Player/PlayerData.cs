﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData
{
    private int xp;
    private int requiredXp;
    private int levelBase;
    private int lvl;
    private List<DroidData> droids;

    public int Xp { get { return xp; } }
    public int RequiredXp { get { return requiredXp; } }
    public int LevelBase { get { return levelBase; } }
    public int Lvl { get { return lvl; } }
    public List<DroidData> Droids { get { return droids; } }

    public PlayerData(Player player)
    {
        xp = player.Xp;
        requiredXp = player.LevelBase;
        levelBase = player.LevelBase;
        lvl = player.Lvl;
        foreach (GameObject droidObject in player.Droids)
        {
            Droid droid = droidObject.GetComponent<Droid>();
            if (droid != null)
            {
                DroidData data = new DroidData(droid);
                droids.Add(data);
            }
        }
    }
}