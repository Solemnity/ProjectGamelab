using System;
using DankyKang.Source;

namespace DankyKang {
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Debugger.Debug("=== Initializing Game ===");
            using (var game = new Main())
                game.Run();
        }
    }
}