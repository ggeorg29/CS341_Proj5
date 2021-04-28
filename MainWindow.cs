using System;
using Gtk;
using MySql.Data;
using MySql.Data.MySqlClient;

public partial class MainWindow : Gtk.Window
{
    static Microsoft.FSharp.Collections.FSharpList<HW5P2Lib.HW5P2.Article> alldata;


    static MySqlConnection conn;

    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    protected void OnButton1Clicked(object sender, EventArgs e)
    {
        string filename = FsFilenameTextview.Buffer.Text;
        string userinput = userinputView.Buffer.Text;
        int id = Int32.Parse(userinput);
        try
        {
            alldata = HW5P2Lib.HW5P2.readfile(filename);
            textview1.Buffer.Text = String.Format("1. Title: {0}", HW5P2Lib.HW5P2.getTitle(id, alldata));
        }
        catch (Exception ex)
        {
            textview1.Buffer.Text = "couldn't load file: " + filename;

        }


    }

    protected void OnButton2Clicked(object sender, EventArgs e)
    {
        string filename = FsFilenameTextview.Buffer.Text;
        string userinput = userinputView.Buffer.Text;
        int id = Int32.Parse(userinput);
        try
        {
            alldata = HW5P2Lib.HW5P2.readfile(filename);
            textview1.Buffer.Text = String.Format("2. Number of Words in The Article: {0}", HW5P2Lib.HW5P2.wordCount(id, alldata));
        }
        catch (Exception ex)
        {
            textview1.Buffer.Text = "couldn't load file: " + filename;

        }
    }

    protected void OnButton4Clicked(object sender, EventArgs e)
    {
        string filename = FsFilenameTextview.Buffer.Text;
        try
        {
            alldata = HW5P2Lib.HW5P2.readfile(filename);
            Microsoft.FSharp.Collections.FSharpList<string> publisherNames = HW5P2Lib.HW5P2.publishers(alldata);
            textview1.Buffer.Text = "4. Unique Publishers: "
                + "\n" + String.Join("\n", publisherNames);
        }
        catch (Exception ex)
        {
            textview1.Buffer.Text = "couldn't load file: " + filename;

        }
    }

    protected void OnButton3Clicked(object sender, EventArgs e)
    {
        string filename = FsFilenameTextview.Buffer.Text;
        string userinput = userinputView.Buffer.Text;
        int id = Int32.Parse(userinput);
        try
        {
            alldata = HW5P2Lib.HW5P2.readfile(filename);
            textview1.Buffer.Text = String.Format("3. Month of Chosen Article: {0}", HW5P2Lib.HW5P2.getMonthName(id, alldata));
        }
        catch (Exception ex)
        {
            textview1.Buffer.Text = "couldn't load file: " + filename;

        }
    }

    protected void OnButton5Clicked(object sender, EventArgs e)
    {
        string filename = FsFilenameTextview.Buffer.Text;
        try
        {
            alldata = HW5P2Lib.HW5P2.readfile(filename);
            Microsoft.FSharp.Collections.FSharpList<string> countryNames = HW5P2Lib.HW5P2.countries(alldata);
            textview1.Buffer.Text = "4. Unique Publishers: "
                + "\n" + String.Join("\n", countryNames);
        }
        catch (Exception ex)
        {
            textview1.Buffer.Text = "couldn't load file: " + filename;

        }

    }

    protected void OnButton6Clicked(object sender, EventArgs e)
    {
        string filename = FsFilenameTextview.Buffer.Text;
        try
        {
            alldata = HW5P2Lib.HW5P2.readfile(filename);
            double overallguard = HW5P2Lib.HW5P2.avgNewsguardscoreForArticles(alldata);
            textview1.Buffer.Text = String.Format("6. Average News Guard Score for All Articles: {0}", overallguard);
        }
        catch (Exception ex)
        {
            textview1.Buffer.Text = "couldn't load file: " + filename;

        }
    }

    protected void OnButton7Clicked(object sender, EventArgs e)
    {
        string filename = FsFilenameTextview.Buffer.Text;
        try
        {
            alldata = HW5P2Lib.HW5P2.readfile(filename);
            Microsoft.FSharp.Collections.FSharpList<Tuple<string, int>> nArticles = HW5P2Lib.HW5P2.numberOfArticlesEachMonth(alldata);
            string output = HW5P2Lib.HW5P2.buildHistogram(nArticles, alldata.Length, "");
            output = output.Replace("\n", Environment.NewLine);
            textview1.Buffer.Text = "7. Number of Articles for Each Month:"
                + "\n" + output;
        }
        catch (Exception ex)
        {
            textview1.Buffer.Text = "couldn't load file: " + filename;

        }

    }

