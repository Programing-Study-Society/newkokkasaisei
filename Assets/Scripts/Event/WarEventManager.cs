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
    public SoundVolume soundVolume;
    public int lastLine;//行の最後

    public GameObject warObject;
    public GameObject textObject;
    public GameObject mainTextObject;

    public int warEventNumber = 0;

    bool first = true;
    bool warWinFirst = true;
    bool SEFirst = true;

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
                globalValue.population = globalValue.population - 100;
                first = false;
            }
            
        }else if (globalValue.lineNumber == 4)
        {
            soundVolume.bgmVolume[0].Stop();
            soundVolume.bgmVolume[1].Play();
        }

        //最後の行から改行したら終了
        if (globalValue.lineNumber > lastLine - 1 && warEventNumber == 1)
        {
            mainTextObject.SetActive(false);
            warObject.SetActive(true);
            warEventNumber = 2;
        }

        //対戦が終わったら
        if (warEventNumber == 3)
        {
            warObject.SetActive(false);
            textObject.SetActive(true);
            if (war.myCountryWin)
            {
                if (SEFirst)
                {
                    soundVolume.bgmVolume[1].Stop();
                    soundVolume.seVolume[3].PlayOneShot(soundVolume.seVolume[3].clip);
                    SEFirst = false;
                }
                text.text = "Winner\n" + "お金+100M";
                if (warWinFirst)
                {
                    globalValue.gigaMoney += 100;
                    warWinFirst = false;
                }
            }
            else
            {
                if (SEFirst)
                {
                    soundVolume.bgmVolume[1].Stop();
                    soundVolume.seVolume[2].PlayOneShot(soundVolume.seVolume[2].clip);
                }
                text.text = "Losers\n" + "お金-100M";
                if (warWinFirst)
                {
                    globalValue.gigaMoney -= 100;
                    warWinFirst = false;
                }
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
        soundVolume.bgmVolume[1].Stop();
        soundVolume.bgmVolume[0].Play();
        eventManager.EndEvent(true, globalValue.rootEventNumber);
        mainTextController.first = true;
        first = true;
        warWinFirst = true;
        SEFirst = true;
        //Debug.Log(globalValue.eventExecution);
    }

    public void ChangeReadText(int Number)
    {
        userScriptManager._sentences = new List<string>();
        userScriptManager._textFile = readText[Number];
    }
}
