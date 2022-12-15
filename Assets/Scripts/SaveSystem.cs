using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    // Player Data
    public int PlayerHP { get; set; }
    public string PlayerLocation { get; set; }

    // Achievements Data
    public List<string> Achievements { get; set; }

    // Constructor
    public SaveSystem()
    {
        Achievements = new List<string>();
    }

    // Save Method
    public void Save()
    {
        // Save Player Data
        PlayerPrefs.SetInt("PlayerHP", PlayerHP);
        PlayerPrefs.SetString("PlayerLocation", PlayerLocation);

        // Save Achievements Data
        for (int i = 0; i < Achievements.Count; i++)
        {
            PlayerPrefs.SetString("Achievement" + i, Achievements[i]);
        }
    }

    // Load Method
    public void Load()
    {
        // Load Player Data
        PlayerHP = PlayerPrefs.GetInt("PlayerHP");
        PlayerLocation = PlayerPrefs.GetString("PlayerLocation");

        // Load Achievements Data
        int i = 0;
        while (PlayerPrefs.HasKey("Achievement" + i))
        {
            Achievements.Add(PlayerPrefs.GetString("Achievement" + i));
            i++;
        }
    }
}