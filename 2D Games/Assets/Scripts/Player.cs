using UnityEngine;

public class Player : MonoBehaviour
{
    #region 欄位範例
    [Header("移動速度"),Range(0,1000)]
    public float movespeed = 10.5f;
    [Header("跳躍高度"), Range(0, 3000)]
    public int jumpheight = 100;
    [Range(0, 200)]
    public float hp = 100;
    [Header("是否在地板上"), Tooltip("顯示角色當前是否在地板上")]
    public bool onfloor;

    private AudioSource aud;
    private Rigidbody2D rig;
    private Animator ani;

    #endregion
    #region 事件
    private void Start()
    {
        //GetComponent<>()為泛行發法,在<>中可輸入各類型
        //作用:取得該物件的鋼體元件
        rig = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        GetPlayerInputHorizontal();
        TurnDirection();
        Jump();
    }
    //固定更新事件:一秒固定更新50次
    //官方建議使用到物理API時於此處進行
    private void FixedUpdate()
    {
         Move(hValue);
    }
    #endregion
    #region 方法範例

    private float hValue ;
    [Header("重力"), Range(0.01f, 1)]
    public float gravity = 1;
    /// <summary>
    /// 取得玩家輸入的水平軸向值 如A,D,左,右
    /// </summary>
    private void GetPlayerInputHorizontal()
    {
        hValue = Input.GetAxis("Horizontal");  //水平值:輸入.取得軸向(軸向名稱)
                                               //作用:取得按下水平按鍵的值 右為1,左為-1,沒按為0
        print("玩家水平值"+hValue);
    }
    /// <summary>
    /// 移動
    /// </summary>
    /// <param name="horizontal">移動的左右</param>
    private void Move(float horizontal) 
    {
        //區域變數:此方法內的欄位有區域性,僅能在此方法適用
        //簡寫:transform此物件的Transform元件
        //posMove=角色當前座標+玩家輸入水平值
        //Time.fixedDeltaTime為1/50秒
        Vector2 posMove = transform.position + new Vector3(horizontal,-gravity, 0) * movespeed * Time.fixedDeltaTime;
        //剛體.座標(前往座標) 
        rig.MovePosition(posMove);
    }
    /// <summary>
    /// 旋轉方向:處理角色面向  向右為0 向左180
    /// </summary>
    private void TurnDirection()
    {
        //如果玩家按D，則角度設定為(0,0,0)
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.eulerAngles = Vector3.zero;
        }
        //如果玩家按A，則角度設定為(0,180,0)
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
    /// <summary>
    /// 跳躍
    /// </summary>
    private void Jump()
    {
        //如果按下空白鍵，則角色會往上跳躍
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rig.AddForce(new Vector2(0,jumpheight));
            
        }
    }
    /// <summary>
    /// 攻擊
    /// </summary>
    private void Attack()
    {

    }
    /// <summary>
    ///受傷 
    /// </summary>
    /// <param name="damage">造成的傷害</param>
    public void Injure(float damage)
    {

    }
    /// <summary>
    /// 死亡
    /// </summary>
    private void Death() { 
    }
    /// <summary>
    /// 吃道具
    /// </summary>
    /// <param name="PropName">道具名稱</param>
    private void EatProp(string PropName)
    {

    }
    #endregion 
}