using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MyToDoList.Library
{
    public class ToDoListMeneger
    {
        private  string connectionString = @"Data Source=(localdb)\MSSQLlocaldb;Integrated Security=True";
        private SqlConnection _conection;
        private SqlCommand _comand;

        public  void CreateDBAndTAbleIfNotExist()
        {
            using (_conection = new SqlConnection(connectionString))
            {
                string comandString = @"USE [master]
             IF NOT EXISTS(SELECT name FROM master.dbo.sysdatabases WHERE name = 'ToDoList') CREATE DATABASE[ToDoList];";
                
                _conection.Open();
                _comand = new SqlCommand(comandString, _conection);
                _comand.ExecuteNonQuery();
                comandString = @" USE ToDoList
                    IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Task' )
                    CREATE TABLE     [Task] (
                    [Id]    UNIQUEIDENTIFIER NOT NULL default newid(),
                    [Title] NVARCHAR (MAX)   NOT NULL,
                    Compleated [bit] default 0
                   );";
                _comand.CommandText = comandString;
                _comand.ExecuteNonQuery();
            }
        }

    }
}
