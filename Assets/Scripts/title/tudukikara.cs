using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

[RequireComponent(typeof(Button))]
public class tudukikara : MonoBehaviour
{
    // Start is called before the first frame update
 
   
 void Start()
{
   tuduki();
}

public void tuduki()
    {
       var button = GetComponent<Button>();
       button.onClick.AddListener(() =>
       {
        SceneManager.LoadScene("Scene2");
       });
    }
}   


    // Update is called once per frame
    
