using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultQuestSO",menuName ="TopDownController/Quests/Default",order =0)]
public class QuestDataSO : ScriptableObject
{
    [Header("Äù½ºÆ® Á¤º¸")]
    public string questName;
    public int questReqiredLevel;
    public int questID;
    public List<int> questPrerequisites;
}
