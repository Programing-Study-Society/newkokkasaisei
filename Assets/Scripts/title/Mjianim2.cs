using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Callbacks;
using Unity.VisualScripting;
using UnityEngine.UI;
using TMPro;

public class Mjianim2 : MonoBehaviour
{
    // Start is called before the first frame update
   public Color image1,imagee2;
   bool flug = false;
  public  GameObject textMeshPro,imagee1,image2,canvas;
  public Color textMeshProUGUI;
  public Animator animator;
  public CanvasGroup canvasgroop;
    void Start()
    {  //image1
        imagee1 = GameObject.Find("Image");
        image1 = imagee1.GetComponent<Image>().color;
        //image2
        image2 = GameObject.Find("Image2");
        imagee2 = image2.GetComponent<Image>().color;
       //TMP
        textMeshPro = GameObject.Find("Text (TMP)");
        textMeshProUGUI = textMeshPro.GetComponent<TextMeshProUGUI>().color;
        animator = textMeshPro.GetComponent<Animator>();
        //canvas
        canvas = GameObject.Find("Canvas2");
        canvasgroop = canvas.GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        Mojianimation2();
    }

    void FixedUpdate()
    {
        if(flug)
        {
            //だんだんtmpの文字が透明になる
            if(textMeshProUGUI.a <= 0.0f)
            {
                Destroy(textMeshPro);
               
            }
            else
            {
                textMeshProUGUI.a -= 1.0f * Time.deltaTime;
                textMeshPro.GetComponent<TextMeshProUGUI>().color = textMeshProUGUI;
            }

            //だんだん画像が透明になり下の画像があらわになる
            if(image1.a <= 0)
            {
                Destroy(imagee1);
                Invoke("Mojianimation3",5);
            }
            else
            {
                image1.a -= 1.0f * Time.deltaTime;
                imagee1.GetComponent<Image>().color = image1;
            }
            
        }
    }
    public void Mojianimation2()
    {
        if(Input.GetKey(KeyCode.Space) && !flug)
        { 
           animator.enabled = false;
           flug = true;
        }
    }

    public void Mojianimation3()
    {
        if(imagee2.a <= 0)
        {
            Destroy(image2.gameObject);
            canvasgroop.alpha = 1;
            canvasgroop.interactable = true;
        }
        else
        {
            imagee2.a -= 1.0f * Time.deltaTime;
            image2.GetComponent<Image>().color = imagee2;
        }
    }

   
}
