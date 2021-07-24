using UnityEngine;   //�ޥ�Unity��������API(Unity Engine�R�W�Ŷ�)

public class Car : MonoBehaviour  //�׹���+���O(����r)+�}���W��
{
    #region ��컡���Υ|�j�y�k

    //���:�x�s²����
    //�y�k:�׹���  ������� ���W�� ���w�Ÿ�(=) �w�]�� ����
    /*��� int ������ƥ]�t0
     *�B�I�� float  �Ҧ��]�t�p���I���ƭ�
     *�r�� string �A�Ψ���B���~���W�٩Ψ����ܡA�i�]�t�S��r��
     *���L��(boolean) bool ��ܪ��A(True�BFalse)
     */
    //�w�q���
    public float weight = 3.5f;
    public int cc = 2000;
    public string brand = "���h";
    public bool windowSky = true;

    //�i�H�ϥΤ���A������ĳ�A���D�W�߻s�@�ιζ��\�i (�]�s�X���D�ήį��ഫ
    //����ݩ�:���U���K�[�B�~�\��
    /*�y�k=[�ݩʦW��(�ݩʭ�)] �r�궷�H""�е� 
     * �p:���DHeader
     * ���DTooltip
     * �d��Range(�̤p��,�̤j��) �ȭ��ϥ�int��float
     */
    public int ���L�ƶq = 4;
    [Header("����ռ�")]
    public int windownumber = 4;
    [Tooltip("���]�w�O�Хܪ��骺����")]
    public float height = 1.5f;
    [Range(2, 10)]
    public int doorcount;
    #endregion

    #region ��L����
    //�C�� Color
    public Color color1;  //�q�{�C�⬰��
    public Color blue = Color.blue;  //�ϥιw�]�C��
    public Color colorcustom1 = new Color(0.5f, 0.5f, 0);  //�ۭq�C��:RGB
    public Color colorcustom2 = new Color(0.5f, 0, 0.5f, 0.5f);  //�ۭq�C��:RGB+�z����

    //�y��:2-4�� Vector (�O�s�ƭȤίB�I��)
    public Vector2 v2;
    public Vector2 v2zero = Vector2.zero;
    public Vector2 v2one = Vector2.one;
    public Vector2 v2Up = Vector2.up;
    public Vector2 v2Right = Vector2.right;
    public Vector2 v2custom = new Vector2(20, -60);

    //�������� Keycode
    public KeyCode kc;
    public KeyCode forward = KeyCode.D;
    public KeyCode attack = KeyCode.Mouse0; //����0 �k��1 �u��2

    //�C������GameObject�P����
    public GameObject GoCamera; //�C������]�t�����W�M�M�פ������m��
    public Transform Cartrs;
    public SpriteRenderer sprPic;

    #endregion

    #region �ƥ�
    //�}�l�ƥ�:����C����Ĳ�o�@���A�B�z��l��
    private void Start()
    {//��X���(�]�t���N����)
        print("Hello World !");

        //���o����� Get
        print(brand);
        //�]�w����� Set
        cc = 5000;
        windowSky = true;
        weight = 10.8f;
        //�I�s��k���y�k�d��(�ݥ��غc��k)
        Drive50();
        Drive100();
        Drive(75,"de javu");  //�I�s���p�A�����������w"��k"��"�ޭz",�ݿ�J����������
        Drive(150,"�A�������u");
        Drive(120);  //���w�]�Ȫ��ѼƥH�w�]�Ȭ��D�A�i�H����J"�ޭz"
        Drive(60, "�ǹ�"); //�ƼƧt�w�]�Ȥ��ѼƳQ�ޭz�ɷ|�̶��ǾɤJ�A�ɭP�ɥX���G�P�]�Q����(�ɥX���G���ɳt60,���Ħǹ�,�ĪG�H��)
        Drive(60, effect: "�ǹ�"); //�[�J�����ܤ��ѼƦW��:�]�w�� ���X�]�Q�ޭz

        float kg = KG();  //�ϰ��ܼơA�Ȧ��A�����ϥ�
        print("�ର���窺��T"+kg);

        print("BMI����:" + BMI(60, 1.6f)); 
    }
    //��s�ƥ�:�B�z���󲾰ʩκ�ť���a��J�A�W�v����60fps(�C��60�V)
    private void Update()
    {
        print("�ڳQ�x��F !");
    }
    #endregion


    #region ��k 
    /*Method,�S�٨禡�B�\��
     * �y�k�� �׹���+�Ǧ^����(�|�j����+void(�L�Ǧ^))+�W��+(�Ѽ�)+{�{���϶�}�A���Τ����i�浲��!!!
     * �{���϶����~�ݭn����
     * �w�q��k���y�l���|�۰ʰ���A����ݭn�b�ƥ󤺩I�s
     * �I�s��k:��k�W��(�ޭz);
     */
    private void Drive50() {
        print("�}�����A�ɼ�50");

    }
    private void Drive100()
    {
        print("�}�����A�ɼ�100");

    }
    /*�{���ݦҶq�X�R��&���@�ʡA�Ѽƥi���Ĵ���
    *�Ѽƻy�k:����+�ѼƦW�١A�g�b�p�A�����B�Ȧb��k���i��
    *�h�ӰѼƥγr���۹j�A�B�ƶq�L�W�� �p:�Ѽ�1,�Ѽ�2,...
    *�Ѽƥi�]�w�w�]�ȡA�y�k������+�ѼƦW��+���w�ȡA�w�]�ȶ���b�Ѽ�"�̥k��"
    */
    /// <summary>
    /// �o�O�}������k�A�ΥH����l���t�סB���ĤίS��
    /// </summary>
    /// <param name="speed">�]�w���l�����ʳt��</param>
    /// <param name="sound">�]�w�}���ɼ��񪺭���</param>
    /// <param name="effect">�]�w�}���ɪ��S��</param>
    private void Drive (int speed, string sound = "����~",string effect= "�H��"){
        print("�}�����A�ɳt" + speed);
        print("����"+sound);
        print("�ĪG"+effect);
}
    /// <summary>
    /// ���q�ഫ:�����ର����
    /// </summary>
    /// <returns>�ର���窺���q��T</returns>
    private float KG()
    {
        return weight*1000;
    }
    private float BMI(float weight,float height)
    {
        return weight / (height * height);
    }
    #endregion
}