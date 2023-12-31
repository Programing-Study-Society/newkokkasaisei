using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class globalValue
{
    //チュートリアルデータ
    public  static int lineNumber = 0;
    public static int rootEventNumber = 0;//追加　変数：イベントの進捗
    public static int randomEventNumber = 0;//追加　変数：進行しているランダムイベントの番号
    public static bool eventExecution = false;
    //削除　public static bool first = true;
    public static RectTransform canvas;
    public static int randomValue = 0;

    //人口
    public static int population = 500;// 追加　ulong --> int

    //所持金データ
    public static int money = 0;
    public static int gigaMoney = 30;
    public static double tradeSize = 0.0;　//追加　変数：貿易で追加するお金の倍率

    //国民不満ゲージデータ
    public static float complain = 50.0f;
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

    //下全て追加
    //音量
    public static float bgmVolume = 0.5f;
    public static float seVolume = 0.5f;

    //外交シーン
    //国
    public static List<string> country = new List<string> { "アメリカ", "日本", "インド", "ドイツ", "コンゴ" };
    //友好度
    public static List<int> friendshipLevel = new List<int> { 50, 30, 30, 30, 30 };
    //経済力
    public static List<int> economicPower = new List<int> { 400, 300, 200, 100, 100 };
    //軍事力
    public static List<int> militaryPower = new List<int> { 400, 300, 100, 400, 100 };
    //貿易品
    public static List<string> tradeGoods = new List<string> { "機械類", "米", "食料品", "海鮮類", "石油" };
    //貿易状況
    public static List<string> tradeSituation = new List<string> { "していない", "していない", "していない", "していない", "していない" };

    // 建築物の種類や座標データ
    public static ObjectData objectData = new ObjectData();

    //建物コスト
    public static int studyNumber = 5;
    public static int[] buildingcos = new int[]{11, 60, 100, 200, 400, 1000, 5400, 28000};//10階建て~(hotel,eigakan,byouin,gakkou,)
    public static string[] buildingstr = new string[]{"ホテル", "映画館", "病院", "学校", "図書館", "公園", "劇場", "博物館"};
}
