using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    public List<GameObject> rootEventObject;
    public List<GameObject> randomEventObject;

    public GameObject dayCounter;//日にちをカウントするスクリプト
    public Button addMonthButton;//翌月にスキップできるボタン

    int random;//ランダムな値を保存する値
    int oldMonth;//前の月

    // Start is called before the first frame update
    void Start()
    {
        oldMonth = globalValue.monthNumber;
    }

    // Update is called once per frame
    void Update()
    {
        //最初の説明部分
        //TutorialFrag();

        //ランダムイベント部分
        if (oldMonth != globalValue.monthNumber)
        {
            Debug.Log("ランダムイベント抽選");
            UFOInvasion();//1%
            Infection();//1%
            disasterEvent();//5%
            oldMonth = globalValue.monthNumber;
        }
        
    }

    //特定のEventを開始する
    public void StartEvent(bool rootEvent ,int eventNumber)
    {
        if(rootEvent)//rootEventの場合
        {
            globalValue.eventExecution = true;
            DuringEvent();
            rootEventObject[eventNumber].SetActive(true);
        }
        else//randomEventの場合
        {
            globalValue.randomEventNumber = eventNumber;
            globalValue.eventExecution = true;
            DuringEvent();
            randomEventObject[eventNumber].SetActive(true);
        }
    }
    
    //開始しているイベントを終了する
    public void EndEvent(bool rootEvent, int eventNumber)
    {
        if (rootEvent)
        {
            globalValue.lineNumber = 0;
            globalValue.eventExecution = false;
            DuringEvent();
            rootEventObject[eventNumber].SetActive(false);
            globalValue.rootEventNumber++;
        }
        else
        {
            globalValue.lineNumber = 0;
            globalValue.eventExecution = false;
            DuringEvent();
            randomEventObject[eventNumber].SetActive(false);
        }
        
    }

    //イベント中に停止するもの
    public void DuringEvent()
    {
        if (globalValue.eventExecution)//イベント中
        {
            addMonthButton.interactable = false;
            dayCounter.SetActive(false);//日数カウンター停止
        }
        else
        {
            addMonthButton.interactable = true;
            dayCounter.SetActive(true);//日数カウンター開始
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

    // ランダムな値(0 ～ randomValue の間)を取得する関数
    // ※randomValueは含まない
    public void RandomFunction(int randomValue)
    {
        random = Random.Range(0, randomValue);
        //Debug.Log(random);
    }

    //UFO襲来イベント(1%の確率)
    public void UFOInvasion()
    {
        if (!globalValue.eventExecution)
        {
            RandomFunction(100);
            if (random < 1)
            {
                StartEvent(false, 0);
            }
        }
    }

    //感染症イベント（1%）
    public void Infection()
    {
        if (!globalValue.eventExecution)
        {
            RandomFunction(100);
            if (random < 1)
            {
                StartEvent(false, 1);
            }
        }
    }

    //災害イベント(5%)
    public void disasterEvent()
    {
        if (!globalValue.eventExecution)
        {
            RandomFunction(100);
            if (random < 5)
            {
                StartEvent(false, 2);
            }
        }
    }
}
