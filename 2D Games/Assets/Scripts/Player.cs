using UnityEngine;

public class Player : MonoBehaviour
{
    #region ���d��
    [Header("���ʳt��"),Range(0,1000)]
    public float movespeed = 10.5f;
    [Header("���D����"), Range(0, 3000)]
    public int jumpheight = 100;
    [Range(0, 200)]
    public float hp = 100;
    [Header("�O�_�b�a�O�W"), Tooltip("��ܨ����e�O�_�b�a�O�W")]
    public bool onfloor;

    private AudioSource aud;
    private Rigidbody2D rig;
    private Animator ani;

    #endregion 
    #region ��k�d��
    /// <summary>
    /// ����
    /// </summary>
    /// <param name="horizontal">���ʪ����k</param>
    private void Move(float horizontal) { 
    }
    /// <summary>
    /// ���D
    /// </summary>
    private void Jump()
    {

    }
    /// <summary>
    /// ����
    /// </summary>
    private void Attack()
    {

    }
    /// <summary>
    ///���� 
    /// </summary>
    /// <param name="damage">�y�����ˮ`</param>
    public void Injure(float damage)
    {

    }
    /// <summary>
    /// ���`
    /// </summary>
    private void Death() { 
    }
    /// <summary>
    /// �Y�D��
    /// </summary>
    /// <param name="PropName">�D��W��</param>
    private void EatProp(string PropName)
    {

    }
    #endregion 
}