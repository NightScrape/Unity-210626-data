using UnityEngine;
using System.Linq;
/// <summary>
/// 敵人基底類別
/// 作用:設置敵方隨機行動、追蹤玩家、等待、受傷及死亡
/// 狀態:列舉Enum、判斷式 Switch (基礎語法)
/// </summary>
public class EnemyBase : MonoBehaviour

{
    #region 公開欄位
    [Header("基本屬性")]
    [Range(50, 5000)]
    public float hp = 100;
    [Range(5, 1000)]
    public float atk = 20;
    [Range(1, 500)]
    public float speed = 1.5f;
    /// <summary>
    /// 隨機等待時間
    /// </summary>
    public Vector2 v2IdleRandom = new Vector2(2, 5);
    /// <summary>
    /// 隨機走路時間
    /// </summary>
    public Vector2 v2WalkRandom = new Vector2(3, 6);
    [Range(0.5f, 5)]
    public float cdAttack = 2;
    private float timerAttack;
    /// <summary>
    /// 用陣列保存相同類型的表格，擁有編號與值兩份資料
    /// </summary>
    [Header("攻擊延遲,可自行設定數量"), Range(0, 5)]
    public float[] attacksDelay;
    [Header("攻擊完成後多久恢復原本狀態"), Range(0, 5)]
    public float attackRestore = 1;
    [Header("掉落道具資料與機率")]
    public GameObject goProp;
    [Range(0, 1)]
    public float propProbability = 0.5f;
    #endregion
    #region 不公開欄位
    //將私人欄位顯示於屬性面板上
    [SerializeField]
    protected StateEnemy state;

    private Rigidbody2D rig;
    private Animator ani;
    private AudioSource aud;

    /// <summary>
    /// 設置隨機等待時間
    /// </summary>
    private float timeIdle;
    /// <summary>
    /// 設置等待計時器
    /// </summary>
    private float timerIdle;
    private float timeWalk;
    private float timerWalk;

