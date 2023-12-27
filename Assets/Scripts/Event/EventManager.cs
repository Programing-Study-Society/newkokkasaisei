using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    public List<GameObject> rootEventObject;
    public List<GameObject> randomEventObject;

    public List<Button> EventNotSelectButton;
    public GameObject YesObject;
    public GameObject NoObject;
    public GameObject eventObject;//イベント専用オブジェクト
    public GameObject dayCounter;//日にちをカウントするスクリプト
    public Button addMonthButton;//翌月にスキップできるボタン

    int random;//ランダムな値を保存する値
    int oldMonth;//前の月

    RandomEventManager randomEventManager;
    WarEventManager warEventManager;

    // Start is called before the first frame update
    void Start()
    {
        oldMonth = globalValue.monthNumber;
    }

    // Update is called once per frame
    void Update()
    {
        //最初の説明部分
        TutorialFrag();

        //戦争イベント
        WarEvent();

        //ランダムイベント部分
        if (oldMonth != globalValue.monthNumber)
        {
            
            RandomFunction(100);
            
            Debug.Log("ランダムイベント抽選" + random);

            if (random < 1)//1%の確立でどちらかが選択される
            {
                RandomFunction(2);
                if (random == 0)
                {
                    UFOInvasion();//1%
                }
                else
                {
                    Infection();//1%
                }
            }
            else if (random < 6)//5%の確立でどちらかが選択される
            {
                disasterEvent();//5%
            }
            else if(random < 100)//10%の確立でどちらかが選択される
            {
                RandomFunction(10);
                if (random < 7)
                {
                    HelpEvent();//10%
                }
                else
                {
                    LuckyEvent();//10%
                }
            }
            
            //前月の更新
            oldMonth = globalValue.monthNumber;
        }
        
    }

    //ランダムイベント中に停止するもの
    public void DuringEvent()
    {
        int EventNotSelectButtonMaxCount = EventNotSelectButton.Count;

        if (globalValue.eventExecution)//イベント中
        {
            dayCounter.SetActive(false);//日数カウンター停止

            //押されたくないボタンを押せないようにする
            for (int i = 0;i < EventNotSelectButtonMaxCount; i++)
            {
                EventNotSelectButton[i].interactable = false;
            }
        }
        else
        {
            dayCounter.SetActive(true);//日数カウンター開始
            //押されたくないボタンを押せるようにする
            for (int i = 0; i < EventNotSelectButtonMaxCount; i++)
            {
                EventNotSelectButton[i].interactable = true;
            }
        }
    }

    //特定のEventを開始する
    public void StartEvent(bool rootEvent ,int eventNumber)
    {
        if(rootEvent)//rootEventの場合
        {
            globalValue.eventExecution = true;
            dayCounter.SetActive(false);//日数カウンター停止
            rootEventObject[eventNumber].SetActive(true);
            globalValue.rootEventNumber = eventNumber;
        }
        else//randomEventの場合
        {
            globalValue.randomEventNumber = eventNumber;
            globalValue.eventExecution = true;
            DuringEvent();
            randomEventObject[eventNumber].SetActive(true);
            eventObject.SetActive(true);
            globalValue.randomEventNumber = eventNumber;
        }
    }
    
    //開始しているイベントを終了する
    public void EndEvent(bool rootEvent, int eventNumber)
    {
        if (rootEvent)
        {
            globalValue.lineNumber = 0;
            globalValue.eventExecution = false;
            dayCounter.SetActive(false);//日数カウンター停止
            rootEventObject[eventNumber].SetActive(false);
            globalValue.rootEventNumber++;
        }
        else
        {
            globalValue.lineNumber = 0;
            globalValue.eventExecution = false;
            DuringEvent();
            randomEventObject[eventNumber].SetActive(false);
            eventObject.SetActive(false);
            if (eventNumber != 3)
            {
                randomAddValue();
            }
        }
        
    }

    //ランダムイベントが終わった後の static 値変更関数
    public void randomAddValue()
    {
        if (globalValue.randomEventNumber == 0)
        {
            globalValue.population -= 300;
        }
        else if(globalValue.randomEventNumber == 1)
        {
            globalValue.gigaMoney -= 30;
        }
        else if (globalValue.randomEventNumber == 2)
        {
            globalValue.gigaMoney -= 1;
        }
        else if (globalValue.randomEventNumber == 3)
        {
            if (globalValue.randomValue <= 1 || globalValue.randomValue == 4)
            {
                globalValue.gigaMoney -= 10;
            }
            else if(globalValue.randomValue == 2 || globalValue.randomValue == 3)
            {
                globalValue.population -= 100;
            }
                
        }
        else if (globalValue.randomEventNumber == 4)
        {
            if (globalValue.randomValue == 0)
            {
                globalValue.population += 100;
            }
            else if (globalValue.randomValue == 1)
            {
                globalValue.population += 300;
            }
            else if (globalValue.randomValue == 2)
            {
                globalValue.gigaMoney += 50;
            }
        }
    }

    // ランダムな値(0 ～ randomValue の間)を取得する関数 ※randomValueは含まない
    public void RandomFunction(int randomValue)
    {
        random = Random.Range(0, randomValue);
        //Debug.Log(random);
    }

    //ランダムイベントで使うテキストを選択する
    public void RandomEventTextSelect(int eventNumber,int textNumber)
    {
        randomEventManager = randomEventObject[eventNumber].GetComponent<RandomEventManager>();

        if (textNumber == 0)
        {
            randomEventManager.ChangeReadText(0);
        }
        else
        {
            RandomFunction(textNumber);
            globalValue.randomValue = random;
            //Debug.Log(random);
            randomEventManager.ChangeReadText(random);
        }
        
    }

    //最初の説明をする条件
    public void TutorialFrag()
    {
        if(globalValue.rootEventNumber == 0)
        {
            if (!globalValue.eventExecution)
            {
                StartEvent(true,globalValue.rootEventNumber);
            }
        }
        else if(globalValue.rootEventNumber == 1)
        {
            StartEvent(true, globalValue.rootEventNumber);
        }
        else
        {

        }
    }

    public void WarEvent()
    {
        for (int i = 0;i < 5;i++)
        {
            if (globalValue.tradeSituation[i] == "戦争中")
            {
                globalValue.tradeSituation[i] = "していない";
                globalValue.friendshipLevel[i] = 1;
                globalValue.rootEventNumber = 2;
                globalValue.randomValue = i;
                warEventManager = rootEventObject[2].GetComponent<WarEventManager>();
                warEventManager.ChangeReadText(i);
                StartEvent(true, globalValue.rootEventNumber);
            }
        }
        
    }

    //UFO襲来イベント(1%の確率)
    public void UFOInvasion()
    {
        if (!globalValue.eventExecution)
        {
            RandomEventTextSelect(0, 0);
            StartEvent(false, 0);
        }
    }

    //感染症イベント（1%）
    public void Infection()
    {
        if (!globalValue.eventExecution)
        {
            RandomEventTextSelect(1, 0);
            StartEvent(false, 1);
        }
    }

    //災害イベント(5%)
    public void disasterEvent()
    {
        if (!globalValue.eventExecution)
        {
            RandomEventTextSelect(2, 0);
            StartEvent(false, 2);
        }
    }

    //ランダムヘルプイベント
    public void HelpEvent()
    {
        if (!globalValue.eventExecution)
        {
            RandomEventTextSelect(3, 5);
            YesObject.SetActive(true);
            NoObject.SetActive(true);
            StartEvent(false, 3);
        }
    }

    //ランダムラッキーイベント
    public void LuckyEvent()
    {
        if (!globalValue.eventExecution)
        {
            RandomEventTextSelect(4, 3);
            StartEvent(false, 4);
        }
    }
}
