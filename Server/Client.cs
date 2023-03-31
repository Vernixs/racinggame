using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    class PClient 
    {
        public static int dataBufferSize = 4096;
        public int ID;
        public TCP tcp(ID);

        public PClient(int _clientID)
        {
            ID = _clientID;
            tcp = new TCP(ID);
        }

        public class TCP
        {
            public TcpClient socket;
            private NetworkStream stream;
            private byte[] receiveBuffer;
            private readonly int ID;

            public TCP(int _ID)
            {
                ID = _ID;
            }

            public void Connect(TcpClient _socket)
            {
                socket = _socket;
                socket.ReceiveBufferSize = dataBufferSize;
                socket.SendBufferSize = dataBufferSize;

                stream = socket.GetStream();
                receiveBuffer = new byte[dataBufferSize];
                stream.BeginRead(receiveBuffer, 0, dataBufferSize, ReceiveCallback, null);
            }

            private void ReceiveCallback(IAsyncResult _result)
            {
                try
                {
                    int _byteLenght = stream.EndRead(_result);
                    if(_byteLenght <=0)
                    {
                        return;
                    }

                    byte[] _data = new byte[_byteLenght];
                    Array.Copy(receiveBuffer, _data, _byteLenght);
                    stream.BeginRead(receiveBuffer, 0, dataBufferSize, ReceiveCallback, null);
                }
                catch(Exception _ex)
                {
                    Console.WriteLine($"Error receiving TCP data: {_ex}");
                }
            }
        }
    }
}