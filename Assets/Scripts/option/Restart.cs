using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void Retry()
    {
        //�`���[�g���A���i��������
        globalValue.lineNumber = 0;
        globalValue.eventExecution = true;
        
        //������������
        globalValue.money = 0;
        
        //�����s���Q�[�W������
        globalValue.complain = 0;

        //���t������
        globalValue.yearNumber = 1;
        globalValue.monthNumber = 1;
        globalValue.dayNumber = 1;

        //�V�[��������
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void endGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//�Q�[���v���C�I��
#else
        Application.Quit();//�Q�[���v���C�I��
#endif
    }
}
