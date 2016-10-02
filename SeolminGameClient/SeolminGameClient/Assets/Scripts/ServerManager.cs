using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;

public class ServerManager : MonoBehaviour
{
    private TcpClient m_client = null;

    void Start()
    {
        try
        {
            m_client = new TcpClient();
            m_client.Connect("127.0.0.1", 5001);

            NetworkStream writeStream = m_client.GetStream();

            Encoding encode = System.Text.Encoding.GetEncoding("ks_c_5601-1987");
            StreamReader readerStream = new StreamReader(writeStream, encode);

            //보낼 데이터를 읽어 Default형식의 바이트 스트림으로 변환
            string dataToSend = Console.ReadLine();
            byte[] data = Encoding.Default.GetBytes(dataToSend);

            while (true)
            {
                dataToSend += "\r\n";
                data = Encoding.Default.GetBytes(dataToSend);
                writeStream.Write(data, 0, data.Length);


                if (dataToSend.IndexOf("<EOF>") > -1)
                    break;

                string returnData;
                returnData = readerStream.ReadLine();
                Console.WriteLine("server : " + returnData);

                dataToSend = Console.ReadLine();
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
        }
        finally
        {
            m_client.Close();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
        }
    }
}
