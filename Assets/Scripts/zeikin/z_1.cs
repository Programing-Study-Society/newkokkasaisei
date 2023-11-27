/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class z_1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        while(true)
        {
            Debug.Log("消費税なら1　法人税なら2　関税なら3　を選んでください");
            int q = int.Parse(Console.ReadLine());
            if (q == 1)
            {
                Debug.Log("税率は何パーセント？");
                long n = long.Parse(Console.ReadLine());
                Debug.Log("お金はいくら入る？");
                long u = long.Parse(Console.ReadLine());
                Debug.Log("今月の収支は");
                Debug.Log(u + u * n / 100);
                break;
            }
            else if (q == 2)
            {
                Debug.Log("税率は何パーセント？");
                long w = long.Parse(Console.ReadLine());
                Debug.Log("お金はいくら入る？");
                long e = long.Parse(Console.ReadLine());
                Debug.Log("今月の収支は");
                Debug.Log(e + e * w / 100);
                break;
            }
            else if (q == 3)
            {
                Debug.Log("税率は何パーセント？");
                long r = long.Parse(Console.ReadLine());
                Debug.Log("お金はいくら入る？");
                long t = long.Parse(Console.ReadLine());
                Debug.Log("今月の収支は");
                Debug.Log(t + t * r / 100);
                break;
            }
            else
            {
                Debug.Log("数字を入力してください");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
*/