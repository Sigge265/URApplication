using System.Windows;

namespace Project
{
    public partial class MainWindow : Window
    {
        private ConnectUR _connectUR;
        private FileLoader _fileLoader;
        private FileExecutor _fileExecutor;
        private StoppingProgram _stop;
        
        public MainWindow()
        {
            InitializeComponent();

            string robotIpAddress = "172.20.254.206";
            int robotModbusPort = 30002;

            _connectUR = new ConnectUR(robotIpAddress, robotModbusPort);
            _fileLoader = new FileLoader();
            _fileExecutor = new FileExecutor();
            _stop = new StoppingProgram(robotIpAddress, robotModbusPort);
        }

        private void Connect_Click(object sender, RoutedEventArgs e)
        {
            // Get the IP address and port from the TextBoxes
            string ipAddress = ipAddressTextBox.Text;
            int port;

            if (!int.TryParse(portNumberTextBox.Text, out port))
            {
                MessageBox.Show("Invalid port number.");
                return;
            }

            // Update the robot manager with the new IP address and port
            _connectUR = new ConnectUR(ipAddress, port);

            // Try to connect to the robot
            bool isConnected = _connectUR.ConnectToRobot();

            // Update the checkbox based on the connection status
            connectionCheckBox.IsChecked = isConnected;
        }

        private void LoadFile_Click(object sender, RoutedEventArgs e)
        {
            // Load the file using the FileLoader
            string fileContent = _fileLoader.LoadFile();

            // Display the content in the TextBox
            if (fileContent != null)
            {
                fileContentTextBox.Text = fileContent;
            }
        }

        private void ExecuteProgram_Click(object sender, RoutedEventArgs e)
        {
            // Get the content from the TextBox
            string contentToExecute = fileContentTextBox.Text;

            // Execute the content using the FileExecutor
            _fileExecutor.ExecuteContent(contentToExecute);
        }

        private void StopProgram_Click(object sender, RoutedEventArgs e)
        {
            // Call the method to stop the Universal Robot program using UniversalRobotManager
            _stop.StopProgram();
        }
    }
}
