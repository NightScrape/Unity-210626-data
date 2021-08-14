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
    private float hValue ;
    [Header("���O"), Range(0.01f, 1)]
    public float gravity = 1;
    [Header("�ˬd�a�O�ϰ�:�y�лP�b�|")]
    public Vector3 groundOffset;
    [Range(0, 2)]
    public float groundRadius;
    private AudioSource aud;
    private Rigidbody2D rig;
    private Animator ani;
    [Header("�����N�o"),Range(0,5)]
    public float cd = 1;

    #endregion
    #region �ƥ�
    private void Start()
    {
        //GetComponent<>()���x���k,�b<>���i��J�U����
        //�@��:���o�Ӫ��󪺿��餸��
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
    //�T�w��s�ƥ�:�@��T�w��s50��
    //�x���ĳ�ϥΨ쪫�zAPI�ɩ󦹳B�i��
    private void FixedUpdate()
    {
         Move(hValue);
    }

    //ø�s�ϥ�:�bunity�̭��Ψӻ��U�{���}�o�B�|�bunity���i��
    private void OnDrawGizmos()
    {
        //���M�w�C��Aø�s�ϥ�
        Gizmos.color = new Color(1, 0, 0, 0.3f);
        Gizmos.DrawSphere(transform.position+groundOffset,groundRadius);  //�Q�ζ�ߩM�b�|ø�s�y��
    }
    #endregion
    #region ��k�d��


    /// <summary>
    /// ���o���a��J�������b�V�� �pA,D,��,�k
    /// </summary>
    private void GetPlayerInputHorizontal()
    {
        hValue = Input.GetAxis("Horizontal");  //������:��J.���o�b�V(�b�V�W��)
                                               //�@��:���o���U�������䪺�� �k��1,����-1,�S����0
    }
    /// <summary>
    /// ����
    /// </summary>
    /// <param name="horizontal">���ʪ����k</param>
    private void Move(float horizontal) 
    {
        /**���ʪ��Ĥ@�ؤ�k:�ۭq���O
        //�ϰ��ܼ�:����k������즳�ϰ��,�ȯ�b����k�A��
        //²�g:transform������Transform����
        //posMove=�����e�y��+���a��J������
        //Time.fixedDeltaTime��1/50��
        Vector2 posMove = transform.position + new Vector3(horizontal,-gravity, 0) * movespeed * Time.fixedDeltaTime;
        //����.�y��(�e���y��) 
        rig.MovePosition(posMove);
        */
        /**���ʲĤG�ؤ�k:�ϥαM�פ������O-���w�C */
        rig.velocity = new Vector2(horizontal*movespeed*Time.fixedDeltaTime,rig.velocity.y);
        ani.SetBool("�����}��",horizontal != 0);
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
        //Vector2�i�H�HVector3�N�J�A�t�η|�h��z�b
        // << �첾�B��l ���w�ϼh�y�k: 1 << ���w�ϼh
        Collider2D hit =Physics2D.OverlapCircle(transform.position + groundOffset, groundRadius,1 << 6);

        //�Y�I�쪫��s�b�N�N��b�a�O�W�A�Ϥ���M
        //�P�_���Y�u��1�ӵ����Ÿ��A�i�N�{�������j�A���ٲ�
        if (hit) onfloor = true;
        else onfloor = false;

        ani.SetBool("���D�}��", !onfloor);
        //�p�G���U�ť��� �åB ����b�a�O�W�A�h����|���W���D
        if (Input.GetKeyDown(KeyCode.Space) && onfloor)  //�@�q�����q�g�k
        {
            rig.AddForce(new Vector2(0,jumpheight));
            
        }
    }
    /// <summary>
    /// �]�w�p�ɾ�
    /// </summary>
    private float timer;
    /// <summary>
    ///�T�w�O�_���� 
    /// </summary>
    private bool isAttack;
    /// <summary>
    /// ����
    /// </summary>
    private void Attack()
    {
        if (!isAttack&&Input.GetKeyDown(KeyCode.Mouse0))
        {
            ani.SetTrigger("����Ĳ�o");
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