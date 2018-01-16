using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace FoodStock01
{
    [Table("Time")]//テーブル名を指定
    public class TimeModel
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int P_hour { get; set; } //時

        public int P_minute { get; set; } //分

        /*******************セレクトメソッド（時）*************************************/
        public static int SelectHour()
        {
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {
                try
                {
                    /**********試し*************/
                    List<TimeModel> SetList = db.Query<TimeModel>("SELECT [P_hour] FROM [Time]"); ;

                    int[] SetArray = new int[100];

                    int alert = 1;

                    int i = 0;

                    //foreach (TimeModel stm in SetList)
                    //{
                    //    //SetArray[i++] = stm.Set_alert;
                    //    SetArray[i] = stm.P_hour;
                    //    i++;
                    //}

                    SetArray[0] = 1;

                    alert = SetArray[0];

                    //データベースに指定したSQLを発行
                    return alert;

                }
                catch (Exception e)
                {

                    System.Diagnostics.Debug.WriteLine(e);
                    return 999;
                }
            }
        }

        /*******************セレクトメソッド（分）*************************************/
        public static int SelectMinute()
        {
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {
                try
                {
                    //データベースに指定したSQLを発行

                    List<TimeModel> SetMinute = db.Query<TimeModel>("SELECT [P_minute] FROM [Time]"); ;

                    int[] SetM = new int[100];

                    int al = 1;

                    int i = 0;

                    foreach (TimeModel stm in SetMinute)
                    {
                        //SetArray[i++] = stm.Set_alert;
                        SetM[i] = stm.P_minute;
                        i++;
                    }

                    al = SetM[0];

                    //データベースに指定したSQLを発行
                    return al;

                }
                catch (Exception e)
                {

                    System.Diagnostics.Debug.WriteLine(e);
                    return 999;
                }
            }
        }

        public static void InsertTime(int p_hour, int p_minute)
        {
            //データベースに接続する
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {
                try
                {
                    //データベースにFoodテーブルを作成する
                    db.CreateTable<TimeModel>();

                    db.Insert(new TimeModel() { P_hour = p_hour, P_minute = p_minute });
                    db.Commit();
                }
                catch (Exception e)
                {
                    db.Rollback();
                    System.Diagnostics.Debug.WriteLine(e);
                }
            }
        }

        /********************アップデートメソッド（2回目以降の通知設定）**********************/
        public static void UpdateTime(int p_hour, int p_minute)
        {
            //データベースに接続する
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {
                try
                {
                    //データベースにFoodテーブルを作成する
                    db.CreateTable<TimeModel>();

                    db.Update(new TimeModel() { P_hour = p_hour, P_minute = p_minute });
                    db.Commit();
                }
                catch (Exception e)
                {
                    db.Rollback();
                    System.Diagnostics.Debug.WriteLine(e);
                }
            }
        }

        
    }
}