using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class globalValue
{
    //チュートリアルデータ
    public  static int lineNumber = 0;
    public static int eventNumber = 0;//追加　変数：イベントの番号
    public static bool eventExecution = false;
    public static bool first = true;
    public static RectTransform canvas;

    //人口
    public static ulong population = 0;

    //所持金データ
    public static ulong money = 0;// 追加　int --> ulong
    public static ulong gigaMoney = 0;// 追加　int --> ulong
    public static double tradeSize = 0.0;　//追加　変数：貿易で追加するお金の倍率

    //国民不満ゲージデータ
    public static float complain = 0.0f;
    public static float complainMax = 100.0f;
    
    //年月日データ
    public static int yearNumber = 1;
    public static int monthNumber = 1;
    public static int dayNumber = 1;

    //軍備力
    public static int armamentsPower = 0;

    //工業力
    public static int industryPower = 0;

    //外交度
    public static int diplomacyDegrees = 0;

    //国力
    public static int countryPower = 0;

    //テキスト速度
    public static float textSpeed = 0.05f;

    //カメラ速度
    public static float sensitiveMove = 0.4f;
    public static float sensitiveZoom = 5.0f;
}
