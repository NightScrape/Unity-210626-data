using UnityEngine;
using System.Collections;  //��P�{��
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
        hit = Physics2D.OverlapBox(transform.position + transform.right *
            checkAttackOffset.x + transform.up * checkAttackOffset.y, checkAttaackSize, 0, 1 << 7);
        if (hit) state = StateEnemy.attack;
    }
    protected override void AttackMethod()
    {
        base.AttackMethod();
        StartCoroutine(DamageDelayed());
    }
    /*��P�{�ǥΪk
     * 1.�ޥΨ�P�{��API System.Collection
     * 2.�Ǧ^��k�B������IEnumerator
     * 3.�HStartCoroutine()�Ұʵ{��
     */
    /// <summary>
    /// ����ǻ��ˮ`
    /// </summary>
    private IEnumerator DamageDelayed()
    {
        //���o�}�C�ƶq�y�k:�}�C���.Length
        for (int i = 0; i < attacksDelay.Length; i++)
        {
            //���o�}�C��ƻy�k:�}�C���[�s��]
            yield return new WaitForSeconds(attacksDelay[i]);
            if (hit) player.Injure(atk);  //�Y�I���ϰ�s�b�A�h�y�������ˮ`
            //���ݧ������_�ɶ�
            yield return new WaitForSeconds(attackRestore);
            //�Y���a�٦b�ϰ줺�h�����A�_�h�N�����L���O
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
