using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private QuestDataSO quests;
    private static QuestManager instance;

    // [구현사항 2] 정적 프로퍼티 정의
    private static QuestManager Instance
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
