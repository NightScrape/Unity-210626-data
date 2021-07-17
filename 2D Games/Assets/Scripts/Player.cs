using UnityEngine;

public class Player : MonoBehaviour
{
    #region 範例1
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
}