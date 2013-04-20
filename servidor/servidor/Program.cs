using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections;

namespace servidor
{
    class Program
    {
        static TcpListener Servidor;
        static Hashtable Cliente;
        static void Main(string[] args)
        {

            String MensajeCliente;
            try
            {
                //Conectarme
                Servidor = new TcpListener(IPAddress.Parse("127.0.0.1"), 8888);
                Cliente = new Hashtable();
                Servidor.Start();
                Console.WriteLine("Servidor Conectado.....................");

                while (true)
                {
                    TcpClient Clinte = Servidor.AcceptTcpClient();
                    Byte[] msj_en_Byte = new Byte[140];

                    NetworkStream NetworCliente = Clinte.GetStream();
                    NetworCliente.Read(msj_en_Byte, 0, msj_en_Byte.Length);

                    MensajeCliente = Encoding.ASCII.GetString(msj_en_Byte, 0, msj_en_Byte.Length);

                    Cliente.Add(MensajeCliente, Clinte);
                    //msj enviar todos los clientes
                    msj_Todos(MensajeCliente,MensajeCliente);
                    

                    //ciclo infinito 
                    chatiar nuevo = new chatiar(MensajeCliente, Clinte);
                }
            }
            catch
            {

                Console.WriteLine("Error");

            }
            finally {
                Servidor.Stop();
            }
           
        }
        public static void   msj_Todos(String Mensaje,String Nombre)
        {
            
            foreach(DictionaryEntry C in Cliente )
            {
                Byte[] uno = null;
                TcpClient cliente_conectado = (TcpClient)C.Value;
                NetworkStream strinnn = cliente_conectado.GetStream();
                uno = Encoding.ASCII.GetBytes(Nombre + " : " + Mensaje);
                strinnn.Write(uno, 0, uno.Length);
                strinnn.Flush();
                Console.WriteLine(Nombre + " : " + Mensaje);

            }
        }
    }
    class chatiar 
    {
        String nombre;
        TcpClient Clienteclase;
        public chatiar(String nombres, TcpClient Clienteclases)
        {
            nombre = nombres;
            Clienteclase = Clienteclases;
            Thread hilo = new Thread(chatiando);
            hilo.Start();

        }
        public void chatiando() 
        {
            String MensajeCliente;
            while (true)
            {
                
                Byte[] msj_en_Byte = new Byte[140];

                NetworkStream NetworCliente = Clienteclase.GetStream();
                NetworCliente.Read(msj_en_Byte, 0, msj_en_Byte.Length);

                MensajeCliente = Encoding.ASCII.GetString(msj_en_Byte, 0, msj_en_Byte.Length);

                //msj enviar todos los clientes
               Program.msj_Todos(MensajeCliente,nombre);
                //ciclo infinito 

            }
        
        }
    
    
    }
}
