using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Config_Web
{
    /// <summary>
    /// Encapsula chamadas ao aspnet_regiis.exe para criptografar e descriptografar
    /// secoes do Web.Config da mesma forma que a ferramenta de linha de comando faz.
    /// Flags utilizadas:
    ///   -pef  sectionName  folderPath  => criptografa
    ///   -pdf  sectionName  folderPath  => descriptografa
    /// O arquivo deve se chamar "web.config" (case-insensitive) na pasta indicada.
    /// </summary>
    public class EncryptionService
    {
        private readonly string _folderPath;

        public EncryptionService(string folderPath)
        {
            if (string.IsNullOrEmpty(folderPath))
                throw new ArgumentNullException("folderPath");

            _folderPath = folderPath;
        }

        public void Encrypt(string sectionName)
        {
            Execute("-pef", sectionName);
        }

        public void Decrypt(string sectionName)
        {
            Execute("-pdf", sectionName);
        }

        private void Execute(string flag, string sectionName)
        {
            string exe = FindAspNetRegiis();
            if (exe == null)
                throw new FileNotFoundException(
                    "aspnet_regiis.exe nao encontrado em nenhum caminho padrao do .NET Framework 4.\n" +
                    "Verifique se o .NET Framework 4.x esta instalado.");

            string args = string.Format("{0} \"{1}\" \"{2}\"", flag, sectionName, _folderPath);

            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName        = exe,
                Arguments       = args,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError  = true,
                CreateNoWindow  = true
            };

            StringBuilder output = new StringBuilder();
            StringBuilder errors = new StringBuilder();

            using (Process process = new Process())
            {
                process.StartInfo = psi;

                process.OutputDataReceived += delegate(object s, DataReceivedEventArgs a)
                {
                    if (a.Data != null) output.AppendLine(a.Data);
                };
                process.ErrorDataReceived += delegate(object s, DataReceivedEventArgs a)
                {
                    if (a.Data != null) errors.AppendLine(a.Data);
                };

                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();

                bool finished = process.WaitForExit(60000);

                if (!finished)
                {
                    try { process.Kill(); } catch { }
                    throw new TimeoutException("aspnet_regiis nao respondeu em 60 segundos.");
                }

                if (process.ExitCode != 0)
                {
                    string detail = errors.Length > 0 ? errors.ToString() : output.ToString();
                    throw new Exception(string.Format(
                        "aspnet_regiis retornou codigo {0}.\n{1}", process.ExitCode, detail.Trim()));
                }
            }
        }

        private static string FindAspNetRegiis()
        {
            string[] candidates = new[]
            {
                @"C:\Windows\Microsoft.NET\Framework64\v4.0.30319\aspnet_regiis.exe",
                @"C:\Windows\Microsoft.NET\Framework\v4.0.30319\aspnet_regiis.exe"
            };

            foreach (string path in candidates)
            {
                if (File.Exists(path))
                    return path;
            }

            return null;
        }
    }
}
