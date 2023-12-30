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

        // 文章中の文（ここでは１行ごと）を入れておくためのリスト
        public List<string> _sentences = new List<string>();


        public void ReadText()
        {

            // テキストファイルの中身を、１行ずつリストに入れておく
            StringReader reader = new StringReader(_textFile.text);
            while (reader.Peek() != -1)
            {
                string line = reader.ReadLine();
                _sentences.Add(line);
                bunmatu++;
            }
        }

        // 現在の行の文を取得する
        public string GetCurrentSentence()
        {
            return _sentences[globalValue.lineNumber];
        }
    }
}