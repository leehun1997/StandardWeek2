using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDataSO : ScriptableObject
{
    [Header("����Ʈ ����")]
    public string questName;
    public int questReqiredLevel;
    public int questNPCid;
    public List<QuestDataSO> questPrerequisites;
}
