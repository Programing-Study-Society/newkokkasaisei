using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void Retry()
    {
        //チュートリアル進捗初期化
        globalValue.lineNumber = 0;
        globalValue.eventExecution = true;
        
        //所持金初期化
        globalValue.money = 0;
        
        //国民不満ゲージ初期化
        globalValue.complain = 0;

        //日付初期化
        globalValue.yearNumber = 1;
        globalValue.monthNumber = 1;
        globalValue.dayNumber = 1;

        //シーン初期化
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void endGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
        Application.Quit();//ゲームプレイ終了
#endif
    }
}
