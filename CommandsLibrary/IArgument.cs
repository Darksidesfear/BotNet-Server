﻿// This code is licensed under the isc license. You can improve the code by keeping this comments 
// (or by any other means, with saving authorship by Zerumi and PizhikCoder retained)
namespace CommandsLibrary
{
    public interface IArgument
    {
        public string Command { get; set; }
        public int ArgumentCount { get; set; }
        public string[] ArgumentsList { get; set; }
        public string[] ArgumentsName { get; set; }
        public System.Type[] ArgumentType { get; set; }
        //public object[][] ArgumentArgs { get; set; }
        public bool IsForServer { get; set; }
        public string CommandInfo { get; set; }
    }
}
