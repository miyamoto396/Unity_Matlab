using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using System;
using System.IO;
using System.Text;

public class MatlabTCPSend : MonoBehaviour
{
    TcpListener listener;
    String msg;

    //自分自身を指すIPアドレス
    public string mIpAddress = "127.0.0.1";

    //ポート番号は適当　ただしクライアントと合わせること
    public int mPortNumber = 2000;

    // Start is called before the first frame update
    void Start()
    {
        var ip = IPAddress.Parse(mIpAddress);
        listener = new TcpListener(ip, mPortNumber);

        listener.Start();
    }

    // Update is called once per frame
    void Update()
    {


        if (!listener.Pending())
        {
        }
        else
        {
            Debug.Log("ConnectSend");


            TcpClient client = listener.AcceptTcpClient();
            NetworkStream ns = client.GetStream();
            StreamReader reader = new StreamReader(ns);

            double data = 1;

            //送信
            byte[] body = BitConverter.GetBytes(data);
            ns.Write(body,0,body.Length);

        }


    }
}
