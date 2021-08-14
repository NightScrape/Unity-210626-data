using UnityEngine;
using System.Linq;  //引用LinQ查詢API-查找陣列資料

public class LearnLinQ : MonoBehaviour
{
    public int[] scores = { 10, 80, 60, 30, 70, 99, 77, 0, 1 };
    public int[] result;
    public int[] resultEqualThan60;
    private void Start()
    {
        //檢查有沒有0分
        //黏巴達 Lambda C#3.0之後的簡寫模式
        //檢查當前有無為0的值
        //x 為代名詞, =>為設定條件
        result=scores.Where(x => x == 0 ).ToArray();

        //檢查有沒有大於等於60分
        resultEqualThan60=scores.Where(y => y >= 60).ToArray();
    }
}
