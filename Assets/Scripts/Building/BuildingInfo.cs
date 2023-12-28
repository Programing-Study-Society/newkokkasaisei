using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingInfo : MonoBehaviour
{
    public int objID; // オブジェクトのID(どのゲームオブジェクトを使用しているか)
    public int population; // 人口増減度
    public int cost; // 所持金増減度
    public int armamentsPower; // 軍備力増減度
    public int industryPower; // 工業力増減度
}