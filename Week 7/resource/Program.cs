﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace resource
{
    public class StateObject
    {
        private int state = 5;
        public void ChangeState(int loop)
        {
            if(state == 5)
            {
                state++;
                Trace.Assert(state == 6, "Состязание за ресурсы возникло после " + " циклов");
            }
            state = 5;
        }
    }
    public class SampleThread
    {
        public void RaceCondition(object obj)
        {
            Trace.Assert(obj is StateObject, "obj должен иметь тип StateObject");
            StateObject state = obj as StateObject;
            int i = 0;
            while (true)
            {
                state.ChangeState(i++);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var state = new StateObject();
            for(int i = 0; i < 20; i++)
            {
                new Task(new SampleThread().RaceCondition, state).Start();
            }
            Thread.Sleep(1000);

        }
    }
}
