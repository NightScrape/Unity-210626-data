using UnityEngine;
using System.Collections;
/// <summary>
/// �]�w��v���l��
/// </summary>
public class CameraControl : MonoBehaviour
{
    #region ���
    [Header("�l�ܳt��"), Range(0, 100)]
    public float speed = 10;
    [Header("�n�l�ܪ�����W��")]
    public string nameTarget;
    [Header("���k����")]
    public Vector2 limitHorizon;
    /// <summary>
    /// �n�l�ܪ�����W��
    /// </summary>
    private Transform target;
    #endregion
    #region �ƥ�
    private void Start()
    {
        //�]���ܦY�į�A�ҥH��ĳ�bStart�ϥ�
        //�ؼ��ܧΤ���=�C������.�M��(����W��).�ܧΤ���
        target = GameObject.Find(nameTarget).transform;
    }
    //���C��s:�bUpdate�����,��ĳ�ΨӾ��a��v��
    private void LateUpdate()
    {
        Track();
    }
    #endregion
    #region ��k
    /// <summary>
    /// �l�ܪ���
    /// </summary>
    private void Track()
    {
        Vector3 PosCam = transform.position;  //A:��v���y��
        Vector3 PosTar = target.position;  //B:�ؼЪ��y��
        //�B��ᵲ�G�y��:���o��v���ΥؼЪ��������y��
        Vector3 PosResult = Vector3.Lerp(PosCam, PosTar, speed * Time.deltaTime);
        //��v��Z�b�ݩ�^�w�]-10�H�K�L�k�ݨ쪫��
        PosResult.z = -10;
        //�ϥΧ���API������v�������k�d��
        PosResult.x = Mathf.Clamp(PosResult.x,limitHorizon.x,limitHorizon.y);
        //�����󪺮y�Чאּ�B��᪺�y��
        transform.position = PosResult;
    }
    #endregion
    [Header("�̰ʴT��"), Range(0, 5)]
    public float shakeValue = 0.2f;
    [Header("�̰ʦ���"), Range(0, 20)]
    public int shakeCount = 10;
    [Header("�̰ʶ��j"), Range(0, 5)]
    public float shakeInterval = 0.3f;
    /// <summary>
    /// �̰ʮĪG
    /// </summary>
    public IEnumerator ShakeEffect()
    {
        Vector3 PosOrigin = transform.position;  //���o��v���̰ʫe���y��
        for (int i = 0; i < shakeCount; i++)  //�j�����y�Ч��
        {
            Vector3 PosShake = PosOrigin;
            if (i % 2 == 0) PosShake.x += shakeValue;  //i�����ƴN���k
            else PosShake.x -= shakeValue;             //i���_�ƴN����
            transform.position = PosShake;
            yield return new WaitForSeconds(shakeInterval);
        }
        transform.position = PosOrigin;  //�^�_��v������l�y��
    }
}
