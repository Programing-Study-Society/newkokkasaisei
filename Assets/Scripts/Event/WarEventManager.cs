using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TextSpace;

public class WarEventManager : MonoBehaviour
{
    public EventManager eventManager;
    public MousePosition MousePosition;
    public UserScriptManager userScriptManager;
    public MainTextController mainTextController;
    public Text text;
    public War war;

    public List<TextAsset> readText;

    public int lastLine;//行の最後

    public GameObject warObject;
    public GameObject textObject;
    public GameObject mainTextObject;

    public int warEventNumber = 0;

    bool first = true;

    // Start is called before the first frame update
    void Start()
    {
        warEventNumber = 1;
    }

    // Update is called once per frame
    void Update()
    {

        //どこを押しても次のテキストに行けるようにする
        MousePosition.UpDataRangeObject(globalValue.canvas);

        if (globalValue.lineNumber == 3)
        {
            
            if (first){
                globalValue.gigaMoney = globalValue.gigaMoney - 10;
                globalValue.population = globalValue.population - 300;
                first = false;
            }
            
        }
        //最後の行から改行したら終了
        if (globalValue.lineNumber > lastLine - 1 && warEventNumber == 1)
        {
            mainTextObject.SetActive(false);
            warObject.SetActive(true);
            warEventNumber = 2;
        }
        if (warEventNumber == 3)
        {
            warObject.SetActive(false);
            textObject.SetActive(true);
            if (war.myCountryWin)
            {
                text.text = "Winner";
            }
            else
            {
                text.text = "Losers";
            }

            //クリックしたら終了
            if (Input.GetMouseButtonUp(0))
            {
                EndWarEvent();
            }
        }
    }

    public void EndWarEvent()
    {
        eventManager.EndEvent(true, globalValue.rootEventNumber);
        mainTextController.first = true;
        //Debug.Log(globalValue.eventExecution);
    }

    public void ChangeReadText(int Number)
    {
        userScriptManager._sentences = new List<string>();
        userScriptManager._textFile = readText[Number];
    }
}
