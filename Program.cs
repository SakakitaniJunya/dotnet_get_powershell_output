using System;
using System.Diagnostics;
using System.IO;

namespace ConsoleOutputCapture
{
    class ConsoleOutputCapture
    {
        static void Main(string[] args)
        {
            // Write Excute Command
            string env = "powershell.exe";
            string command = "Connect-MgGraph";

            // ProcessStartInfoを作成し、プロセスの設定を行います。
            ProcessStartInfo psi = new ProcessStartInfo(env, command)
            {
                RedirectStandardOutput = true, // 標準出力をリダイレクトすることを指定します
                RedirectStandardError = true,  // 標準エラーをリダイレクトすることを指定します
                UseShellExecute = false,        // シェル機能を使用せず、プロセスを直接実行することを指定します
                CreateNoWindow = true          // 新しいウィンドウを作成せずに実行することを指定します
            };

            // Processオブジェクトを作成し、プロセスを実行します。 
            using (Process process = new Process { StartInfo = psi })
            {
                process.Start(); //プロセスを開始します

                //標準出力と標準エラーを取得します
                string standardOutput = process.StandardOutput.ReadToEnd();
                string standardError = process.StandardError.ReadToEnd();

                process.WaitForExit(); //プロセスが終了するまで待機します

                // テスト
                Console.WriteLine("標準出力");
                Console.WriteLine(standardOutput);
                Console.WriteLine("標準エラー");
                Console.WriteLine(standardError);

            }


        }
    }
}
