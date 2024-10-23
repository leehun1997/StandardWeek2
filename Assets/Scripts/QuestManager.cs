using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private List<QuestDataSO> quests;
    private static QuestManager instance;

    // [구현사항 2] 정적 프로퍼티 정의
    public static QuestManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<QuestManager>();
                if(instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.AddComponent<QuestManager>();
                    instance = obj.GetComponent<QuestManager>();
                }
            }
            return instance;
        }
    }
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);//이미 존재하면 새로운 생성자 파괴
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        foreach(QuestDataSO quest in quests)
        {
            if (quest is EncounterQuestDataSO)
            {
                EncounterQuestDataSO Equest = quest as EncounterQuestDataSO;
                Debug.Log($"{Equest.questID}. {Equest.questName} (필요레벨:{Equest.questReqiredLevel}, 선행 퀘스트 : {(Equest.questPrerequisites.Count == 0 ? "없음" : string.Join(", ", Equest.questPrerequisites))})");
                Debug.Log($"{Equest.questEncountid} 완료하기");
            }
            else if (quest is MonsterQuestDataSO)
            {
                MonsterQuestDataSO Mquest = quest as MonsterQuestDataSO;
                Debug.Log($"{Mquest.questID}. {Mquest.questName} (필요레벨:{Mquest.questReqiredLevel}, 선행 퀘스트 : {(Mquest.questPrerequisites.Count == 0 ? "없음" : string.Join(", ", Mquest.questPrerequisites))})");
                Debug.Log($"{Mquest.monsterName}을 {Mquest.monsterNum}만큼 물리치기.");
            }
            else
            {
                Debug.Log($"{quest.questID}. {quest.questName} (필요레벨:{quest.questReqiredLevel}, 선행 퀘스트 : {(quest.questPrerequisites.Count == 0 ? "없음" : string.Join(", ", quest.questPrerequisites))})");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
