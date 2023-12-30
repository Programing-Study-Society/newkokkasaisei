using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace TextSpace
{
    public class UserScriptManager : MonoBehaviour
    {
        public int bunmatu=0;

        [SerializeField] public TextAsset _textFile;

        // ���͒��̕��i�����ł͂P�s���Ɓj�����Ă������߂̃��X�g
        public List<string> _sentences = new List<string>();


        public void ReadText()
        {

            // �e�L�X�g�t�@�C���̒��g���A�P�s�����X�g�ɓ���Ă���
            StringReader reader = new StringReader(_textFile.text);
            while (reader.Peek() != -1)
            {
                string line = reader.ReadLine();
                _sentences.Add(line);
                bunmatu++;
            }
        }

        // ���݂̍s�̕����擾����
        public string GetCurrentSentence()
        {
            return _sentences[globalValue.lineNumber];
        }
    }
}