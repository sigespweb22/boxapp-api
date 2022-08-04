// using System;
// using System.IO;
// using System.Reflection;

// namespace BoxBack.WebApi.Helpers
// {
//     public class RegistraLog
//     {
//         private static string caminhoExe = string.Empty;
//         public static bool Log(string strMensagem, string strNomeArquivo = "ArquivoLog" )
//         {
//             try
//             {
//                 caminhoExe = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
//                 string caminhoArquivo = Path.Combine(caminhoExe, strNomeArquivo);
//                 if (!File.Exists(caminhoArquivo))
//                 {
//                     FileStream arquivo = File.Create(caminhoArquivo);
//                     arquivo.Close();
//                 }
//                 using (StreamWriter w = File.AppendText(caminhoArquivo))
//                 {
//                     AppendLog(strMensagem, w);
//                 }
//                 return true;
//             }
//             catch (Exception)
//             {
//                 return false;
//             }
//         }
//         private static void AppendLog(string logMensagem, TextWriter txtWriter)
//         {
//             try
//             {
//                 // txtWriter.Write("\r\nLog Entrada : ");
//                 // txtWriter.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
//                 // txtWriter.WriteLine("  :");
//                 txtWriter.WriteLine($"  :{logMensagem}");
//                 // txtWriter.WriteLine("------------------------------------");
//             }
//             catch (Exception ex)
//             {
//                 throw ex;
//             }
//         }
//     }
// }

/// https://docs.microsoft.com/pt-br/dotnet/fundamentals/code-analysis/quality-rules/ca2200