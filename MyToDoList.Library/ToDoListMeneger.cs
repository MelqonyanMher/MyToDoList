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

        public void AddTaskInTable(MyToDo task)
        {
            string query = $"Use ToDoList" +
                $" Insert into Task (Id,Title) Values ('{task.Id}','{task.Value}')";
            using (_conection = new SqlConnection(connectionString))
            {
                _conection.Open();
                _comand = new SqlCommand(query,_conection);
                _comand.ExecuteNonQuery();
            }
        }

        public void RemoveTaskFromTable(MyToDo task)
        {
            string query = $"Use ToDoList" +
                $" Delete From Task where [Id] ='{task.Id}'";
            using (_conection = new SqlConnection(connectionString))
            {
                _conection.Open();
                _comand = new SqlCommand(query, _conection);
                _comand.ExecuteNonQuery();
            }
        }
        public ToDoTaskList ReadFromBase(ToDoTaskList list)
        {
            string query = $"Use ToDoList" +
                $" Select Id,Title,Compleated from Task";
            using (_conection = new SqlConnection(connectionString))
            {
                _conection.Open();
                _comand = new SqlCommand(query, _conection);
                SqlDataReader reader = _comand.ExecuteReader();
                while (reader.Read())
                {

                    list.Add(new MyToDo((Guid)reader[0], (string)reader[1], (bool)reader[2]));
                }
                return list;
            }
        }
    }
}
