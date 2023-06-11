using System;
using System.Collections.Generic;
using System.Text;

namespace App4.WebSocketImplementation
{
    public interface IConnectionHolder
    {
        void OnError(Exception ex);
        void AddHeader(string key, string value);
    }
}
