using UnityEngine;
/// <summary>
/// 設定攝影機追蹤
/// </summary>
public class CameraControl : MonoBehaviour
{
    #region 欄位
    [Header("追蹤速度"), Range(0, 100)]
    public float speed = 10;
    [Header("要追蹤的物件名稱")]
    public string nameTarget;
    [Header("左右限制")]
    public Vector2 limitHorizon;
    /// <summary>
    /// 要追蹤的物件名稱
    /// </summary>
    private Transform target;
    #endregion
    #region 事件
    private void Start()
    {
        //因為很吃效能，所以建議在Start使用
        //目標變形元件=遊戲物件.尋找(物件名稱).變形元件
        target = GameObject.Find(nameTarget).transform;
    }
    //較慢更新:在Update後執行,建議用來操縱攝影機
    private void LateUpdate()
    {
        Track();
    }
    #endregion
    #region 方法
    /// <summary>
    /// 追蹤物件
    /// </summary>
    private void Track()
    {
        Vector3 PosCam = transform.position;  //A:攝影機座標
        Vector3 PosTar = target.position;  //B:目標物座標
        //運算後結果座標:取得攝影機及目標物之間的座標
        Vector3 PosResult = Vector3.Lerp(PosCam, PosTar, speed * Time.deltaTime);
        //攝影機Z軸需放回預設-10以免無法看到物件
        PosResult.z = -10;
        //使用夾住API限制攝影機的左右範圍
        PosResult.x = Mathf.Clamp(PosResult.x,limitHorizon.x,limitHorizon.y);
        //此物件的座標改為運算後的座標
        transform.position = PosResult;
    }
    #endregion
}
