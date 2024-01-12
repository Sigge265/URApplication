using System;
using System.Net.Sockets;
using System.Windows.Controls;

namespace Project
{
    public class ConnectUR
    {
        private string _robotIpAddress;
        private int _robotModbusPort;

        public ConnectUR(string robotIpAddress, int robotModbusPort)
        {
            _robotIpAddress = robotIpAddress;
            _robotModbusPort = robotModbusPort;
        }

        public bool ConnectToRobot()
        {
            try
            {
                // Create a TCP client to connect to the Universal Robot
                using (TcpClient client = new TcpClient(_robotIpAddress, _robotModbusPort))
                {
                    // Implement the logic to check the connection
                    return client.Connected;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
