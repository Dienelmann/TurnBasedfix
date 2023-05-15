using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class LevelSystem
{
  public event EventHandler OnLevelChanged;
  public event EventHandler OnExperienceChanged;
  
  public int level;
  public int experience;
  public int experienceToNextLevel;

  public LevelSystem()
  {
    level = 0;
    experience = 0;
    experienceToNextLevel = 100;
  }

  public void AddExperience(int amount)
  {
    experience += amount;
    if (experience >= experienceToNextLevel)
    {
      // Enough experience to lvl up
      
      level++;
      experience -= experienceToNextLevel;
      if (OnLevelChanged != null) OnLevelChanged(this,EventArgs.Empty);
    }
    if (OnExperienceChanged != null) OnExperienceChanged(this,EventArgs.Empty);
  }

  public int GetLevelNumber()
  {
    return level;
  }

  public int GetExperienceNormalized()
  {
    return experience / experienceToNextLevel;
  }
}
