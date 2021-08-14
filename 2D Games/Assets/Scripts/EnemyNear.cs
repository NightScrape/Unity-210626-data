using UnityEngine;
/// <summary>
/// 近距離敵人類型:近距離攻擊
/// </summary>
//類別:父類別(此類別為被繼承的類別)
public class EnemyNear : EnemyBase
{
    #region 欄位
    [Header("攻擊區域的位移及大小")]
    public Vector2 checkAttackOffset;
    public Vector3 checkAttaackSize;
    #endregion
    #region 事件
    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos(); //此為父類別的原先資料
        Gizmos.color = new Color(0.2f, 0.8f, 0.8f, 0.3f);
        Gizmos.DrawCube(transform.position + transform.right *
            checkAttackOffset.x + transform.up * checkAttackOffset.y, checkAttaackSize);
    }
    protected override void Update()
    {
        base.Update();
        CheckPlayerInAttackArea();
    }
    #endregion
    #region 方法
    /// <summary>
    /// 偵測玩家是否出現於攻擊區域內
    /// </summary>
    private void CheckPlayerInAttackArea()
    {
        Collider2D hit = Physics2D.OverlapBox(transform.position + transform.right *
            checkAttackOffset.x + transform.up * checkAttackOffset.y, checkAttaackSize,0,1 << 7);
        if (hit) state = StateEnemy.attack;
    }
    #endregion
}
