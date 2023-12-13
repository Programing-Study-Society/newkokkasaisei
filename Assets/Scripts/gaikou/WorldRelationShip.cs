using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldRelationShip : MonoBehaviour
{
    [Header("アメリカ関係値")] public CountryRelationShip america;
    [Header("日本関係値")] public CountryRelationShip japan;
    [Header("インド関係値")] public CountryRelationShip india;
    [Header("ドイツ関係値")] public CountryRelationShip germany;
    [Header("コンゴ関係値")] public CountryRelationShip kongo;
    public List<CountryRelationShip> worldCountry;
}
