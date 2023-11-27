using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void Retry()
    {
        globalValue.lineNumber = 0;
        globalValue.tutorialExecution = true;
        globalValue.money = 0;
        globalValue.complain = 0;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
