using System;
using System.Net.Sockets;
using System.Text;
using System.Windows;

namespace Project
{
    public class FileExecutor
    {
        public void ExecuteContent(string content)
        {
            // Replace with the actual IP address and port of your Universal Robot
            string robotIpAddress = "172.20.254.206";
            int robotModbusPort = 30002;

            try
            {
                // Create a TCP client to connect to the Universal Robot
                using (TcpClient client = new TcpClient(robotIpAddress, robotModbusPort))
                using (NetworkStream stream = client.GetStream())
                {
                    // Encode the content as ASCII bytes
                    byte[] data = Encoding.ASCII.GetBytes(content);

                    // Send the content to the Universal Robot
                    stream.Write(data, 0, data.Length);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending content to the Universal Robot: " + ex.Message);
            }
        }
    }
}