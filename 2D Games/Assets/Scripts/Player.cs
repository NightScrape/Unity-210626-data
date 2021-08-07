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
    #region �ƥ�
    private void Start()
    {
        //GetComponent<>()���x��o�k,�b<>���i��J�U����
        //�@��:���o�Ӫ��󪺿��餸��
        rig = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        GetPlayerInputHorizontal();
        TurnDirection();
        Jump();
    }
    //�T�w��s�ƥ�:�@��T�w��s50��
    //�x���ĳ�ϥΨ쪫�zAPI�ɩ󦹳B�i��
    private void FixedUpdate()
    {
         Move(hValue);
    }
    #endregion
    #region ��k�d��

    private float hValue ;
    [Header("���O"), Range(0.01f, 1)]
    public float gravity = 1;
    /// <summary>
    /// ���o���a��J�������b�V�� �pA,D,��,�k
    /// </summary>
    private void GetPlayerInputHorizontal()
    {
        hValue = Input.GetAxis("Horizontal");  //������:��J.���o�b�V(�b�V�W��)
                                               //�@��:���o���U�������䪺�� �k��1,����-1,�S����0
        print("���a������"+hValue);
    }
    /// <summary>
    /// ����
    /// </summary>
    /// <param name="horizontal">���ʪ����k</param>
    private void Move(float horizontal) 
    {
        //�ϰ��ܼ�:����k������즳�ϰ��,�ȯ�b����k�A��
        //²�g:transform������Transform����
        //posMove=�����e�y��+���a��J������
        //Time.fixedDeltaTime��1/50��
        Vector2 posMove = transform.position + new Vector3(horizontal,-gravity, 0) * movespeed * Time.fixedDeltaTime;
        //����.�y��(�e���y��) 
        rig.MovePosition(posMove);
    }
    /// <summary>
    /// �����V:�B�z���⭱�V  �V�k��0 �V��180
    /// </summary>
    private void TurnDirection()
    {
        //�p�G���a��D�A�h���׳]�w��(0,0,0)
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.eulerAngles = Vector3.zero;
        }
        //�p�G���a��A�A�h���׳]�w��(0,180,0)
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
    /// <summary>
    /// ���D
    /// </summary>
    private void Jump()
    {
        //�p�G���U�ť���A�h����|���W���D
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rig.AddForce(new Vector2(0,jumpheight));
            
        }
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