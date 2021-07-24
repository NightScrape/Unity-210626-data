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
    #region 方法範例
    /// <summary>
    /// 移動
    /// </summary>
    /// <param name="horizontal">移動的左右</param>
    private void Move(float horizontal) { 
    }
    /// <summary>
    /// 跳躍
    /// </summary>
    private void Jump()
    {

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