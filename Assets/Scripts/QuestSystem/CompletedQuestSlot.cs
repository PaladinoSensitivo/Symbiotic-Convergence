using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompletedQuestSlot : MonoBehaviour 
{
    [SerializeField] Text m_completedTitle;
    [SerializeField] Text m_completedTitleExperienceText;
    [SerializeField] Text m_completedTitleGoldText;
    public void Set(Text title, Text experienceText, Text goldText){
        m_completedTitle.text = title.text;
        m_completedTitleExperienceText.text = experienceText.text;
        m_completedTitleGoldText.text = goldText.text;
    }
}
