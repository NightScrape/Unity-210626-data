using UnityEngine;

public class Player : MonoBehaviour
{
    #region �d��1
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
}