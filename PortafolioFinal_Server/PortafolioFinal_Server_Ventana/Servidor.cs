using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections;

namespace PortafolioFinal_Server_Ventana
{
	public class Program_servidor
	{
		static TcpListener Servidor;
		static Hashtable Cliente;
		public static bool Ciclos =true;
		public void ClaseServidor()
		{
			
			String MensajeCliente;
			try
			{
				//Conectarme
				Servidor = new TcpListener(IPAddress.Parse("172.20.10.8"), 6080);
				Cliente = new Hashtable();
				Servidor.Start();
				Console.WriteLine("Servidor Conectado.....................");
				
				while (Ciclos)
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
		public static void CerrarServidor()
		{
			Ciclos=false;
			chatiar.Cerrar_Hilos();
		}
	}

	class chatiar 
	{
		public static Thread hilo_chatiando;
		public static bool Ciclos =true;
		String nombre;
		TcpClient Clienteclase;
		public chatiar(String nombres, TcpClient Clienteclases)
		{
			nombre = nombres;
			Clienteclase = Clienteclases;
			 hilo_chatiando = new Thread(chatiando);
				hilo_chatiando.Start();
			
		}
		public void chatiando() 
		{
			String MensajeCliente;
			while (Ciclos)
			{
				
				Byte[] msj_en_Byte = new Byte[140];
				
				NetworkStream NetworCliente = Clienteclase.GetStream();
				NetworCliente.Read(msj_en_Byte, 0, msj_en_Byte.Length);
				
				MensajeCliente = Encoding.ASCII.GetString(msj_en_Byte, 0, msj_en_Byte.Length);
				
				//msj enviar todos los clientes
				Program_servidor.msj_Todos(MensajeCliente,nombre);
				//ciclo infinito 
				
			}
			
		}
		public static void Cerrar_Hilos()
		{
			hilo_chatiando.Abort();
			Ciclos=false;
		}
		
		
	}
}
