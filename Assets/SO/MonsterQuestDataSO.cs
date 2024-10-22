using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MonsterQuestSO", menuName = "TopDownController/Quests/Monster", order = 1)]
public class MonsterQuestDataSO : QuestDataSO
{
    [Header("몬스터 퀘스트 추가 정보")]
    public string monsterName;
    public int monsterNum;
}
