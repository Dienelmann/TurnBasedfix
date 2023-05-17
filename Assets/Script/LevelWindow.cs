using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class LevelWindow : MonoBehaviour
{
   private Text levelText;
   private Slider experienceBarSlider;
   private LevelSystem levelSystem;

   private void Awake()
   {
      levelText = transform.Find("levelText").GetComponent<Text>();
      experienceBarSlider = transform.Find("ExperienceBar").GetComponent<Slider>();
   }

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
