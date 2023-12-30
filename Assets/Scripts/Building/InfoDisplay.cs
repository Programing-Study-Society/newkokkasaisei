using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoDisplay : MonoBehaviour
{
    public TextMeshProUGUI objName;
    public TextMeshProUGUI costV;
    public TextMeshProUGUI industryPowerV;
    public TextMeshProUGUI armamentsPowerV;
    public TextMeshProUGUI populationV;

    public void Display(GameObject obj)
    {
        // objのスクリプトを取得
        BuildingInfo buildingInfo = obj.GetComponent<BuildingInfo>();

        // 各TextMeshProUGUIにテキストを代入
        objName.text = obj.name;
        costV.text = buildingInfo.cost.ToString("+#,##0;-#,##0;0");
        industryPowerV.text = buildingInfo.industryPower.ToString("+#,##0;-#,##0;0");
        armamentsPowerV.text = buildingInfo.armamentsPower.ToString("+#,##0;-#,##0;0");
        populationV.text = buildingInfo.population.ToString("+#,##0;-#,##0;0");
    }
}
