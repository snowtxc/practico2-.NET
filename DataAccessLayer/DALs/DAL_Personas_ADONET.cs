using DataAccessLayer.IDALs;
using Microsoft.Data.SqlClient;
using Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DALs
{
    public class DAL_Personas_ADONET : IDAL_Personas
    {

        private string _connectionString = "Server=DESKTOP-PQS42G3\\SQLEXPRESS;DATABASE=Practico2;Trusted_Connection=True;TrustServerCertificate=True;";

        public void Delete(string documento)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("DELETE FROM Personas WHERE Documento = @documento", connection))
                {
                    command.Parameters.Add("@documento", SqlDbType.VarChar);
                    command.Parameters["@documento"].Value = documento;

                    command.ExecuteReader();

                }
                connection.Close();
            }
        }
        public List<Persona> Get()
        {

            List<Persona> personas = new List<Persona>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using(SqlCommand command = new SqlCommand("SELECT * FROM Personas", connection))
                {
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read()) 
                        {
                            Persona persona = new Persona();

                            persona.Documento = reader["Documento"].ToString();
                            persona.Nombre = reader["Nombre"].ToString();
                            personas.Add(persona);


                        }
                    }
                }
            }
            return personas;


        }

        public Persona Get(string documento)
        {
            Persona persona = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM Personas WHERE Documento = @documento", connection))
                {
                    command.Parameters.Add("@documento", SqlDbType.VarChar);
                    command.Parameters["@documento"].Value = documento;

                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            persona = new Persona
                            {
                                Documento = (string)reader["Documento"],
                                Nombre = (string)reader["Nombre"]
                            };


                        }


                    }

                    
                }
                connection.Close();
            }
            return persona;
        }

        public void Insert(Persona persona)
        {


            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO dbo.Personas (Nombre,Documento) VALUES (@Nombre,@Documento)", connection))
                {
                    command.Parameters.Add("@Nombre", SqlDbType.VarChar);
                    command.Parameters.Add("@Documento", SqlDbType.VarChar);

                    command.Parameters["@Nombre"].Value = persona.Nombre;
                    command.Parameters["@Documento"].Value = persona.Documento;

                    command.ExecuteScalar();

                }
                connection.Close();
            }

        }

        public void Update(Persona persona)
        {
            throw new NotImplementedException();
        }
    }
}
