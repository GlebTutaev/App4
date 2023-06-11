using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace App4.WebSocketImplementation
{
    public class ConnectionHolder : IConnectionHolder
    {
        private IConnection _connection;
        public ConnectionHolder(IConnection connection)
        {
            this._connection = connection;
        }
        public void AddHeader(string key, string value)
        {
            _connection.Headers.Add(key, value);
        }

        public void OnError(Exception ex)
        {
            _connection.OnError(ex);
        }
    }
}
