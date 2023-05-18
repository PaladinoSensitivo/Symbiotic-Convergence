using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public PlayerMovement player;
    public Quest quest;
    public Quest quest2;
    public Quest quest3;

    public Text titleText;
    public Text descriptionText;
    public Text experienceText;
    public Text goldText;

    public void Start()
    {
        player.quest = quest;
        titleText.text = quest.title;
        descriptionText.text = quest.description;
        experienceText.text = quest.experienceReward.ToString();
        goldText.text = quest.goldReward.ToString();
    }
    public void Update()
    {

    }

    public void NextQuest()
    {
        if(quest.isActive == true) { 
            quest.isActive = false;
            quest2.isActive = true;
            player.quest = quest2;
            titleText.text = quest2.title;
            descriptionText.text = quest2.description;
            experienceText.text = quest2.experienceReward.ToString();
            goldText.text = quest2.goldReward.ToString();
        }
        else if(quest2.isActive == true)
        {
            quest2.isActive = false;
            quest3.isActive = true;
            player.quest = quest3;
            titleText.text = quest3.title;
            descriptionText.text = quest3.description;
            experienceText.text = quest3.experienceReward.ToString();
            goldText.text = quest3.goldReward.ToString();
        }
    }
}
