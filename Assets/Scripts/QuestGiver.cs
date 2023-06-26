using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public PlayerMovement player;
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

    void FixedUpdate(){
        if(CurrentQuest().goal.isReached() == true){
            NextQuest();
        }
    }
    public void NextQuest()
    {
        UpdateCompletedQuest();
        if(index < questList.Length)
            index++;
        Debug.Log(index);
        Debug.Log(questList[index].goal.goalType);
        questList[index-1].isActive = false;
        questList[index].isActive = true;
        UpdateActiveQuest();
    }
    public void UpdateCompletedQuest(){
        GameObject questSlot = Instantiate(completedQuestPF, completedQuestParent, false);
        CompletedQuestSlot cQuestSlot = questSlot.GetComponent<CompletedQuestSlot>();
        cQuestSlot.Set(titleText, experienceText, goldText);
    }
    public void UpdateActiveQuest(){
        player.quest = CurrentQuest();
        titleText.text = CurrentQuest().title;
        descriptionText.text = CurrentQuest().description;
        experienceText.text = CurrentQuest().experienceReward.ToString();
        goldText.text = CurrentQuest().goldReward.ToString();
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