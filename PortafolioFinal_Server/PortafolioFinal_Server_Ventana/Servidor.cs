using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections;
using Gtk;
using PortafolioFinal_Server_Ventana;

namespace PortafolioFinal_Server_Ventana
{
	public class Clase_Servidor
	{
		public static TcpListener Servidor;
		static Hashtable Cliente;
		public static bool EstadoServidor;
		public static bool Ciclos = true;
		public static string mensajeRegistro;
		
		public void ClaseServidor()
		{
			
			String MensajeCliente;
			try
			{
				//Conectarme
				Servidor = new TcpListener(IPAddress.Parse(MainWindow.stringIP), 6080);
				Cliente = new Hashtable();
				Servidor.Start();
				mensajeRegistro = "Servidor Conectado.....................";

				//Se crea una instancia nueva para poder acceder al método que va a llenar el textview.
				MainWindow ventana = new MainWindow();
				ventana.anadir_Registro(mensajeRegistro);
				//MainWindow.anadirTextView(mensajeRegistro, 1);


				Console.WriteLine("Servidor Conectado.....................");
				EstadoServidor = true;
				
				
				while (Ciclos)
				{
					TcpClient Clinte = Servidor.AcceptTcpClient();
					Byte[] msj_en_Byte = new Byte[140];
					
					NetworkStream NetworCliente = Clinte.GetStream();
					NetworCliente.Read(msj_en_Byte, 0, msj_en_Byte.Length);
					//ventana.anadir_Registro(mensajeRegistro);
					
					MensajeCliente = Encoding.ASCII.GetString(msj_en_Byte, 0, msj_en_Byte.Length);
					string[] words = MensajeCliente.Split(':');
					//ventana.anadir_Registro(mensajeRegistro);


					usuarios nuevo = new usuarios();
					if(nuevo.Estan_Registrados(words[0],words[1])==true)
					{
						Byte[] uno = null;
						
						NetworkStream strinnn = Clinte.GetStream();
						uno = Encoding.ASCII.GetBytes( "true");
						strinnn.Write(uno, 0, uno.Length);
						strinnn.Flush();
						Cliente.Add(words[0], Clinte);
						Metodos_Servidor Cliente_chatiando = new Metodos_Servidor(MensajeCliente, Clinte);
						
					}
					else{
						
						Byte[] uno = null;
						
						NetworkStream strinnn = Clinte.GetStream();
						uno = Encoding.ASCII.GetBytes("false");
						strinnn.Write(uno, 0, uno.Length);
						strinnn.Flush();
						
						
					}
					
					//ciclo infinito 
					
				}
			}
			catch
			{
				EstadoServidor = false;
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
			Ciclos = false;
		}
	}

	public class Metodos_Servidor 
	{
		public static Thread hilo_chatiando;
		public static bool Ciclos =true;
		String nombre;
		TcpClient Clienteclase;
		
		public Metodos_Servidor(String nombres, TcpClient Clienteclases)
		{
			Clase_Servidor.msj_Todos("El usuario a entrado:",nombre);
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
				//leer msj
				NetworkStream NetworCliente = Clienteclase.GetStream();
				NetworCliente.Read(msj_en_Byte, 0, msj_en_Byte.Length);
				
				MensajeCliente = Encoding.ASCII.GetString(msj_en_Byte, 0, msj_en_Byte.Length);
				Console.WriteLine(MensajeCliente);
				//msj enviar todos los clientes
				Clase_Servidor.msj_Todos(MensajeCliente,nombre);
				//ciclo infinito 
				
			}
		}
		
		public static void Cerrar_Hilos()
		{
			Ciclos=false;
		}
	}
}
