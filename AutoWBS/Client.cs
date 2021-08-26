using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Net;

namespace CC320
{
    public enum enumClient
    {
        CONNECTED,
        DISCONNECTED,
        RECEIVED
    }
    public class Client
    {
        public delegate void EventForClient(enumClient eAE, string _strData);
        public event EventForClient ClientCallBack;
        public string IP = "10.0.1.188";
        public int Port = 50000;

        byte[] m_DataBuffer = new byte[512];
        IAsyncResult m_asynResult;
        private AsyncCallback pfnCallBack;
        private Socket client;
        public bool Connected = false;
        private string ConnectString = "OK?";
        public void Connect()
        {
            Ping pinger = new Ping();
            PingReply reply = pinger.Send(IP);
            if (reply.Status == IPStatus.Success)
            {
                try
                {
                    client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    IPAddress Ip = IPAddress.Parse(IP);
                    int iPortNo = System.Convert.ToInt32(Port);
                    IPEndPoint ipEnd = new IPEndPoint(Ip, iPortNo);
                    client.Connect(ipEnd);
                    //Send(ConnectString);
                    WaitForData();
                    if (ClientCallBack != null)
                    {
                        ClientCallBack.Invoke(enumClient.CONNECTED, "Connected");
                        Connected = true;
                    }
                }
                catch
                {
                    Connected = false;
                }
            }
        }
        private void WaitForData()
        {
            try
            {
                if (pfnCallBack == null)
                {
                    pfnCallBack = new AsyncCallback(OnDataReceived);
                }
                CSocketPacket theSocPkt = new CSocketPacket();
                theSocPkt.thisSocket = client;
                m_asynResult = client.BeginReceive(theSocPkt.dataBuffer, 0, theSocPkt.dataBuffer.Length, SocketFlags.None, pfnCallBack, theSocPkt);
            }
            catch
            {
            }

        }
        private class CSocketPacket
        {
            public System.Net.Sockets.Socket thisSocket;
            public byte[] dataBuffer = new byte[256];
        }
        public void Disconnect()
        {
            try
            {
                if (client != null)
                {
                    client.Disconnect(true);
                    if (ClientCallBack != null)
                    {
                        ClientCallBack.Invoke(enumClient.DISCONNECTED, "Disconnected");
                        Connected = false;
                    }
                }
            }
            catch
            {
                Connected = true;
            }
        }
        public void Send(string data)
        {
            if (client != null && data != null)
            {
                try
                {
                    Object objData = data;
                    byte[] byData = System.Text.Encoding.ASCII.GetBytes(objData.ToString());
                    client.Send(byData);
                }
                catch (SocketException)
                {
                    client = null;
                    if (ClientCallBack != null)
                    {
                        ClientCallBack.Invoke(enumClient.DISCONNECTED, "Disconnected");
                        Connected = false;
                    }
                }
            }
        }
        private void OnDataReceived(IAsyncResult asyn)
        {
            try
            {
                CSocketPacket theSockId = (CSocketPacket)asyn.AsyncState;
                int iRx = 0;
                iRx = theSockId.thisSocket.EndReceive(asyn);
                char[] chars = new char[iRx + 1];
                System.Text.Decoder d = System.Text.Encoding.ASCII.GetDecoder();
                int charLen = d.GetChars(theSockId.dataBuffer, 0, iRx, chars, 0);
                System.String szData = new System.String(chars);
                if (ClientCallBack != null)
                {
                    ClientCallBack.Invoke(enumClient.RECEIVED, szData);
                }
                Connected = true;
                WaitForData();
            }
            catch
            {

            }
        }
    }
}

