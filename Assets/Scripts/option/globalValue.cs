using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class globalValue
{
    //チュートリアルデータ
    public  static int lineNumber = 0;
    public static bool eventExecution = true;
    public static bool first = true;
    public static RectTransform canvas;
    
    //所持金データ
    public static int money = 0;
    public static int gigaMoney = 0;

    //国民不満ゲージデータ
    public static float complain = 0.0f;
    public static float complainMax = 100.0f;
    
    //年月日データ
    public static int yearNumber = 1;
    public static int monthNumber = 1;
    public static int dayNumber = 1;

    //テキスト速度
    public static float textSpeed = 0.05f;

    //カメラ速度
    public static float sensitiveMove = 0.4f;
    public static float sensitiveZoom = 5.0f;
}
