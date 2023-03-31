using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace GameServer
{
    class Client
    {
        public static int dataBuffersize = 4096;

        public int id;
        public TCP tcp;

        public Client(int _clientId)
        {
            id = _clientId;
            tcp = new TCP(id);
        }

        public class TCP
        {
            public TcpClient socket;

            public readonly int id;
            private NetworkStream stream;
            private byte[] receiverBuffer;

            public TCP(int _Id)
            {
                id = _Id;
            }

            public void Connect(TcpClient _socket)
            {
                socket = _socket;
                socket.ReceiveBufferSize = dataBuffersize;
                socket.SendBufferSize = dataBuffersize;

                stream = socket.GetStream();

                receiverBuffer = new byte[dataBuffersize];

                stream.BeginRead(receiverBuffer, 0, dataBuffersize, ReceiveCallback, null);
            }

            private void ReceiveCallback(IAsyncResult _result)
            {
                try
                {
                    int _byteLenght = stream.EndRead(_result);
                    if(_byteLenght <= 0) 
                    {
                        return;
                    }

                    byte[] _data = new byte[_byteLenght];
                    Array.Copy(receiverBuffer, _data, _byteLenght);

                    stream.BeginRead(receiverBuffer, 0, dataBuffersize, ReceiveCallback, null);
                }
                catch (Exception _ex)
                {
                    Console.WriteLine($"Error receiving {_ex}");
                }

            }
        }
    }
}
