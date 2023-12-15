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

        MousePosition MousePosition;

        bool first = true;

        // Start is called before the first frame update
        void Start()
        {
            MousePosition = mousePosition.GetComponent<MousePosition>();

            _time = 0f;
            
        }

        public void OnClickNextText()
        {
            
            if (globalValue.lineNumber == GameManager.Instance.userScriptManager.bunmatu)
            {
                MessageWindow.SetActive(true);
                //Debug.Log("�����񂾂�I�I");
            }
            else
            {
                if (CanGoToTheNextLine())
                {
                    GoToTheNextLine();
                    DisplayText();
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
            if (first == true || globalValue.lineNumber == 0)
            {
                DisplayText();
                first = false;
            }

            // ���͂��P�������\������
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

            // �͈͎w�肳�ꂽ�����N���b�N���ꂽ�Ƃ��A���̍s�ֈړ�
            if (MousePosition.messageMousePosition)
            {
                if (Input.GetMouseButtonUp(0))
                {
                    OnClickNextText();

                }
            }
            
        }

        // ���̍s�́A���ׂĂ̕������\������Ă��Ȃ���΁A�܂����̍s�֐i�ނ��Ƃ͂ł��Ȃ�
        public bool CanGoToTheNextLine()
        {
            string sentence = GameManager.Instance.userScriptManager.GetCurrentSentence();
            _sentenceLength = sentence.Length;
            return (_displayedSentenceLength > sentence.Length);
        }

        // ���̍s�ֈړ�
        public void GoToTheNextLine()
        {
            _displayedSentenceLength = 0;
            _time = 0f;
            _mainTextObject.maxVisibleCharacters = 0;
            globalValue.lineNumber++;
            
        }

        // �e�L�X�g��\��
        public void DisplayText()
        {
            string sentence = GameManager.Instance.userScriptManager.GetCurrentSentence();
            _mainTextObject.text = sentence;
        }
    }
}