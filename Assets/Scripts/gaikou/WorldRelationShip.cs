using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldRelationShip : MonoBehaviour
{
    [Header("�A�����J�֌W�l")] public CountryRelationShip america;
    [Header("���{�֌W�l")] public CountryRelationShip japan;
    [Header("�C���h�֌W�l")] public CountryRelationShip india;
    [Header("�h�C�c�֌W�l")] public CountryRelationShip germany;
    [Header("�R���S�֌W�l")] public CountryRelationShip kongo;
    public List<CountryRelationShip> worldCountry;
}
