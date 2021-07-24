using UnityEngine;   //引用Unity引擎提供API(Unity Engine命名空間)

public class Car : MonoBehaviour  //修飾詞+類別(關鍵字)+腳本名稱
{
    #region 欄位說明及四大語法

    //欄位:儲存簡單資料
    //語法:修飾詞  資料類型 欄位名稱 指定符號(=) 預設值 結尾
    /*整數 int 全部整數包含0
     *浮點數 float  所有包含小數點之數值
     *字串 string 適用角色、物品之名稱或角色對話，可包含特殊字元
     *布林值(boolean) bool 顯示狀態(True、False)
     */
    //定義欄位
    public float weight = 3.5f;
    public int cc = 2000;
    public string brand = "賓士";
    public bool windowSky = true;

    //可以使用中文，但不建議，除非獨立製作或團隊許可 (因編碼問題及效能轉換
    //欄位屬性:輔助欄位添加額外功能
    /*語法=[屬性名稱(屬性值)] 字串須以""標註 
     * 如:標題Header
     * 標題Tooltip
     * 範圍Range(最小值,最大值) 僅限使用int及float
     */
    public int 輪胎數量 = 4;
    [Header("窗戶組數")]
    public int windownumber = 4;
    [Tooltip("欄位設定是標示物體的高度")]
    public float height = 1.5f;
    [Range(2, 10)]
    public int doorcount;
    #endregion

    #region 其他類型
    //顏色 Color
    public Color color1;  //默認顏色為黑
    public Color blue = Color.blue;  //使用預設顏色
    public Color colorcustom1 = new Color(0.5f, 0.5f, 0);  //自訂顏色:RGB
    public Color colorcustom2 = new Color(0.5f, 0, 0.5f, 0.5f);  //自訂顏色:RGB+透明度

    //座標:2-4維 Vector (保存數值及浮點數)
    public Vector2 v2;
    public Vector2 v2zero = Vector2.zero;
    public Vector2 v2one = Vector2.one;
    public Vector2 v2Up = Vector2.up;
    public Vector2 v2Right = Vector2.right;
    public Vector2 v2custom = new Vector2(20, -60);

    //按鍵類型 Keycode
    public KeyCode kc;
    public KeyCode forward = KeyCode.D;
    public KeyCode attack = KeyCode.Mouse0; //左鍵0 右鍵1 滾輪2

    //遊戲物件GameObject與元件
    public GameObject GoCamera; //遊戲物件包含場景上和專案內的欲置物
    public Transform Cartrs;
    public SpriteRenderer sprPic;

    #endregion

    #region 事件
    //開始事件:撥放遊戲時觸發一次，處理初始化
    private void Start()
    {//輸出資料(包含任意類型)
        print("Hello World !");

        //取得欄位資料 Get
        print(brand);
        //設定欄位資料 Set
        cc = 5000;
        windowSky = true;
        weight = 10.8f;
        //呼叫方法之語法範例(需先建構方法)
        Drive50();
        Drive100();
        Drive(75,"de javu");  //呼叫中小括號內的為限定"方法"的"引述",需輸入對應的類型
        Drive(150,"你給路打優");
        Drive(120);  //有預設值的參數以預設值為主，可以不輸入"引述"
        Drive(60, "灰塵"); //複數含預設值之參數被引述時會依順序導入，導致導出結果與設想不符(導出結果為時速60,音效灰塵,效果碎石)
        Drive(60, effect: "灰塵"); //加入欲改變之參數名稱:設定值 更改出設想引述

        float kg = KG();  //區域變數，僅此括號內使用
        print("轉為公斤的資訊"+kg);

        print("BMI指數:" + BMI(60, 1.6f)); 
    }
    //更新事件:處理物件移動或監聽玩家輸入，頻率約為60fps(每秒60幀)
    private void Update()
    {
        print("我被困住了 !");
    }
    #endregion


    #region 方法 
    /*Method,又稱函式、功能
     * 語法為 修飾詞+傳回類型(四大類型+void(無傳回))+名稱+(參數)+{程式區塊}，不用分號進行結尾!!!
     * 程式區塊內才需要分號
     * 定義方法的句子不會自動執行，執行需要在事件內呼叫
     * 呼叫方法:方法名稱(引述);
     */
    private void Drive50() {
        print("開車中，時數50");

    }
    private void Drive100()
    {
        print("開車中，時數100");

    }
    /*程式需考量擴充性&維護性，參數可有效提升
    *參數語法:類型+參數名稱，寫在小括號內且僅在方法內可用
    *多個參數用逗號相隔，且數量無上限 如:參數1,參數2,...
    *參數可設定預設值，語法為類型+參數名稱+指定值，預設值須放在參數"最右方"
    */
    /// <summary>
    /// 這是開車的方法，用以控制車子的速度、音效及特效
    /// </summary>
    /// <param name="speed">設定車子的移動速度</param>
    /// <param name="sound">設定開車時播放的音效</param>
    /// <param name="effect">設定開車時的特效</param>
    private void Drive (int speed, string sound = "梗梗梗~",string effect= "碎石"){
        print("開車中，時速" + speed);
        print("音效"+sound);
        print("效果"+effect);
}
    /// <summary>
    /// 重量轉換:公噸轉為公斤
    /// </summary>
    /// <returns>轉為公斤的重量資訊</returns>
    private float KG()
    {
        return weight*1000;
    }
    private float BMI(float weight,float height)
    {
        return weight / (height * height);
    }
    #endregion
}