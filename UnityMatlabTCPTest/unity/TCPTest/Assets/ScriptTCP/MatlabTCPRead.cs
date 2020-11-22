using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using System;
using System.IO;
using System.Text;



public class MatlabTCPRead : MonoBehaviour
{
    TcpListener listener;
    TcpListener listenerSend;
    String msg;

    static double ReadData = 0;     //Matlabからうけとったデータ
    
    public string mIpAddress = "127.0.0.1";    //自分自身を指すIPアドレス
    public int mPortNumber = 2001;  //ポート番号は適当　ただしクライアントと合わせること

    private GameObject shikaku;
    
    // Start is called before the first frame update
    void Start()
    {
        var ip = IPAddress.Parse(mIpAddress);
        listener = new TcpListener(ip, mPortNumber);

        listener.Start();

        shikaku = GameObject.Find("shikaku");
    }

    static float rotz = 0;

    // Update is called once per frame
    void Update()
    {
        

        shikaku.transform.Rotate(0,0, rotz);

        if (!listener.Pending())
        {
        }
        else
        {
            Debug.Log("ConnectRead");
            
            TcpClient client = listener.AcceptTcpClient();
            NetworkStream ns = client.GetStream();
            BinaryReader reader = new BinaryReader(ns);         //Binaryで読み出すのが大事
            
            ReadData = reader.ReadDouble();

            rotz = (float)ReadData;

            Debug.Log(ReadData);
            
        }
        

    }
}

//ゴミ↓
//byte[] body = Encoding.Default.GetBytes(msg);
//byte[] body = Encoding.GetEncoding("Shift_JIS").GetBytes(msg);
//byte[] body = Encoding.ASCII.GetBytes(msg);


/*
byte temp1;
for (int i=0;i<3;i++) {
    temp1 = body[7-i];
    body[7-i] = body[i];
    body[i] = temp1;
}
*/

//byte[] temp = Encoding.ASCII.GetBytes("abcdefgh");       //double 1
//byte[] temp = { 0, 0, 0, 0 ,0, 36 , 254, 64};     //double 123456
//byte[] temp = { 0, 0, 0, 0 ,0, 0 ,240, 63};       //double 1

/*
for (int i = 0; i < 8; i++)
{
    Debug.Log(temp[i]);
}
*/

//double data_read = BitConverter.ToDouble(body, 0);      //doubleに変換

//Debug.Log(msg);
//Debug.Log(data_read);