using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

[RequireComponent(typeof(Button))]
public class Hajimekara : MonoBehaviour
{
    // Start is called before the first frame update
 
    void Start()
    {
       hajime();
    }

    void hajime()
    {
       var button = GetComponent<Button>();
       button.onClick.AddListener(() =>
       {
        SceneManager.LoadScene("proken");
       });
    }
}

    // Update is called once per frame
    
