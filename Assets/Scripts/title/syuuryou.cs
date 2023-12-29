using UnityEngine.UI;
using UnityEngine;


public class syuuryou : MonoBehaviour
{
    

    // Start is called before the first frame update

   

    public void syuuryo()
    {
       
       
       #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else 
            Application.Quit();
        #endif
    }
}
        

    // Update is called once per frame