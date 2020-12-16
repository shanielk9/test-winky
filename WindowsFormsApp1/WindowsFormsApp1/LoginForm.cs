using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace WindowsFormsApp1
{
    public partial class LoginForm : Form
    {
        private const int k_FullNameMinChar = 5;
        private const int k_PasswordMinChar = 6;

        private UserData m_userData = new UserData();
        Random r = new Random();

        public LoginForm()
        {
            InitializeComponent();

            initPeople();
        }

        private void initPeople()
        {
            try
            {
                if (!(File.Exists(@"C:\\temp\\UsersJson.json")))
                {
                    //url that generate rendom full name & email & password
                    string Url = @"http://www.filltext.com/?rows=1000&fullname={firstName}~{lastName}&email={email}&password={password}&pretty=true";

                    var Json = new WebClient().DownloadString(Url);

                    using (var writer = new StreamWriter(@"C:\\temp\\UsersJson.json"))
                    {
                        writer.Write(Json);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FullNameTxtBx_Click(object sender, EventArgs e)
        {
            FullNameTxtBx.Text = "";
        }

        private void EmailTxtBx_Click(object sender, EventArgs e)
        {
            EmailTxtBx.Text = "";
        }

        private void PasswordTxtBx_Click(object sender, EventArgs e)
        {
            PasswordTxtBx.Text = "";
            PasswordTxtBx.PasswordChar = '*';
        }

        private bool checkIfAllTxtBxInitForSign()
        {
            if (!checkName())
            {
                return false;
            }
            if(!checkEmail())
            {
                return false;
            }
            if(!checkPassword())
            {
                return false;
            }

            return true;
        }

        private bool checkName()
        {
            if (!FullNameTxtBx.Text.Contains(" ")) //check if there is one space
                return false;
            if (FullNameTxtBx.Text.Length < k_FullNameMinChar)
                return false;

            m_userData.fullname = FullNameTxtBx.Text;
            return true;
        }

        private bool checkEmail()
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(EmailTxtBx.Text);
                if (addr.Address == EmailTxtBx.Text)
                {
                    m_userData.email = EmailTxtBx.Text;
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }

        private bool checkPassword()
        {
            if (PasswordTxtBx.Text.Length < k_PasswordMinChar)
                return false;

            m_userData.password = PasswordTxtBx.Text;
            return true;
        }

        private void SignInBtn_Click(object sender, EventArgs e)
        {
            PasswordTxtBx.PasswordChar = '*';

            if (!checkIfAllTxtBxInitForSign())
            {
                MessageBox.Show("One of the enterd values illegal.");
            }
            else
            {
                try
                {
                    if (!checkIfUserSignInAllready())
                    {
                        var filePath = @"C:\\temp\\UsersJson.json";
                        // Read existing json data
                        var jsonData = System.IO.File.ReadAllText(filePath);
                        // De-serialize to object or create new list
                        var usersList = JsonConvert.DeserializeObject<List<UserData>>(jsonData) ?? new List<UserData>();

                        // Add any new employees
                        usersList.Add(m_userData);

                        // Update json data string
                        jsonData = JsonConvert.SerializeObject(usersList);
                        System.IO.File.WriteAllText(filePath, jsonData);
                        ////////////////////////////////////////////////////
                    }
                    else
                    {
                        MessageBox.Show("You Allready Signed in!, press Login.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private bool checkIfUserSignInAllready()
        {
            bool isAppear = false;

            try
            {
                if (!(File.Exists(@"C:\\temp\\UsersJson.json")))
                {
                    return false;
                }

                string JsonFromFile;
                using (var reader = new StreamReader(@"C:\\temp\\UsersJson.json"))
                {
                    JsonFromFile = reader.ReadToEnd();
                }

                if(JsonFromFile.Contains('"'+m_userData.email+'"'))
                {
                    isAppear = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return isAppear;
        }
    }
}
