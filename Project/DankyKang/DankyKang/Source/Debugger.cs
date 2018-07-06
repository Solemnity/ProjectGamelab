using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DankyKang.Source {
    public class Debugger {

        public static void Debug(string message) {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Print(message);
        }
        public static void Warning(string message) {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Print(message);
        }

        public static void Error(string message) {
            Console.ForegroundColor = ConsoleColor.Red;
            Print(message);
        }

        public static void Log(string message) {
            Console.ForegroundColor = ConsoleColor.White;
            Print(message);
        }

        public static void CustomColor(string message, ConsoleColor color) {
            Console.ForegroundColor = color;
            Print(message);
        }

        private static void Print(string message) {
            StackFrame frame = new StackFrame(2, true);
            var method = frame.GetMethod();
            var lineNumber = frame.GetFileLineNumber();
            
            Console.WriteLine($"({method.Name}):{lineNumber} > {message}");
        }
    }
}
