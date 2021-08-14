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
    private float hValue ;
    [Header("重力"), Range(0.01f, 1)]
    public float gravity = 1;
    [Header("檢查地板區域:座標與半徑")]
    public Vector3 groundOffset;
    [Range(0, 2)]
    public float groundRadius;
    private AudioSource aud;
    private Rigidbody2D rig;
    private Animator ani;
    [Header("攻擊冷卻"),Range(0,5)]
    public float cd = 1;

    #endregion
    #region 事件
    private void Start()
    {
        //GetComponent<>()為泛行方法,在<>中可輸入各類型
        //作用:取得該物件的鋼體元件
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }
    private void Update()
    {
        GetPlayerInputHorizontal();
        TurnDirection();
        Jump();
        Attack();
    }
    //固定更新事件:一秒固定更新50次
    //官方建議使用到物理API時於此處進行
    private void FixedUpdate()
    {
         Move(hValue);
    }

    //繪製圖示:在unity裡面用來輔助程式開發且會在unity內可見
    private void OnDrawGizmos()
    {
        //先決定顏色再繪製圖示
        Gizmos.color = new Color(1, 0, 0, 0.3f);
        Gizmos.DrawSphere(transform.position+groundOffset,groundRadius);  //利用圓心和半徑繪製球體
    }
    #endregion
    #region 方法範例


    /// <summary>
    /// 取得玩家輸入的水平軸向值 如A,D,左,右
    /// </summary>
    private void GetPlayerInputHorizontal()
    {
        hValue = Input.GetAxis("Horizontal");  //水平值:輸入.取得軸向(軸向名稱)
                                               //作用:取得按下水平按鍵的值 右為1,左為-1,沒按為0
    }
    /// <summary>
    /// 移動
    /// </summary>
    /// <param name="horizontal">移動的左右</param>
    private void Move(float horizontal) 
    {
        /**移動的第一種方法:自訂重力
        //區域變數:此方法內的欄位有區域性,僅能在此方法適用
        //簡寫:transform此物件的Transform元件
        //posMove=角色當前座標+玩家輸入水平值
        //Time.fixedDeltaTime為1/50秒
        Vector2 posMove = transform.position + new Vector3(horizontal,-gravity, 0) * movespeed * Time.fixedDeltaTime;
        //剛體.座標(前往座標) 
        rig.MovePosition(posMove);
        */
        /**移動第二種方法:使用專案內的重力-較緩慢 */
        rig.velocity = new Vector2(horizontal*movespeed*Time.fixedDeltaTime,rig.velocity.y);
        ani.SetBool("走路開關",horizontal != 0);
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
        //Vector2可以以Vector3代入，系統會去掉z軸
        // << 位移運算子 指定圖層語法: 1 << 指定圖層
        Collider2D hit =Physics2D.OverlapCircle(transform.position + groundOffset, groundRadius,1 << 6);

        //若碰到物件存在就代表在地板上，反之亦然
        //判斷式若只有1個結束符號，可將程式中的大括號省略
        if (hit) onfloor = true;
        else onfloor = false;

        ani.SetBool("跳躍開關", !onfloor);
        //如果按下空白鍵 並且 角色在地板上，則角色會往上跳躍
        if (Input.GetKeyDown(KeyCode.Space) && onfloor)  //一段跳普通寫法
        {
            rig.AddForce(new Vector2(0,jumpheight));
            
        }
    }
    /// <summary>
    /// 設定計時器
    /// </summary>
    private float timer;
    /// <summary>
    ///確定是否攻擊 
    /// </summary>
    private bool isAttack;
    /// <summary>
    /// 攻擊
    /// </summary>
    private void Attack()
    {
        if (!isAttack&&Input.GetKeyDown(KeyCode.Mouse0))
        {
            ani.SetTrigger("攻擊觸發");
            isAttack = true;
        }
        if (isAttack)
        {
            if (timer < cd)
            {
                timer += Time.deltaTime;
            }
            else
            {
                timer = 0;
                isAttack = false;
            }
        }

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