using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
   public class datenBank
    {
        int q;
        private MySqlConnection dbConnection;

        public void dbOeffnen()
        {
            try
            {
                dbConnection = new MySqlConnection(
                    "SERVER=127.0.0.1; DATABASE=spiel_project;"  //connection mit datenbank erstellen
                    + "UID=root; PASSWORD=root; SSLMODE=NONE");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void dbSchliessen()
        {
            dbConnection.Close();                                   //connection schliessen
        }
        public void saveUser(string a)                               // spieler in datenbank speichern
        {
            dbOeffnen();
    
            MySqlCommand comm = dbConnection.CreateCommand();
            comm.CommandText = ("INSERT INTO  spiel_project.spielerNamen  VALUES(null,null,'" + a + "');"); //entschprechende SQL Befel
            dbConnection.Open();
            comm.ExecuteNonQuery();
            dbConnection.Close();

        }

        public void saveScore(int score,string name)// score speichern
        {
            dbOeffnen();

            MySqlCommand comm = dbConnection.CreateCommand();
            comm.CommandText = ("INSERT INTO  spiel_project.spielerNamen  VALUES(null,'"+score+"','" +name+ "');"); //entschprechende SQL Befel
            dbConnection.Open();
            comm.ExecuteNonQuery();
            dbConnection.Close();

        }

        public List<land> giblisteland()                                 // Liste von Classe Land wird ausgefuhlt
        {
            List<land> liLa = new List<land>();
            MySqlCommand comm = dbConnection.CreateCommand(); 
            comm.CommandText = "SELECT * FROM landd;";  //entschprechende SQL Befel

            dbConnection.Open();
            MySqlDataReader reader = comm.ExecuteReader();

            while (reader.Read())
            {
                land l = new land(
                    
                    reader.GetString(1), // land
                    reader.GetString(2), // stadt
                    reader.GetString(3)   // flagg
                    );

                liLa.Add(l);
            }

            reader.Close();
            dbConnection.Close();


            return liLa;
        }
        public int namePrufen(string name) // pruft wie viel mal eingegebene name in sql table vorkommt
        {
            dbOeffnen();
            int q=0;
            MySqlCommand comm = dbConnection.CreateCommand();
            comm.CommandText = "select count(*) from spielernamen where nikname = '"+name+"';";    //entschprechende SQL Befel
            dbConnection.Open();
            MySqlDataReader reader = comm.ExecuteReader();
            while(reader.Read())
            {
                q = reader.GetInt32(0);
            }
            reader.Close();
            dbConnection.Close();
            

            return q ;
        }

        public void delNames() // loescht alle datensatze in tabele
        {
            dbOeffnen();
            MySqlCommand comm = dbConnection.CreateCommand();
            comm.CommandText = " delete from spielernamen where id > 1; "; //entschprechende SQL Befel
            dbConnection.Open();
            comm.ExecuteNonQuery();
            dbConnection.Close();
        }

        public void delNam(string n) // loescht eingegebene name
        {
            dbOeffnen();
            MySqlCommand comm = dbConnection.CreateCommand();
            comm.CommandText = "delete from spielernamen where nikName = '" + n + "';";  //entschprechende SQL Befel
            dbConnection.Open();
            comm.ExecuteNonQuery();
            dbConnection.Close();
        }
        public List<score> showScore() // zeigt name and score in absteigende Reihnfolge
       
        {
            List<score> liSc = new List<score>();
            MySqlCommand comm = dbConnection.CreateCommand();
            comm.CommandText = " select nikName,score from spielernamen order by score desc;  ";

            dbConnection.Open();
            MySqlDataReader reader = comm.ExecuteReader();

            while (reader.Read())
            {
                score l = new score(

               reader.IsDBNull(0)?"ohne": reader.GetString(0), // name
               reader.IsDBNull(1)?"0":     reader.GetString(1) // scor3
                    );



               liSc.Add(l);
            }

            reader.Close();
            dbConnection.Close();


            return liSc;
        }
        public void updateName(string g) //wird nicht benutzt
        {
            dbOeffnen();
            MySqlCommand comm = dbConnection.CreateCommand();
            comm.CommandText = " update spielernamen set nikName = replace(nikName, '" + g + "', '" + g + "') where nikName = '" + g + "';";
            dbConnection.Open();
            comm.ExecuteNonQuery();
            dbConnection.Close();

        }

    }
}
