using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public PlayerMovement player;
    /*public Quest quest;
    public Quest quest2;
    public Quest quest3;*/
    public Quest[] questList;
    public GameObject activeQuestTAB, completedQuestTAB;
    public GameObject completedQuestPF;
    public Transform completedQuestParent;
    public int index;

    public Text titleText;
    public Text descriptionText;
    public Text experienceText;
    public Text goldText;

    public void Start()
    {
        player.quest = questList[index];
        questList[index].isActive = true;
        Debug.Log(questList[index].goal.goalType);
        titleText.text = questList[index].title;
        descriptionText.text = questList[index].description;
        experienceText.text = questList[index].experienceReward.ToString();
        goldText.text = questList[index].goldReward.ToString();
    }

    public void NextQuest()
    {
        UpdateCompletedQuest();
        index++;
        Debug.Log(questList[index].goal.goalType);
        questList[index-1].isActive = false;
        questList[index].isActive = true;
        UpdateActiveQuest();
        /*if(quest.isActive == true) { 
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
        }*/
    }
    public void UpdateCompletedQuest(){
        GameObject questSlot = Instantiate(completedQuestPF, completedQuestParent, false);
        CompletedQuestSlot cQuestSlot = questSlot.GetComponent<CompletedQuestSlot>();
        cQuestSlot.Set(titleText, experienceText, goldText);
    }
    public void UpdateActiveQuest(){
        player.quest = questList[index];
        titleText.text = questList[index].title;
        descriptionText.text = questList[index].description;
        experienceText.text = questList[index].experienceReward.ToString();
        goldText.text = questList[index].goldReward.ToString();        
    }
    public Quest CurrentQuest(){
        return questList[index];
    }
}

/*public class CompletedQuestData 
{
    public Text completedTitle;
    public Text completedTitleExperienceText;
    public Text completedTitleGoldText;
    public CompletedQuestData(Text title, Text experienceText, Text goldText){
        completedTitle = title;
        completedTitleExperienceText = experienceText;
        completedTitleGoldText = goldText;
    }
}*/