    protected void OnButton8Clicked(object sender, EventArgs e)
    {
        string filename = FsFilenameTextview.Buffer.Text;
        try
        {
            alldata = HW5P2Lib.HW5P2.readfile(filename);
            Microsoft.FSharp.Collections.FSharpList<Tuple<string, double>> reliablepct = HW5P2Lib.HW5P2.reliableArticlePercentEachPublisher(alldata);

            textview1.Buffer.Text = "8. Percentage of Articles That Are Reliable for Each Publisher: " + "\n";
            Microsoft.FSharp.Collections.FSharpList<string> lines1 = HW5P2Lib.HW5P2.printNamesAndPercentages(reliablepct);
            foreach (string line in lines1)
                textview1.Buffer.Text += line;

        }
        catch (Exception ex)
        {
            textview1.Buffer.Text = "couldn't load file: " + filename;

        }
    }

    protected void OnButton9Clicked(object sender, EventArgs e)
    {
        string filename = FsFilenameTextview.Buffer.Text;
        try
        {
            alldata = HW5P2Lib.HW5P2.readfile(filename);
            var avg = HW5P2Lib.HW5P2.averageguardscore(alldata);
            textview1.Buffer.Text = "9. Average News Guard Score for Each Country: ";
            foreach (var A in avg)
            {
                textview1.Buffer.Text += (String.Format("\n{0}: {1:F3}", A.Item1, A.Item2));
            }
        }
        catch (Exception ex)
        {
            textview1.Buffer.Text = "couldn't load file: " + filename;

        }

    }

    protected void OnButton10Clicked(object sender, EventArgs e)
    {
        string filename = FsFilenameTextview.Buffer.Text;
        try
        {
            alldata = HW5P2Lib.HW5P2.readfile(filename);
            textview1.Buffer.Text = "10. The Average News Guard Score for Each Political Bias Category: " + "\n";
            var b = HW5P2Lib.HW5P2.avgNewsguardscoreEachBias(alldata);
            var output = HW5P2Lib.HW5P2.buildHistogramFloat(b, "");
            textview1.Buffer.Text += output;
        }
        catch (Exception ex)
        {
            textview1.Buffer.Text = "couldn't load file: " + filename;

        }
    }
    void establishConnection()
    {
        string server = dataBaseView.Buffer.Text;
        string user = usernameView.Buffer.Text;
        string database = sqlDbView.Buffer.Text;
        string port = portView.Buffer.Text;
        string password = passwordView.Buffer.Text;
        //uncomment for project submittion
        string connStr = "server="+server+";user=" + user+"; database=" + database+";port=" + port+";password=" + password+"";
        //string connStr = "server=localhost;user=root;database=hw5;port=3306;password=Gleb12345!";  // change the database and password to test on your machine
        conn = new MySqlConnection(connStr);                                                     // must be these values when submitting to gradescope
        conn.Open();
    }

