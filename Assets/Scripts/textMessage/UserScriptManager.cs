using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace TextSpace
{
    public class UserScriptManager : MonoBehaviour
    {
        public int bunmatu=0;

        [SerializeField] TextAsset _textFile;

        // 文章中の文（ここでは１行ごと）を入れておくためのリスト
        List<string> _sentences = new List<string>();

        void Awake()
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