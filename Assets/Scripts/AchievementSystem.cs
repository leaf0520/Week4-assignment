using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementSystem : MonoBehaviour
{
    public event Action<string> OnAchievementUnlocked;

    private int _killEnemies;
    private int _dieWithoutKilling;

    public void Update()
    {
        if (_killEnemies >= 100)
        {
            OnAchievementUnlocked?.Invoke("Kill 100 Enemies");
        }

        if (_dieWithoutKilling > 0)
        {
            OnAchievementUnlocked?.Invoke("Die without killing Single Enemy");
        }
    }

    public void IncrementKillEnemies()
    {
        _killEnemies++;
    }

    public void IncrementDieWithoutKilling()
    {
        _dieWithoutKilling++;
    }
}