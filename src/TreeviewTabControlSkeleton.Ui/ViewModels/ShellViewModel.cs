using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeviewTabControlSkeleton.Ui.ViewModels
{
    public class ShellViewModel : Screen
    {
        public ShellViewModel()
        {
            this.Message = "Hello World!";
            this.Version = "1.0 DEBUG";
        }

        public string Message { get; set; }

        public string Version { get; set; }

    }
}
