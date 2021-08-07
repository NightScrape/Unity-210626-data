using UnityEngine;
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
}
