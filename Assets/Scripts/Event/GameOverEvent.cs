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
    public SoundVolume soundVolume;
    public List<TextAsset> readText;

    public int lastLine;//�s�̍Ō�

    public GameObject mainTextObject;
    public GameObject gameOverObject;

    bool first = true;

    // Start is called before the first frame update
    void Start()
    {
        soundVolume.bgmVolume[0].Stop();
        soundVolume.bgmVolume[1].Play();
    }

    // Update is called once per frame
    void Update()
    {

        //�ǂ��������Ă����̃e�L�X�g�ɍs����悤�ɂ���
        MousePosition.UpDataRangeObject(globalValue.canvas);

        if (globalValue.lineNumber > lastLine - 2)
        {
            if (first)
            {
                soundVolume.bgmVolume[1].Stop();
                soundVolume.seVolume[2].Play();
                first = false;
            }
        }
        //�Ō�̍s������s������I��
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
