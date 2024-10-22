using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EncountQuestSO", menuName = "TopDownController/Quests/Encount", order = 2)]
public class EncounterQuestDataSO : QuestDataSO
{
    [Header("전투 퀘스트 추가 정보")]
    public int questEncountid;
}
