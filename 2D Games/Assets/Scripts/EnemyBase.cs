using UnityEngine;
using System.Linq;
/// <summary>
/// �ĤH�����O
/// �@��:�]�m�Ĥ��H����ʡB�l�ܪ��a�B���ݡB���ˤΦ��`
/// ���A:�C�|Enum�B�P�_�� Switch (��¦�y�k)
/// </summary>
public class EnemyBase : MonoBehaviour

{
    #region ���}���
    [Header("���ݩ�")]
    [Range(50, 5000)]
    public float hp = 100;
    [Range(5, 1000)]
    public float atk = 20;
    [Range(1, 500)]
    public float speed = 1.5f;    
    /// <summary>
    /// �H�����ݮɶ�
    /// </summary>
    public Vector2 v2IdleRandom = new Vector2(2, 5);
    /// <summary>
    /// �H�������ɶ�
    /// </summary>
    public Vector2 v2WalkRandom = new Vector2(3, 6);
    /// <summary>
    /// �ΰ}�C�O�s�ۦP���������A�֦��s���P�Ȩ�����
    /// </summary>
    [Header("��������,�i�ۦ�]�w�ƶq"), Range(0, 5)]
    public float[] attacksDelay;
    [Header("����������h�[��_�쥻���A"), Range(0, 5)]
    public float attackRestore = 1;
    #endregion
    #region �����}���
    //�N�p�H�����ܩ��ݩʭ��O�W
    [SerializeField]
    protected StateEnemy state;

    private Rigidbody2D rig;
    private Animator ani;
    private AudioSource aud;

    /// <summary>
    /// �]�m�H�����ݮɶ�
    /// </summary>
    private float timeIdle;
    /// <summary>
    /// �]�m���ݭp�ɾ�
    /// </summary>
    private float timerIdle;
    private float timeWalk;
    private float timerWalk;

    #endregion
    /// <summary>
    /// �����ϰ쪺�I��:�O�s���a�O�_�i�J�����ϰ�P���a�I��
    /// </summary>
    protected Collider2D hit;
    protected Player player;
    #region �ƥ�
    private void Start()
    {
        #region ���o����
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();

        player = GameObject.Find("���a").GetComponent<Player>();
        #endregion
        #region �]�w��l��
        timeIdle = Random.Range(v2IdleRandom.x,v2IdleRandom.y);
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
    [Header("�˴��e�観�L��ê���Φa�O")]
    public Vector3 checkForwardOffset;
    [Range(0, 1)]
    public float checkForwardRadius = 0.3f;
    /*�����O�����Ʊ�l���O�Ƽg����`
     * 1.�׹��������n�Opublic(���N�ҥi�ϥ�) ��protected(�ߤl���O�i��)
     * 2.�����O�����ݩ������e�K�[virtual���� (�W�z�ⶵ�@�άҬ����\�l���O�Ƽg)
     * 3.�l���O�����ݩ������e�K�[override�Ƽg
     */
    protected virtual void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0.3f, 0.3f, 0.4f);
        Gizmos.DrawSphere(transform.position + transform.right*
            checkForwardOffset.x+transform.up*checkForwardOffset.y, checkForwardRadius);
    }
    #endregion
    //�}�C�y�k:���N�i������+���A�� �p:int[],float[],vector2[]
    public Collider2D[] hits;
    /// <summary>
    /// �s��e��O�_�����]�t�a�O�θ��x������
    /// </summary>
    public Collider2D[] hitResult;
    #region ��k
    /// <summary>
    /// �����e��O�_���a�O�λ�ê��
    /// </summary>
    private void CheckForward()
    {
        hits = Physics2D.OverlapCircleAll(transform.position + transform.right *
            checkForwardOffset.x + transform.up * checkForwardOffset.y, checkForwardRadius);
        /*��ر��p���n�i����V�A�H�K�����ê���α���
         * 1.�}�C�����D�a�O�θ��x������:���J���ê��
         * 2.�}�C���O�Ū�:��ܨS�a�诸��
         * �d��LinQ:�i�H�d�߰}�C�����L��ƤΦ��L�S�w���
         */
        hitResult = hits.Where(x => x.name != "���x" && x.name != "�a�O"&&x.name!="���a"&&x.name!= "�i��V���x"&&x.name!="�Ův").ToArray();
        if(hits.Length == 0||hitResult.Length!=0)
        {
            TurnDirection();
        }
    }
    /// <summary>
    /// ��V
    /// </summary>
    private void TurnDirection()
    {
        float y = transform.eulerAngles.y;
        if (y == 0) transform.eulerAngles = Vector2.up * 180;
        else transform.eulerAngles = Vector2.zero;
    }
    /// <summary>
    /// �ˬd���A
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
    /// ����:�b�H����ƫ���樫�����A
    /// </summary>
    private void Idle()
    {
        if(timerIdle < timeIdle) //�p�G�p�ɾ�<���ݮɶ�
        {
            timerIdle += Time.deltaTime; //�W�[�ɶ�
            ani.SetBool("�����}��", false);
        }
        else //�_�h
        {
            RandomDirection();
            timerIdle = 0;  //�p�ɾ��k�s
            timeWalk = Random.Range(v2WalkRandom.x,v2WalkRandom.y);  //�]�w��᪺�H�������ɶ�
            state = StateEnemy.walk;  //���ܪ��A������
        }
    }
    /// <summary>
    /// �H������
    /// </summary>
    private void Walk()
    {
        if (timerWalk < timeWalk)
        {
            timerWalk += Time.deltaTime;
            ani.SetBool("�����}��", true);
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
    /// �N���z�欰��W�B�z�é�fixedupdate�I�s
    /// </summary>
    private void WalkInFixedUpdate()
    {
        if(state==StateEnemy.walk) rig.velocity = transform.right*speed*Time.deltaTime+Vector3.up*rig.velocity.y;
    }
    /// <summary>
    /// �H����V:�H�����V����Υk�� (�k:(0,0,0)��(0,180,0))
    /// </summary>
    private void RandomDirection()
    {
        int random = Random.Range(0, 2); //�H��.�d��(�̤p,�̤j) �Y�ݱo�X��Ʒ|�����̤j��-�H�����o0,1
        if (random == 0) transform.eulerAngles = Vector2.up * 180;
        else transform.eulerAngles = Vector2.zero;
    }
    [Range(0.5f,5)]
    public float cdAttack = 2f;
    private float timerAttack;
    private void Attack()
    {
        if (timerAttack < cdAttack)
        {
            timerAttack += Time.deltaTime;
        }
        else
        {
            AttackMethod();
        }
    }
    /// <summary>
    /// �l���O�i�H�M�w�p��M�w����k
    /// </summary>
    protected virtual void AttackMethod()
    {
        timerAttack = 0;
        ani.SetTrigger("����Ĳ�o");
    }
    #endregion

    /*�w�q�C�|
     * 1.�ϥ�����renum�w�q�C�|�H�Υ]�t���ﶵ�A�i�b���O�~�w�q
     * 2.�ݭn���@����쬰���C�|����
     * 3.�y�k: �׹���enum �C�|�W��{�ﶵ1,�ﶵ2,...�ﶵn}
     */
    public enum StateEnemy
    {
        idle, walk, track, attack, dead
    }
}