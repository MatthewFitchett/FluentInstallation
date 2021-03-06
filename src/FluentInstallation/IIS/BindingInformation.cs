﻿using System;

namespace FluentInstallation.IIS
{
    internal class BindingInformation
    {
        public int Port { get; set; }
        public string IpAddress { get; set; }
        public string HostName { get; set; }

        public BindingInformation()
        {
            Port = 80;
            IpAddress = "*";
            HostName = string.Empty;
        }

        public static BindingInformation Parse(string value)
        {

            var bindingInformation = new BindingInformation();

            if (string.IsNullOrEmpty(value))
            {
                return bindingInformation;
            }

            var values = value.Split(':');


            if (values.Length >= 1)
            {
                bindingInformation.IpAddress = values[0];
            }

            if (values.Length >= 2)
            {
                bindingInformation.Port = Convert.ToInt32(values[1]);
            }

            if (values.Length >= 3)
            {
                bindingInformation.HostName = values[2];
            }

            return bindingInformation;

        }

        public override string ToString()
        {
            return string.IsNullOrEmpty(HostName) ? string.Format("{0}:{1}", IpAddress, Port) : string.Format("{0}:{1}:{2}", IpAddress, Port, HostName);
        }
    }
}