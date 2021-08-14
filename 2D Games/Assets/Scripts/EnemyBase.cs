using UnityEngine;
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
    #endregion
    #region �����}���
    //�N�p�H�����ܩ��ݩʭ��O�W
    [SerializeField]
    private StateEnemy state;

    private Rigidbody2D rig;
    private Animator ani;
    private AudioSource aud;
    /// <summary>
    /// �H�����ݮɶ�
    /// </summary>
    private Vector2 v2IdleRandom = new Vector2(2, 5);
    /// <summary>
    /// �H�������ɶ�
    /// </summary>
    private Vector2 v2WalkRandom = new Vector2(3, 6);
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
    #region �ƥ�
    private void Start()
    {
        #region ���o����
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
        #endregion
        #region �]�w��l��
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
    #region ��k
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