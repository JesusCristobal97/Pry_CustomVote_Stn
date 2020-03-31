
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;

namespace CVote_DataAccess.Utils
{
    public class Utils
    {
        public string getStatusV(string v) {
            string request = "";
            switch (v)
            {
               case "1":
                    request= "Creado";
                    break;
                case "2":
                    request = "Iniciado";
                    break;
                case "3":
                    request = "Terminado";
                    break;
            }
            return request;
        }

        public string getTypeV(string v)
        {
            string request = "";
            switch (v)
            {
                case "1":
                    request = "Revoto";
                    break;
                case "2":
                    request = "Primer Voto";
                    break;
            }
            return request;
        }

        public string GetMac(string ip)
        {

            string resultados = "";
            string mac = "";
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = "arp.exe";
            p.StartInfo.Arguments = "-a";
            p.Start();
            resultados = p.StandardOutput.ReadToEnd();
            p.WaitForExit();

            //string path = Server.MapPath("~/App_Data/DBCustomVote202.mdb");
            string dato = "";

            if (resultados.Contains(ip))
            {

                string pub = resultados.Replace("Interfaz: ", "");
                int inpub = pub.IndexOf(" ", 1);
                string sub = pub.Substring(0, inpub).Replace("\r\n", "");

                if (sub.Equals(ip))
                {
                    dato = (from nic in NetworkInterface.GetAllNetworkInterfaces() where nic.OperationalStatus == OperationalStatus.Up select nic.GetPhysicalAddress().ToString()).FirstOrDefault();

                }
                else
                {
                    int intubica = resultados.IndexOf("Tipo", 0, resultados.Length) + 4;
                    mac = resultados.Substring(intubica, resultados.Length - intubica).Replace("\r\n", ",").Replace("dinámico", "").Replace("estático", "");
                    string[] str = new string[] { "" };
                    str = mac.Split(',');

                    for (int i = 0; i < str.Length; i++)
                    {
                        if (str[i].Contains(ip))
                        {
                            int length = ip.Length;
                            int end = 0;

                            switch (length)
                            {
                                case 11:
                                    end = length + 4;
                                    break;
                                case 12:
                                    end = length + 3;
                                    break;
                                case 13:
                                    end = length + 2;
                                    break;
                                case 14:
                                    end = length + 1;
                                    break;
                                case 15:
                                    end = length + 0;
                                    break;

                            }
                            dato = str[i].Substring(end, str[i].Length - end).Trim();

                        }
                    }
                }
            }
            return dato;
        }

    }


}
