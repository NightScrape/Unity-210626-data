using UnityEngine;
/// <summary>
/// ��Z���ĤH����:��Z������
/// </summary>
//���O:�����O(�����O���Q�~�Ӫ����O)
public class EnemyNear : EnemyBase
{
    #region ���
    [Header("�����ϰ쪺�첾�Τj�p")]
    public Vector2 checkAttackOffset;
    public Vector3 checkAttaackSize;
    #endregion
    #region �ƥ�
    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos(); //���������O��������
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
    #region ��k
    /// <summary>
    /// �������a�O�_�X�{������ϰ줺
    /// </summary>
    private void CheckPlayerInAttackArea()
    {
        Collider2D hit = Physics2D.OverlapBox(transform.position + transform.right *
            checkAttackOffset.x + transform.up * checkAttackOffset.y, checkAttaackSize,0,1 << 7);
        if (hit) state = StateEnemy.attack;
    }
    #endregion
}
