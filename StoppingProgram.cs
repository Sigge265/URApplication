using System;
using System.Net.Sockets;
using System.Text;

namespace Project
{
    public class StoppingProgram
    {
        private string _robotIpAddress;
        private int _robotModbusPort;

        public StoppingProgram(string robotIpAddress, int robotModbusPort)
        {
            _robotIpAddress = robotIpAddress;
            _robotModbusPort = robotModbusPort;
        }

        public void StopProgram()
        {
            try
            {
                // Create a TCP client to connect to the Universal Robot
                using (TcpClient client = new TcpClient(_robotIpAddress, _robotModbusPort))
                using (NetworkStream stream = client.GetStream())
                {
                    // Implement the logic to send a command to stop the program
                    // For example, you might send a specific command recognized by the Universal Robot
                    string stopCommand = "stopj(2)";
                    byte[] data = Encoding.ASCII.GetBytes(stopCommand);

                    // Send the command to the Universal Robot
                    stream.Write(data, 0, data.Length);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately
                Console.WriteLine("Error stopping Universal Robot program: " + ex.Message);
            }
        }
    }
}

