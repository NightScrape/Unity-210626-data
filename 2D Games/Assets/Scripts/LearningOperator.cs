using UnityEngine;

//認識運算子
//1.數學運算子
public class LearningOperator : MonoBehaviour
{
    public int a = 10;
    public int b = 3;
    public int c = 7;
    public int hp = 80;

    public float ScoreA = 99;
    public float ScoreB = 1;

    public int health = 50;
    public int key = 1;
    public int coin = 4;
    public int jewel = 3;

    void Start()
    {
        #region 數學運算子
        print(a + b);  //13
        print(a - b);  //7
        print(a * b);  //30
        print(a / b);  //3
        print(a % b);  //1
        //遞增
        c = c + 1;  // = 運算符號，先計算右邊在計算左
        c++;        //簡寫
        print("c運算後的結果" + c);
        //扣血12
        hp = hp - 12;
        hp -= 12;
        //回復30(假定無上限
        hp += 30;
        #endregion
        #region 比較運算子
        //> < >= <= == !=
        print("99大於1:"+(ScoreA>ScoreB));
        print("99小於1:" + (ScoreA < ScoreB));
        print("99大於等於1:" + (ScoreA >= ScoreB));
        print("99小於等於1:" + (ScoreA <= ScoreB));
        print("99等於1:" + (ScoreA == ScoreB));
        print("99不等於1:" + (ScoreA != ScoreB));
        #endregion
        #region 邏輯運算子
        print("邏輯運算子");

        print("並且");
        //比較兩者資料
        //並且 &&
        //只要一布林值為false,則結果為false
        print(true && true);
        print(false && true);
        print(true && false);
        print(false && false);
        print("或者");
        //或者 ||
        //只要一布林值為true,則結果為true
        print(true || true);
        print(false || true);
        print(true || false);
        print(false || false);
        //通關條件:擁有1把鑰匙且血量大於0
        print("是否通關" +(key==1&&health>0));
        //通關條件:擁有2顆以上(大於等於)寶石或5個以上金幣
        print("是否通關" + (jewel >= 2 || coin >= 5));

        //相反
        print(!true);
        print(!false);
        #endregion
    }
}