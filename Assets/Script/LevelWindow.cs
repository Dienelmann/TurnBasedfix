using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class LevelWindow : MonoBehaviour
{
   public Text levelText;
   public Slider experienceBarSlider;
   private LevelSystem levelSystem;

   

   private void SetExperienceBarSlider(float experienceNormalized)
   {
      experienceBarSlider.value = experienceNormalized;
   }

   private void SetLevelNumber(int LevelNumber)
   {
      levelText.text = "LEVEL\n" + (LevelNumber + 1);
   }

   public void SetLevelSystem(LevelSystem levelSystem)
   {
      this.levelSystem = levelSystem;
      
      
      SetExperienceBarSlider(levelSystem.GetExperienceNormalized());
   }
}