    #endregion
    /// <summary>
    /// 攻擊區域的碰撞:保存玩家是否進入攻擊區域與玩家碰撞
    /// </summary>
    protected Collider2D hit;
    protected Player player;
    #region 事件
    private void Start()
    {
        #region 取得元件
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();

        player = GameObject.Find("玩家").GetComponent<Player>();
        #endregion
        #region 設定初始值
        timeIdle = Random.Range(v2IdleRandom.x, v2IdleRandom.y);
        #endregion
    }
    protected virtual void Update()
    {
        CheckForward();
        CheckState();
    }
    private void FixedUpdate()
    {
        WalkInFixedUpdate();
    }
    [Header("檢測前方有無障礙物或地板")]
    public Vector3 checkForwardOffset;
    [Range(0, 1)]
    public float checkForwardRadius = 0.3f;
    /*父類別成員希望子類別複寫須遵循
     * 1.修飾詞必須要是public(任意皆可使用) 或protected(唯子類別可用)
     * 2.父類別成員需於類型前添加virtual虛擬 (上述兩項作用皆為允許子類別複寫)
     * 3.子類別成員需於類型前添加override複寫
     */
    protected virtual void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0.3f, 0.3f, 0.4f);
        Gizmos.DrawSphere(transform.position + transform.right *
            checkForwardOffset.x + transform.up * checkForwardOffset.y, checkForwardRadius);
    }
    #endregion
    //陣列語法:任意可用類型+中括號 如:int[],float[],vector2[]
    public Collider2D[] hits;
    /// <summary>
    /// 存放前方是否有不包含地板及跳台之物件
    /// </summary>
    public Collider2D[] hitResult;
    #region 方法
    /// <summary>
    /// 偵測前方是否有地板或障礙物
    /// </summary>
    private void CheckForward()
    {
        hits = Physics2D.OverlapCircleAll(transform.position + transform.right *
            checkForwardOffset.x + transform.up * checkForwardOffset.y, checkForwardRadius);
        /*兩種情況都要進行轉向，以免撞到障礙物及掉落
         * 1.陣列內有非地板及跳台的物件:為遇到障礙物
         * 2.陣列內是空的:表示沒地方站立
         * 查詢LinQ:可以查詢陣列內有無資料及有無特定資料
         */
        hitResult = hits.Where(x => x.name != "跳台" && x.name != "地板" && x.name != "玩家" && x.name != "可穿越跳台" && x.name != "巫師").ToArray();
        if (hits.Length == 0 || hitResult.Length != 0)
        {
            TurnDirection();
        }
    }
    /// <summary>
    /// 轉向
    /// </summary>
    private void TurnDirection()
    {
        float y = transform.eulerAngles.y;
        if (y == 0) transform.eulerAngles = Vector2.up * 180;
        else transform.eulerAngles = Vector2.zero;
    }
    /// <summary>
    /// 檢查狀態
    /// </summary>
    private void CheckState()
    {
        switch (state)
        {
            case StateEnemy.idle:
                Idle();
                break;
            case StateEnemy.walk:
                Walk();
                break;
            case StateEnemy.track:
                break;
            case StateEnemy.attack:
                Attack();
                break;
            case StateEnemy.dead:
                break;
        }

    }
    /// <summary>
    /// 等待:在隨機秒數後執行走路狀態
    /// </summary>
    private void Idle()
    {
        if (timerIdle < timeIdle) //如果計時器<等待時間
        {
            timerIdle += Time.deltaTime; //增加時間
            ani.SetBool("走路開關", false);
        }
        else //否則
        {
            RandomDirection();
            timerIdle = 0;  //計時器歸零
            timeWalk = Random.Range(v2WalkRandom.x, v2WalkRandom.y);  //設定其後的隨機走路時間
            state = StateEnemy.walk;  //改變狀態為走路
        }
    }
    /// <summary>
    /// 隨機走路
    /// </summary>
    private void Walk()
    {
        if (timerWalk < timeWalk)
        {
            timerWalk += Time.deltaTime;
            ani.SetBool("走路開關", true);
        }
        else
        {
            rig.velocity = Vector2.zero;
            state = StateEnemy.idle;
            timeIdle = Random.Range(v2IdleRandom.x, v2IdleRandom.y);
            timerWalk = 0;
        }
    }
    /// <summary>
    /// 將物理行為單獨處理並於fixedupdate呼叫
    /// </summary>
    private void WalkInFixedUpdate()
    {
        if (state == StateEnemy.walk) rig.velocity = transform.right * speed * Time.deltaTime + Vector3.up * rig.velocity.y;
    }
    /// <summary>
    /// 隨機方向:隨機面向左邊或右邊 (右:(0,0,0)左(0,180,0))
    /// </summary>
    private void RandomDirection()
    {
        int random = Random.Range(0, 2); //隨機.範圍(最小,最大) 若需得出整數會忽略最大值-隨機取得0,1
        if (random == 0) transform.eulerAngles = Vector2.up * 180;
        else transform.eulerAngles = Vector2.zero;
    }
    private void Attack()
    {
        if (timerAttack < cdAttack)
        {
            timerAttack += Time.deltaTime;
            ani.SetBool("走路開關", false);
        }
        else
        {
            AttackMethod();
        }
    }
    /// <summary>
    /// 子類別可以決定如何決定的方法
    /// </summary>
    protected virtual void AttackMethod()
    {
        timerAttack = 0;
        ani.SetTrigger("攻擊觸發");
    }
    public void Hurt(float damage)
    {
        hp -= damage;
        ani.SetTrigger("受傷觸發");
        if (hp <= 0) Dead();
    }
    /// <summary>
    /// 死亡:死亡動畫、狀態、關閉腳本、碰撞氣、加速度及剛體凍結
    /// </summary>
    private void Dead()
    {
        hp = 0;
        ani.SetBool("死亡動畫", true);
        state = StateEnemy.dead;
        GetComponent<CapsuleCollider2D>().enabled = false;  //關閉碰撞器
        rig.velocity = Vector3.zero;  //加速度歸零
        rig.constraints = RigidbodyConstraints2D.FreezeAll;  //剛體全部凍結
        DropProp();
        enabled = false;

    }
    private void DropProp()
    {
        if(Random.value <= propProbability)
        {
            //生成(物件,座標,角度)
            //Quaternion.identity 為零角度=vector3.zero
            Instantiate(goProp, transform.position + Vector3.up * 0.5f, Quaternion.identity);
        }
    }
    #endregion

    /*定義列舉
     * 1.使用關鍵字enum定義列舉以及包含的選項，可在類別外定義
     * 2.需要有一個欄位為此列舉類型
     * 3.語法: 修飾詞enum 列舉名稱{選項1,選項2,...選項n}
     */
    public enum StateEnemy
    {
        idle, walk, track, attack, dead
    }
}