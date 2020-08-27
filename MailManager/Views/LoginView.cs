﻿using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
using MailManager.Class;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MailManager
{
    public partial class Login : Form
    {
        private readonly MainView view;

        public Login(MainView mainView)
        {
            InitializeComponent();
            view = mainView;
        }

        private void lklblNewAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            view.ChangeView(new CreateAccountView(view));
            Dispose();
            Close();
        }

        private async void BtnLogin_Click(object sender, EventArgs e)
        {
            FirebaseClient client = FireConfig.GetClient();
            FirebaseAuthProvider authProvider = FireConfig.GetAuthProvider(); 

            if (string.IsNullOrEmpty(txtUser.Text))
            {
                MessageBox.Show(
                    "El usuario no debe estar vacio",
                    "Error");
            }
            else
            {
                if (string.IsNullOrEmpty(txtPassword.Text))
                {
                    MessageBox.Show(
                        "La contraseña no debe estar vacia",
                        "Error");
                }
                else
                {
                    try
                    {
                        
                        var signIn = await authProvider.SignInWithEmailAndPasswordAsync(txtUser.Text, txtPassword.Text);
                        User user = await authProvider.GetUserAsync(signIn.FirebaseToken);
                        if (user.IsEmailVerified)
                        {
                            List<MailAccount> mails = null;

                            var query2 = await client
                            .Child("User Account")
                            .Child($"{user.DisplayName} Mails")
                            .OrderByKey()
                            .OnceAsync<List<MailAccount>>();

                            foreach (var account in query2)
                            {
                                mails = account.Object;
                            }

                            AES.CryptoConfigure();

                            List<MailAccount> mailsDencrypt = new List<MailAccount>();

                            foreach (MailAccount account in mails)
                            {
                                string hostname = null;
                                if (!string.IsNullOrEmpty(account.Hostname))
                                {
                                    hostname = AES.Dencrypt(account.Hostname);
                                }
                                
                                mailsDencrypt.Add(new MailAccount(
                                    AES.Dencrypt(account.Mail), 
                                    AES.Dencrypt(account.Password), 
                                    hostname, 
                                    account.Puerto,
                                    AES.Dencrypt(account.Protocol),
                                    account.SSL));
                            }

                            view.ChangeView(new ManagedAccountView(mailsDencrypt));
                            view.Location = new Point(200, 100);
                            
                            MainView.SignIn = signIn;
                            MainView.UserApp = user;
                            MainView.AuthProvider = authProvider;
                            
                        }
                        else
                        {
                            MessageBox.Show(
                                "Verifica la cuenta",
                                "Error");
                        }
                    }
                    catch (FirebaseAuthException)
                    {
                        MessageBox.Show(
                            "Los datos son incorrectos",
                            "Error");
                    }
                    
                }
            }
        }
    }
}
