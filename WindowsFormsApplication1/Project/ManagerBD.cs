﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;


namespace Project
{
    class ManagerBD
    {
        SQLiteConnection sql;
        public void Connection()
        {
            try
            {
                sql = new SQLiteConnection(@"Data Source= mydb.sqlite;Version=3");
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Управляющий запрос
        /// </summary>
        public void controlquery(string сq)
        {
            try
            {
                SQLiteCommand sc = new SQLiteCommand(сq, sql);
                sql.Open();
                sc.ExecuteNonQuery();
                sql.Close();
            }
            catch (Exception ex)
            {
                sql.Close();
                throw ex; 
            }


        }
        /// <summary>
        /// запрос выборка
        /// </summary>
        /// <param name="sq"></param>
        public DataTable selectionquery(string sq)
        {
            DataTable dt;
            try
            {
                //SQLiteConnection sqlcon = new SQLiteConnection(@"Data Source= mydb.sqlite;Version=3");
                sql.Open();
                SQLiteCommand sc = new SQLiteCommand(sql);
                sc.CommandText = @sq;

                SQLiteDataReader sdr = sc.ExecuteReader();
                 dt = new DataTable();
                dt.Load(sdr);
                //dataGridView1.DataSource = dt;
                sql.Close();
            }
            catch (Exception ex)
            {
                sql.Close();
                throw ex;
            }
            return dt;
        }
        /// <summary>
        /// Вывод статистики для диаграмм
        /// </summary>
        /// <returns></returns>
        public DataTable Statistic()
        {
            DataTable dt;
            try
            {
                sql.Open();
                SQLiteCommand sc = new SQLiteCommand(sql);
                sc.CommandText = @"select month_zakaz,sum(summa),count(*) from zakaz group by month_zakaz ;";

                SQLiteDataReader sdr = sc.ExecuteReader();
                dt = new DataTable();
                dt.Load(sdr);
                //dataGridView1.DataSource = dt;
                sql.Close();
            }
            catch (Exception ex)
            {
                sql.Close();
                throw ex;
            }
            return dt;
        }

        

    }


}


