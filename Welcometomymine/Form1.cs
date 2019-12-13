using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace Welcometomymine
{
    public partial class Form1 : Form
    {
        ConnectionHandler Connection = new ConnectionHandler();
        public Form1()
        {
            
            InitializeComponent();
            Connection.InitializeConnection();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }
        private void Button3_Click(object sender, EventArgs e)
        {
            Connection.Refresh();
        }

        private void Button7_Click(object sender, EventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {

        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
        public class ConnectionHandler
        {
            public string[] ip = System.IO.File.ReadLines(System.IO.Directory.GetCurrentDirectory() + @"\ip.txt").ToArray();



            Socket serverS = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            public static IPEndPoint GetLocalEndPoint()
            {
                using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
                {
                    socket.Connect("8.8.8.8", 23);
                    IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                    IPAddress ip = endPoint.Address;
                    IPEndPoint Host = new IPEndPoint(ip, 23);
                    socket.Close();


                    return Host;
                }


            }

            public void InitializeConnection()
            {

                ConnectionHandler Connection = new ConnectionHandler();
                Connection.serverS.Bind(GetLocalEndPoint());
                Connection.serverS.Listen(5);
                Socket conn = Connection.serverS.Accept();



            }
            public void Refresh()
            {
                Form1 form = new Form1();
                Ping pingSender = new Ping();
                PingOptions options = new PingOptions();
                options.DontFragment = true;
                string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                int timeout = 120;
                foreach (string ips in ip)
                {
                    PingReply reply = pingSender.Send(ips, timeout, buffer, options);
                    if (reply.Status == IPStatus.Success)
                    {
                       string i = ips.GetEnumerator().ToString();
                        //TextBox curText = (TextBox)this.ip["IPAddress" + i.ToString()];



                    }
                }
            }

            public void Connect(IPEndPoint text)
            {

            }
        }
    

    }
}