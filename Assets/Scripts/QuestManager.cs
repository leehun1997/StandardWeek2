using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private List<QuestDataSO> quests;
    private static QuestManager instance;

    // [�������� 2] ���� ������Ƽ ����
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
            Destroy(gameObject);//�̹� �����ϸ� ���ο� ������ �ı�
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
                Debug.Log($"{Equest.questID}. {Equest.questName} (�ʿ䷹��:{Equest.questReqiredLevel}, ���� ����Ʈ : {(Equest.questPrerequisites.Count == 0 ? "����" : string.Join(", ", Equest.questPrerequisites))})");
                Debug.Log($"{Equest.questEncountid} �Ϸ��ϱ�");
            }
            else if (quest is MonsterQuestDataSO)
            {
                MonsterQuestDataSO Mquest = quest as MonsterQuestDataSO;
                Debug.Log($"{Mquest.questID}. {Mquest.questName} (�ʿ䷹��:{Mquest.questReqiredLevel}, ���� ����Ʈ : {(Mquest.questPrerequisites.Count == 0 ? "����" : string.Join(", ", Mquest.questPrerequisites))})");
                Debug.Log($"{Mquest.monsterName}�� {Mquest.monsterNum}��ŭ ����ġ��.");
            }
            else
            {
                Debug.Log($"{quest.questID}. {quest.questName} (�ʿ䷹��:{quest.questReqiredLevel}, ���� ����Ʈ : {(quest.questPrerequisites.Count == 0 ? "����" : string.Join(", ", quest.questPrerequisites))})");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
