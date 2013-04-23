using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace PortafolioFinal_Server_Ventana
{
	class usuarios
	{
		#region Propiedades
		public int Id { get; set; }
		public string Nombre { get; set; }
		public string Contrasena { get; set; }
		public static bool Correcto;
		#endregion
		#region Constructores
		public usuarios()
		{
			
		}
		public bool Estan_Registrados(string nombre, string contrasena)
		{
			Conexion.AbrirConexion();
			
			MySqlCommand tabla = new MySqlCommand("SELECT nombre,contrasena  FROM  usuarios  WHERE nombre='"+nombre+"' AND contrasena='"+contrasena+"'", Conexion.varConexion);
			MySqlDataReader data = tabla.ExecuteReader();
			if (data.Read())
			{
				return true;
			}
			else
			{
				return false;
			}
			
			Conexion.CerrarConexion();
		}
		#endregion
		#region Metodos
		
		
		#endregion
		
	}
}

abstract class Conexion
{
	/// <summary>
	/// Variable para coenctar con la base de datos...
	/// </summary>
	public static MySqlConnection varConexion = new MySqlConnection("Server=localhost;Database=chatandroid;Uid=root; Pwd='' ");
	
	/// Abrir conexion
	/// </summary>
	public static void AbrirConexion()
	{
		varConexion.Open();
	}
	/// <summary>
	/// Cerrar conexion 
	/// </summary>
	public static void CerrarConexion()
	{
		varConexion.Close();
	}
}
