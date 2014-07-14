using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public partial class dcTable : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            dynCreation();
    }
    public void btSaveDB(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        Label lbl=null;
        SqlConnection sqlconnObj = null;
        SqlCommand sqlcmdObj = null;
        string sql_instQuery = "", sqlConnectionString = "";
        try
        {
            int n = int.Parse(txtTBCount.Text);
            sqlConnectionString = "server=CSNSYS068\\SQLEXPRESS;Database=ImranGani;User ID=sa;Password=cellar123;";
            sqlconnObj = new SqlConnection(sqlConnectionString);
            for (int i = 1; i <= n; i++)
            {
                TextBox t = this.Page.FindControl("tbValue" + i) as TextBox;
                if (t != null)
                    sql_instQuery += "INSERT INTO DynTable_1(UserName,sno)values('" + t.Text + "','" + i + "');";
            }
            sqlcmdObj = new SqlCommand(sql_instQuery, sqlconnObj);
            sqlconnObj.Open();
            if (sqlcmdObj.ExecuteNonQuery() > 0)
            {
                lbl = new Label();
                lbl.Text = "<br/><span id=\"lbl1\" style=\"color:Green;\"/>Data Saved successfully: ";
                phTextBoxesHere.Controls.Add(lbl);
            }
            else
            {
                lbl = new Label();
                lbl.Text = "<br/><span id=\"lbl1\" style=\"color:Red;\"/>Data saving err : ";
                phTextBoxesHere.Controls.Add(lbl);
            }

        }
        catch (Exception er)
        {
            lbl = new Label();
            lbl.Text = "<br/><span id=\"lbl1\" style=\"color:Red;\"/>Catch err : " + er;
            phTextBoxesHere.Controls.Add(lbl);
        }
        finally
        {
            if (sqlconnObj != null)
            {
                if (sqlconnObj.State.Equals(ConnectionState.Open))
                    sqlconnObj.Close();
                sqlconnObj.Dispose();
            }
            if (sqlcmdObj != null)
                sqlcmdObj.Dispose();
            sqlConnectionString = null;
            sql_instQuery = null;
        }            
    }
    public void dynCreation()
    {
        Table table = null;
        TableRow row = null;
        TableCell cell = null;
        Label lbl = null;
        TextBox tb = null;
        Button btSave =null;
        try
        {
            int n = int.Parse(txtTBCount.Text);
            table = new Table();
            table.ID = "Table1";
            for (int i = 1; i <= n; i++)
            {
                row = new TableRow();
                for (int j = 1; j <= 2; j++)
                {
                    cell = new TableCell();
                    lbl = new Label();
                    lbl.Text = "Label " + i;
                    cell.Controls.Add(lbl);
                    row.Cells.Add(cell);
                    j++;
                    tb = new TextBox();
                    tb.ID = "tbValue" + i.ToString();
                    cell.Controls.Add(tb);
                    row.Cells.Add(cell);
                }
                table.Rows.Add(row);
            }
            phTextBoxesHere.Controls.Add(table);
            btSave = new Button();
            btSave.ID = "btSave1";
            btSave.Text = "Save";
            btSave.Click += new EventHandler(btSaveDB);
            phTextBoxesHere.Controls.Add(btSave);
        }
        catch (Exception er)
        {
            lbl = new Label();
            lbl.Text = "<br/><span id=\"lbl1\" style=\"color:Red;\"/>Catch err : " + er;
            phTextBoxesHere.Controls.Add(lbl);
        }
        finally
        {
            if (table != null)
                table.Dispose();
            if (row != null)
                row.Dispose();
            if (cell != null)
                cell.Dispose();
            if (lbl != null)
                lbl.Dispose();
            if (tb != null)
                tb.Dispose();
        }
    }
}
