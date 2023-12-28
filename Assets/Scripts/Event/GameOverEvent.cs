using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TextSpace;

public class GameOverEvent : MonoBehaviour
{
    public EventManager eventManager;
    public MousePosition MousePosition;
    public UserScriptManager userScriptManager;
    public MainTextController mainTextController;
    
    public List<TextAsset> readText;

    public int lastLine;//行の最後

    public GameObject mainTextObject;
    public GameObject gameOverObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //どこを押しても次のテキストに行けるようにする
        MousePosition.UpDataRangeObject(globalValue.canvas);

        //最後の行から改行したら終了
        if (globalValue.lineNumber > lastLine - 1)
        {
            mainTextObject.SetActive(false);
            gameOverObject.SetActive(true);
        }
    }

    public void ChangeReadText(int Number)
    {
        userScriptManager._sentences = new List<string>();
        userScriptManager._textFile = readText[Number];
    }
}
