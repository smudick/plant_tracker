﻿using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using PlantTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlantTracker.Data
{
    public class UserPlantsRepository
    {
        readonly string ConnectionString;
        public UserPlantsRepository(IConfiguration config)
        {
            ConnectionString = config.GetConnectionString("PlantTracker");
        }
        public List<UserPlants> GetAllUserPlants()
        {
            using var db = new SqlConnection(ConnectionString);
            var sql = @"SELECT * 
                        FROM User_Plants";
            return db.Query<UserPlants>(sql).ToList();
        }
        public void AddPlantToUser(UserPlants userPlants)
        {
            using var db = new SqlConnection(ConnectionString);
            var Last_Watered_Date = DateTime.Now;
            userPlants.Last_Watered_Date = Last_Watered_Date;
            var Next_Watered_Date = Last_Watered_Date.AddDays(userPlants.User_Water_Time);
            userPlants.Next_Watered_Date = Next_Watered_Date;
            var sql = @"INSERT INTO [dbo].[User_Plants]
                            ([User_Id]
                            ,[Plant_Id]
                            ,[Last_Watered_Date]
                            ,[Next_Watered_Date]
                            ,[Notes]
                            ,[User_Water_Time]
                            ,[User_Sunlight])
                       VALUES                 
                            (@User_Id
                            ,@Plant_Id
                            ,@Last_Watered_Date
                            ,@Next_Watered_Date
                            ,@Notes
                            ,@User_Water_Time
                            ,@User_Sunlight)";
            var id = db.ExecuteScalar<int>(sql, userPlants);
            userPlants.Id = id;
        }
    }
}
