using UnityEngine;
using System.Collections;  //協同程序
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
        hit = Physics2D.OverlapBox(transform.position + transform.right *
            checkAttackOffset.x + transform.up * checkAttackOffset.y, checkAttaackSize, 0, 1 << 7);
        if (hit) state = StateEnemy.attack;
    }
    protected override void AttackMethod()
    {
        base.AttackMethod();
        StartCoroutine(DamageDelayed());
    }
    /*協同程序用法
     * 1.引用協同程序API System.Collection
     * 2.傳回方法、類型為IEnumerator
     * 3.以StartCoroutine()啟動程序
     */
    /// <summary>
    /// 延遲傳遞傷害
    /// </summary>
    private IEnumerator DamageDelayed()
    {
        //取得陣列數量語法:陣列欄位.Length
        for (int i = 0; i < attacksDelay.Length; i++)
        {
            //取得陣列資料語法:陣列欄位[編號]
            yield return new WaitForSeconds(attacksDelay[i]);
            if (hit) player.Injure(atk);  //若碰撞區域存在，則造成相應傷害
            //等待攻擊後恢復時間
            yield return new WaitForSeconds(attackRestore);
            //若玩家還在區域內則攻擊，否則就執行其他指令
            int stateRandom = Random.Range(0, 2);
            if (hit) state = StateEnemy.attack;
            else 
            {
                if (stateRandom == 0) state = StateEnemy.idle;
                else state = StateEnemy.walk;
            }
        }
    }
    #endregion
}
