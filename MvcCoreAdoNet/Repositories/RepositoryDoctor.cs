using Microsoft.Data.SqlClient;
using MvcCoreAdoNet.Models;

namespace MvcCoreAdoNet.Repositories
{
    public class RepositoryDoctor
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;

        public RepositoryDoctor()
        {
            string connectionString = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=sa;Encrypt=True;Trust Server Certificate=True";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
        }
        public async Task<List<Doctor>> GetDoctorsAsync() 
        {
            string sql = "select * from DOCTOR";
            this.com.CommandType = System.Data.CommandType.Text;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            List<Doctor> doctores = new List<Doctor>();
            while (await this.reader.ReadAsync())
            {
                //creamos el objeto y le pasamos la info
                Doctor doc = new Doctor
                {
                    IdDoctor = int.Parse(this.reader["DOCTOR_NO"].ToString()),
                    Apellido = this.reader["APELLIDO"].ToString(),
                    Especialidad = this.reader["ESPECIALIDAD"].ToString(),
                    Salario = int.Parse(this.reader["SALARIO"].ToString())
                };
                //añadimos cada doctor a la coleccion
                doctores.Add(doc);
            }
            await this.reader.CloseAsync();
            await this.cn.CloseAsync();
            return doctores;
        }

        public async Task<List<Doctor>> GetDoctoresEspecialidadesAsync(string especialidad)
        {
            string sql = "select * from DOCTOR where ESPECIALIDAD=@especialidad";
            this.com.Parameters.AddWithValue("@especialidad", especialidad);
            this.com.CommandType = System.Data.CommandType.Text;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            List<Doctor> doctores = new List<Doctor>();
            while (await this.reader.ReadAsync())
            {
                Doctor doc = new Doctor
                {
                    IdDoctor = int.Parse(this.reader["DOCTOR_NO"].ToString()),
                    Apellido = this.reader["APELLIDO"].ToString(),
                    Especialidad = this.reader["ESPECIALIDAD"].ToString(),
                    Salario = int.Parse(this.reader["SALARIO"].ToString())
                };
                doctores.Add(doc);
            }
            await this.reader.CloseAsync();
            await this.cn.CloseAsync();
            this.com.Parameters.Clear();
            return doctores;
        }

        public async Task<List<string>> GetEspecialidadesAsync()
        {
            string sql = "select distinct ESPECIALIDAD from DOCTOR";
            this.com.CommandType = System.Data.CommandType.Text;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            List<string> especialidades = new List<string>();
            while (await this.reader.ReadAsync())
            {
                especialidades.Add(this.reader["ESPECIALIDAD"].ToString());              
            }
            await this.reader.CloseAsync();
            await this.cn.CloseAsync();
            return especialidades;
        }
    }
}
