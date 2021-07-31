using UnityEngine;

public class APINonStatic : MonoBehaviour
{
   
    public Transform traA;
    public Camera cam;
    public Transform traB;
    public Light lightA;
    public Camera camA;
    public SpriteRenderer sprA;
    public SpriteRenderer sprB;
    public Transform traC;
    public Rigidbody2D rig2D;
    //取得非靜態屬性
    //1.定義此非靜態屬性的類別欄位
    //2.欄位必須放入要取資訊的物件  (不能為空值)
    private void Start()
    { 
        #region 認識非靜態屬性
        //1.取得非靜態屬性
        //print("取得座標:" + Transform.position); 錯誤-非靜態屬性需有物件參考
        //使用非靜態屬性  語法 欄位.非靜態屬性
        print("取得立方體座標:"+traA.position);
        print("取得攝影機的背景顏色"+cam.backgroundColor);
        //2.設定非靜態屬性 語法 欄位.非靜態屬性+指定+值
        cam.backgroundColor = new Color(0.8f, 0.5f, 0.6f);

        //3.呼叫非靜態屬性 語法 欄位.非靜態屬性(對應引數)
        traB.Translate(1, 0, 0);
        lightA.Reset();
        #endregion

        #region 練習
        print("攝影機深度"+camA.depth);
        print("圖片顏色" + sprA.color);
        camA.backgroundColor = Random.ColorHSV();
        sprB.flipY = true;
        #endregion
    }
    private void Update()
    {
        traC.Rotate(0,0,1);
        rig2D.AddForce(new Vector2(0,10));
    }
}
