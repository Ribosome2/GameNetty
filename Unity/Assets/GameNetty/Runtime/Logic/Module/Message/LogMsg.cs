﻿using System.Collections.Generic;

namespace ET
{
    public class LogMsg: Singleton<LogMsg>, ISingletonAwake
    {
        private readonly HashSet<ushort> ignore = new()
        {
            // OuterMessage.C2G_Ping, 
            // OuterMessage.G2C_Ping, 
            // OuterMessage.C2G_Benchmark, 
            // OuterMessage.G2C_Benchmark,
        };
        
        private readonly HashSet<string> ignoreTypeNames = new()
        {
            "ET.C2G_Ping", 
            "ET.G2C_Ping", 
            "ET.C2G_Benchmark", 
            "ET.G2C_Benchmark",
        };

        public void Awake()
        {
        }

        public void Debug(Fiber fiber, object msg)
        {
            // ushort opcode = OpcodeType.Instance.GetOpcode(msg.GetType());
            if (this.ignoreTypeNames.Contains(msg.GetType().FullName))
            {
                return;
            }
            fiber.Log.Debug(msg.ToString());
        }
    }
}