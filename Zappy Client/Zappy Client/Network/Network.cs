﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

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
        private static Network instance;
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

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Creates a new Network instance
        /// </summary>
        public Network()
        {
            this.Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this.Connected = false;
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Creates the real instance
        /// </summary>
        public void Create() { }
        
        /// <summary>
        /// Connect to a specific host and port
        /// </summary>
        /// <param name="host"></param>
        /// <param name="port"></param>
        public void Connect(String host, String port)
        {
            Int32 _port = 0;

            if (Int32.TryParse(port, out _port) == false)
            {
                // send error
                return;
            }
            this.Socket.Connect(host, _port);
            this.Connected = true;
        }

        /// <summary>
        /// Update the Network
        /// </summary>
        public void Update()
        {
            if (this.Connected == true)
            {
                if (this.Socket.Poll(10, SelectMode.SelectRead) == true)
                {
                    Byte[] _buffer = null;
                    String _message = null;
                    Int32 _size = 0;

                    _size = this.Socket.Receive((_buffer = new Byte[this.Socket.Available]));
                    _message = Encoding.Default.GetString(_buffer);
                    Console.WriteLine(_message);
                    this.HandleMessages(_message);
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

            if (this.Connected == true && this.Socket.Connected == true)
            {
                Int32 _send = this.Socket.Send(_buffer);
                if (_send == -1)
                {
                    // error pop-up
                }
            }
        }

        /// <summary>
        /// Handle messages
        /// </summary>
        /// <param name="messages"></param>
        private void HandleMessages(String messages)
        {
        }

        #endregion
    }
}
