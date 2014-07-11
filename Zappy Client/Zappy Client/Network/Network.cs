using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using Zappy_Client.Core;
using Zappy_Client.Core.Windows;

/*--------------------------------------------------------
 * Network.cs - file description
 * 
 * Version: 1.0
 * Author: Filipe
 * Created: 04/07/2014 10:59:57
 * 
 * Notes:
 * -------------------------------------------------------*/

namespace Zappy_Client
{
    public partial class Network
    {
        #region SINGLETON

        private static Object NetworkLock = new Object();
        public static Network instance;
        public static Network Instance
        {
            get
            {
                lock (NetworkLock)
                {
                    if (instance == null)
                    {
                        instance = new Network();
                    }
                    return instance;
                }
            }
        }

        #endregion

        #region FIELDS

        private Socket Socket { get; set; }
        private Boolean Connected { get; set; }
        private GameScreen Game { get; set; }

        private String Message { get; set; }

        public Boolean Started { get; set; }

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Creates a new Network instance
        /// </summary>
        public Network()
        {
            this.Game = Zappy.Instance.ScreenManager["GameScreen"] as GameScreen;
            this.Connected = false;
            this.Message = "";
            this.Started = false;
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Creates the real instance
        /// </summary>
        public void Create()
        {
            this.InitializeMessages();
        }
        
        /// <summary>
        /// Connect to a specific host and port
        /// </summary>
        /// <param name="host"></param>
        /// <param name="port"></param>
        public Boolean Connect(String host, String port)
        {
            Int32 _port = 0;

            if (Int32.TryParse(port, out _port) == false)
            {
                return false;
            }
            try
            {
                this.Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                this.Socket.Connect(host, _port);
            }
            catch
            {
                (Zappy.Instance.InterfaceEngine.GetContainer("Popup") as Popup).Show("Cannot initiate connexion with server.");
                return false;
            }
            this.Connected = true;
            return true;
        }

        /// <summary>
        /// Disconnect the socket
        /// </summary>
        public void Disconnect()
        {
            this.Connected = false;
            this.Socket.Close();
            this.Socket.Dispose();
            this.Socket = null;
        }

        /// <summary>
        /// Update the Network
        /// </summary>
        public void Update()
        {
            if (this.Connected == true && this.Socket.Connected == true)
            {
                if (this.Socket.Poll(10, SelectMode.SelectRead) == true)
                {
                    Byte[] _buffer = null;
                    String _message = null;

                    if (this.Socket.Connected == true)
                    {
                        this.Socket.Receive((_buffer = new Byte[this.Socket.Available]));
                        _message = Encoding.UTF8.GetString(_buffer);
                        Console.WriteLine(_message);
                        if (String.IsNullOrEmpty(_message) == false)
                        {
                            Char _last = _message.Last();
                            this.Message += _message;
                            if (_last == '\n')
                            {
                                String[] _commands = this.Message.Split('\n');
                                foreach (String Command in _commands)
                                {
                                    this.ExecAnswer(Command);
                                }
                                this.Message = "";
                            }
                        }
                    }
                }
   
            }
        }

        /// <summary>
        /// Send a message to the server
        /// </summary>
        /// <param name="message"></param>
        public void SendMessage(String message)
        {
            Byte[] _buffer = Encoding.Default.GetBytes(message);
            Int32 _send = -1;

            if (this.Connected == true && this.Socket.Connected == true)
            {
                try
                {
                    _send = this.Socket.Send(_buffer);
                }
                catch
                {
                    Zappy.Instance.Disconnect();
                }
                if (_send == -1)
                {
                    // error pop-up
                }
            }
        }

        /// <summary>
        /// Ask server to do a cmd
        /// </summary>
        /// <param name="cmd">Cmd to ask to the server</param>
        /// <returns>true if success, false in the other case</returns>
        public Boolean ExecAsk(String cmd)
        {
            List<String> _items = new List<String>();

            if (this.Connected == false)
                return false;
            if ((_items = Parser.GetCmdItems(cmd)) == null)
                return false;
            return AskFunctions[_items.First()](_items);
        }

        /// <summary>
        /// Exec server's answer
        /// </summary>
        /// <param name="cmd">Cmd received from server</param>
        /// <returns>true if success, false in the other case</returns>
        public Boolean ExecAnswer(String cmd)
        {
            List<String> _items = new List<String>();
            if (this.Connected == false)
            {
                Network.instance.Started = false; 
                return false;
            }
            if ((_items = Parser.GetCmdItems(cmd)) == null)
            {
                Network.instance.Started = false;
                return false;
            }
            return AnswerFunctions[_items.First()](_items);
        }

        #endregion
    }
}
