using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal
{
    public GoalType goalType;

    public int requiredAmount;
    public int currentAmount;
    public bool trigger = false;

    public bool isReached()
    {
        if(goalType == GoalType.Gathering || goalType == GoalType.Kill)
        {
            return (currentAmount >= requiredAmount);
        }
        return false;
    }

    public void EnemyKilled()
    {
        if(goalType == GoalType.Kill)
        currentAmount++;
    }

    public void ItemCollected()
    {
        if (goalType == GoalType.Gathering)
            currentAmount++;
    }

    public void ReachPlace()
    {
        Debug.Log("Tentei chegar");
        if (goalType == GoalType.Trigger){
            trigger = true;
            Debug.Log("Cheguei");
        }
    }    
}
public enum GoalType
{
    Kill,
    Gathering,
    Trigger
}