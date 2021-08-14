using UnityEngine;
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
    #endregion
    #region 不公開欄位
    //將私人欄位顯示於屬性面板上
    [SerializeField]
    private StateEnemy state;

    private Rigidbody2D rig;
    private Animator ani;
    private AudioSource aud;
    /// <summary>
    /// 隨機等待時間
    /// </summary>
    private Vector2 v2IdleRandom = new Vector2(2, 5);
    /// <summary>
    /// 隨機走路時間
    /// </summary>
    private Vector2 v2WalkRandom = new Vector2(3, 6);
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
    #region 事件
    private void Start()
    {
        #region 取得元件
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
        #endregion
        #region 設定初始值
        timeIdle = Random.Range(v2IdleRandom.x,v2IdleRandom.y);
        #endregion
    }
    private void Update()
    {
        CheckState();
    }
    private void FixedUpdate()
    {
        WalkInFixedUpdate();
    }
    #endregion
    #region 方法
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
        if(timerIdle < timeIdle) //如果計時器<等待時間
        {
            timerIdle += Time.deltaTime; //增加時間
            ani.SetBool("走路開關", false);
        }
        else //否則
        {
            RandomDirection();
            timerIdle = 0;  //計時器歸零
            timeWalk = Random.Range(v2WalkRandom.x,v2WalkRandom.y);  //設定其後的隨機走路時間
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
        if(state==StateEnemy.walk) rig.velocity = transform.right*speed*Time.deltaTime+Vector3.up*rig.velocity.y;
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