    protected void OnSqlButton1Clicked(object sender, EventArgs e)
    {
        try
        { 
            establishConnection();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            textview1.Buffer.Text = "Could not connect to the server for SQL Database";

        }

        

        try
        {
            string stringInput = userinputView.Buffer.Text;
            int id = Int32.Parse(stringInput);
            MySqlDataReader reader;

            string query = String.Format(@" 
                                                SELECT title
                                                FROM news
                                                WHERE news_id = {0};", id);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            reader = cmd.ExecuteReader();
            textview1.Buffer.Text = String.Format("{0}", reader.GetName(0));
            while (reader.Read())
            {
                textview1.Buffer.Text += String.Format("\n{0}", reader.GetString(0));
            }
            reader.Close();


        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            textview1.Buffer.Text = "Connection Established, BUT coundn't perform task";
        }
    }

    protected void OnSqlButton2Clicked(object sender, EventArgs e)
    {
        try
        {
            establishConnection();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            textview1.Buffer.Text = "Could not connect to the server for SQL Database";

        }

        MySqlDataReader reader;
        try
        {
            // Write (copy from queries folder) the query
            string query = String.Format(@" 
                                                SELECT news_id, LENGTH(body_text) AS length
                                                FROM news
                                                WHERE LENGTH(body_text)>100
                                                ORDER BY news_id;
                                            ");
            MySqlCommand cmd = new MySqlCommand(query, conn);
            reader = cmd.ExecuteReader();
            textview1.Buffer.Text = String.Format("{0}\t{1}", reader.GetName(0), reader.GetName(1));
            while (reader.Read())
            {
                textview1.Buffer.Text += String.Format("\n{0}\t\t{1}", reader.GetString(0), reader.GetInt32(1));
            }
            reader.Close();



        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            textview1.Buffer.Text = "Connection Established, BUT coundn't perform task";
        }
    

    }

    protected void OnSqlButton3Clicked(object sender, EventArgs e)
    {
        try
        {
            establishConnection();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            textview1.Buffer.Text = "Could not connect to the server for SQL Database";

        }

        MySqlDataReader reader;
        try
        {
     
            string query = String.Format(@" 
                                                SELECT title, DATE_FORMAT(STR_TO_DATE(publish_date, '%c/%d/%y'), '%M') AS Month
                                                FROM news
                                                ORDER BY STR_TO_DATE(publish_date, '%m/%d/%y')
                                            ");
            MySqlCommand cmd = new MySqlCommand(query, conn);
            reader = cmd.ExecuteReader();
            textview1.Buffer.Text = String.Format("{0}\t{1}", reader.GetName(0), reader.GetName(1));
            while (reader.Read())
            {
                textview1.Buffer.Text += String.Format("\n{0}\t{1}", reader.GetString(0), reader.GetString(1));
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }

    protected void OnSqlButton4Clicked(object sender, EventArgs e)
    {
        try
        {
            establishConnection();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            textview1.Buffer.Text = "Could not connect to the server for SQL Database";

        }

        MySqlDataReader reader;
        try
        {

            string query = String.Format(@" 
                                                SELECT publisher
                                                FROM publisher_table
                                                JOIN news
                                                USING (publisher_id)
                                                GROUP BY publisher
                                                ORDER BY publisher;
                                            ");
            MySqlCommand cmd = new MySqlCommand(query, conn);
            reader = cmd.ExecuteReader();
            textview1.Buffer.Text = String.Format("{0}", reader.GetName(0));
            while (reader.Read())
            {
                textview1.Buffer.Text += String.Format("\n{0}", reader.GetString(0));
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }

    protected void OnSqlButton5Clicked(object sender, EventArgs e)
    {
        try
        {
            establishConnection();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            textview1.Buffer.Text = "Could not connect to the server for SQL Database";

        }

        MySqlDataReader reader;
        try
        {

            string query = String.Format(@" 
                                               SELECT country, COUNT(news_id) AS articleCount
                                                FROM country_table
                                                LEFT JOIN news
                                                USING (country_id)
                                                GROUP BY country
                                                ORDER BY articleCount DESC;
                                            ");
            MySqlCommand cmd = new MySqlCommand(query, conn);
            reader = cmd.ExecuteReader();
            textview1.Buffer.Text = String.Format("{0}\t{1}", reader.GetName(0), reader.GetName(1));
            while (reader.Read())
            {
                textview1.Buffer.Text += String.Format("\n{0}\t\t{1}", reader.GetString(0), reader.GetInt32(1));
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }

    protected void OnSqlButton6Clicked(object sender, EventArgs e)
    {
        try
        {
            establishConnection();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            textview1.Buffer.Text = "Could not connect to the server for SQL Database";

        }

        MySqlDataReader reader;
        try
        {

            string query = String.Format(@" 
                                                SELECT ROUND(AVG(news_guard_score),3) AS `Average Score`
                                                FROM news;
                                            ");
            MySqlCommand cmd = new MySqlCommand(query, conn);
            reader = cmd.ExecuteReader();
            textview1.Buffer.Text = String.Format("{0}", reader.GetName(0));
            while (reader.Read())
            {
                textview1.Buffer.Text += String.Format("\n{0:F3}", reader.GetDouble(0));
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }

    protected void OnSqlButton7Clicked(object sender, EventArgs e)
    {
        try
        {
            establishConnection();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            textview1.Buffer.Text = "Could not connect to the server for SQL Database";

        }

        MySqlDataReader reader;
        try
        {

            string query = String.Format(@" 
                                               SELECT month, numArticles, overall, ROUND(100*numArticles/overall,3) AS percentage
                                                FROM
                                                (
                                                SELECT month, monthnum, COUNT(publish_date) AS numArticles, overallCount AS overall
                                                FROM
                                                (
                                                SELECT DATE_FORMAT(STR_TO_DATE(publish_date, '%m/%d/%y'), '%M') AS month, 
                                                    DATE_FORMAT(STR_TO_DATE(publish_date, '%m/%d/%y'), '%m') AS monthnum,
                                                    publish_date
                                                FROM news
                                                ) AS T1
                                                JOIN
                                                (
                                                SELECT COUNT(*) overallCount FROM news
                                                ) AS T2
                                                GROUP BY month, monthnum, overallCount
                                                ) AS T3
                                                ORDER BY monthnum;
                                            ");
            MySqlCommand cmd = new MySqlCommand(query, conn);
            reader = cmd.ExecuteReader();
            textview1.Buffer.Text = String.Format("{0}\t{1}\t{2}\t{3}", reader.GetName(0), reader.GetName(1), reader.GetName(2), reader.GetName(3));
            while (reader.Read())
            {
                textview1.Buffer.Text += String.Format("\n{0}\t{1}\t\t\t{2}\t\t{3:F3}", reader.GetString(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3));
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }

    protected void OnSqlButton8Clicked(object sender, EventArgs e)
    {
        try
        {
            establishConnection();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            textview1.Buffer.Text = "Could not connect to the server for SQL Database";

        }

        MySqlDataReader reader;
        try
        {

            string query = String.Format(@" 
                                               SELECT publisher, ROUND(AVG(reliability)*100, 3) AS percentage
                                                FROM news
                                                JOIN publisher_table
                                                USING (publisher_id)
                                                GROUP BY publisher
                                                ORDER BY percentage DESC, publisher;
                                            ");
            MySqlCommand cmd = new MySqlCommand(query, conn);
            reader = cmd.ExecuteReader();
            textview1.Buffer.Text = String.Format("{0}\t{1}", reader.GetName(0), reader.GetName(1));
            while (reader.Read())
            {
                textview1.Buffer.Text += String.Format("\n{0}\t{1:F3}", reader.GetString(0), reader.GetInt32(1));
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }

    protected void OnSqlButton9Clicked(object sender, EventArgs e)
    {
        try
        {
            establishConnection();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            textview1.Buffer.Text = "Could not connect to the server for SQL Database";

        }

        MySqlDataReader reader;
        try
        {

            string query = String.Format(@" 
                                               SELECT country, ROUND(AVG(news_guard_score),3) AS avg_news_score
                                                FROM news
                                                JOIN country_table
                                                USING (country_id)
                                                GROUP BY country
                                                ORDER BY AVG(news_guard_score) DESC, country ASC;

                                            ");
            MySqlCommand cmd = new MySqlCommand(query, conn);
            reader = cmd.ExecuteReader();
            textview1.Buffer.Text = String.Format("{0}\t{1}", reader.GetName(0), reader.GetName(1));
            while (reader.Read())
            {
                textview1.Buffer.Text += String.Format("\n{0}\t{1:F3}", reader.GetString(0), reader.GetInt32(1));
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }

    protected void OnSqlButton10Clicked(object sender, EventArgs e)
    {
        try
        {
            establishConnection();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            textview1.Buffer.Text = "Could not connect to the server for SQL Database";

        }

        MySqlDataReader reader;
        try
        {

            string query = String.Format(@" 
                                               SELECT author, political_bias, COUNT(*) AS numArticles
                                                FROM news
                                                JOIN news_authors
                                                USING (news_id)
                                                JOIN author_table
                                                USING (author_id)
                                                JOIN political_bias_table
                                                USING (political_bias_id)
                                                GROUP BY author, political_bias
                                                ORDER BY author, COUNT(*) DESC, political_bias;
                                            ");
            MySqlCommand cmd = new MySqlCommand(query, conn);
            reader = cmd.ExecuteReader();
            textview1.Buffer.Text = String.Format("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2));
            while (reader.Read())
            {
                textview1.Buffer.Text += String.Format("\n{0}\t{1}\t{2}", reader.GetString(0), reader.GetString(1), reader.GetInt32(2));
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}
