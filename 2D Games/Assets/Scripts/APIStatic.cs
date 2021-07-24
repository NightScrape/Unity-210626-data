using UnityEngine;
/// <summary>
/// 認識API及第一種用法:靜態
/// </summary>
public class APIStatic: MonoBehaviour
{
    //API分為兩大類:靜態及非靜態
    //屬性:可理解為欄位 Properties
    //方法 Methods
    private void Start()
    {
        //靜態屬性
        //1.取得  語法:類別.靜態屬性
        print("隨機值:" + Random.value);
        print("無限大:" + Mathf.Infinity);
        //2.設定  語法:類別.靜態屬性+指定+值
        Cursor.visible = false;  //鼠標顯示與否
        //唯讀屬性 Read Only:該屬性不可用設定更改，僅能讀取
        Screen.fullScreen = true;
        //靜態方法
        //3.呼叫 
        float r = Random.Range(7.2f, 10.6f);
        print("隨機顯現7.2-10.6:" + r); }

        public float hp = 70;
    private void Update()
    {
        
        hp = Mathf.Clamp(hp,0,100);  //Clamp夾住
        print("HP="+hp);
    }

}
