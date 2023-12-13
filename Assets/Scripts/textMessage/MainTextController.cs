using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace TextSpace
{
    public class MainTextController : MonoBehaviour
    {

        [SerializeField] TextMeshProUGUI _mainTextObject;
        [SerializeField] GameObject textMassage;
        int _displayedSentenceLength;
        int _sentenceLength;
        float _time;
        [SerializeField] GameObject MessageWindow;
        [SerializeField] GameObject mousePosition;
        [SerializeField] GameObject tutorial;
        MousePosition MousePosition;
        TutorialManager TutorialManager;

        // Start is called before the first frame update
        void Start()
        {
            TutorialManager = tutorial.GetComponent<TutorialManager>();
            MousePosition = mousePosition.GetComponent<MousePosition>();

            _time = 0f;
           
            DisplayText();
        }

        public void OnClickNextText()
        {
            if (globalValue.lineNumber == GameManager.Instance.userScriptManager.bunmatu)
            {
                MessageWindow.SetActive(true);
                //Debug.Log("文字列だよ！！");
            }
            else
            {
                if (CanGoToTheNextLine())
                {
                    GoToTheNextLine();
                    DisplayText();
                    TutorialManager.TutorialRangeMovement();
                }
                else
                {
                    _displayedSentenceLength = _sentenceLength;
                }
            }
        }

        // Update is called once per frame
        void Update()
        {

            // 文章を１文字ずつ表示する
            _time += Time.deltaTime;
            if (_time >= globalValue.textSpeed)
            {
                _time -= globalValue.textSpeed;
                if (!CanGoToTheNextLine())
                {
                    _displayedSentenceLength++;
                    _mainTextObject.maxVisibleCharacters = _displayedSentenceLength;
                }
            }

            if(globalValue.lineNumber < TutorialManager.listMaxCount)
            {
                // 範囲指定された所をクリックされたとき、次の行へ移動
                if (MousePosition.messageMousePosition)
                {
                    if (Input.GetMouseButtonUp(0))
                    {
                        OnClickNextText();

                    }
                }
            }
            else
            {
                textMassage.SetActive(false);
            }
            
        }

        // その行の、すべての文字が表示されていなければ、まだ次の行へ進むことはできない
        public bool CanGoToTheNextLine()
        {
            string sentence = GameManager.Instance.userScriptManager.GetCurrentSentence();
            _sentenceLength = sentence.Length;
            return (_displayedSentenceLength > sentence.Length);
        }

        // 次の行へ移動
        public void GoToTheNextLine()
        {
            _displayedSentenceLength = 0;
            _time = 0f;
            _mainTextObject.maxVisibleCharacters = 0;
            globalValue.lineNumber++;
            
        }

        // テキストを表示
        public void DisplayText()
        {
            string sentence = GameManager.Instance.userScriptManager.GetCurrentSentence();
            _mainTextObject.text = sentence;
        }
    }
}