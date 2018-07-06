using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DebugWindow {
    public class Log {
        public static void Main(string[] args) => new Log().MainAsync().GetAwaiter().GetResult();

        public async Task MainAsync() {
            Console.WriteLine("=== Debug Window Initialized ===");

            await Task.Delay(-1);
        }

        public static void Debug(string message) {
            Console.ForegroundColor = ConsoleColor.Blue;
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

        public static void Simple(string message) {
            Console.ForegroundColor = ConsoleColor.White;
            Print(message);
        }

        private static void Print(string message) {
            StackFrame frame = new StackFrame(2, true);
            var method = frame.GetMethod();
            var fileName = frame.GetFileName();
            var lineNumber = frame.GetFileLineNumber();

            Console.WriteLine($"{fileName} - {method}:{lineNumber} > {message}");
        }

        public static void CloseDebug() {
            
        }
    }
}
