using System;
using System.Collections.Generic;
using System.Text;

namespace App4.Services
{
    public interface IStatusBar
    {
        /// <summary>
        /// Hide
        /// </summary>
        void HideStatusBar();

        /// <summary>
        /// Show
        /// </summary>
        void ShowStatusBar();
    }
}
