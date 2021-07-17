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
  public  int cc = 2000;
  public  string brand = "賓士";
  public  bool windowSky = true;
  
    //可以使用中文，但不建議，除非獨立製作或團隊許可 (因編碼問題及效能轉換
    //欄位屬性:輔助欄位添加額外功能
    /*語法=[屬性名稱(屬性值)] 字串須以""標註 
     * 如:標題Header
     * 標題Tooltip
     * 範圍Range(最小值,最大值) 僅限使用int及float
     */
  public  int 輪胎數量 = 4;
    [Header("窗戶組數")]
  public  int windownumber = 4;
    [Tooltip("欄位設定是標示物體的高度")]
  public float height = 1.5f;
    [Range(2, 10)]
    public int doorcount;
    #endregion

    #region 其他類型
    //顏色 Color
    public Color color1;  //默認顏色為黑
    public Color blue = Color.blue;  //使用預設顏色
    public Color colorcustom1 = new Color(0.5f, 0.5f,0);  //自訂顏色:RGB
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

    }
    //更新事件:處理物件移動或監聽玩家輸入，頻率約為60fps(每秒60幀)
    private void Update()
    {
        print("我被困住了 !");  
    }
    #endregion

}