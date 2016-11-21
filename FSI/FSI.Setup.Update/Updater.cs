using SharpSvn;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FSI.Setup.Update
{
    public partial class Updater : Form
    {
        public string _svnUser;
        public string _svnPassword;
        public string _appUrl;
        public string _canonicalUrl;
        public string _templatesUrl;

        public Updater(string[] args)
        {
            InitializeComponent();
            _appUrl = args[0];
            _canonicalUrl = args[1];
            _templatesUrl = args[2];
        }
        bool _runingThread = false;
        private void GetApplication()
        {
            _runingThread = true;
            btnAtualizarAplicacao.BeginInvoke(
                   new Action(() =>
                   {
                       btnAtualizarAplicacao.Enabled = false;
                   }
               ));
            btnCanonico.BeginInvoke(
               new Action(() =>
               {
                   btnCanonico.Enabled = false;
               }
           ));
            btnAtualizarTemplates.BeginInvoke(
           new Action(() =>
           {
               btnAtualizarTemplates.Enabled = false;
           }
        ));

            Thread.Sleep(50);
            bool gotList;
            List<string> files = new List<string>();

            using (SvnClient client = new SvnClient())
            {
                client.Authentication.UserNamePasswordHandlers
                   += delegate (object obj, SharpSvn.Security.SvnUserNamePasswordEventArgs args)
                   {
                       args.Save = true;
                   };
                Collection<SvnListEventArgs> list;

                gotList = client.GetList(_appUrl, out list);

                if (gotList)
                {
                    foreach (SvnListEventArgs item in list)
                    {
                        if (item.Name.EndsWith(".exe") || item.Name.EndsWith(".dll") && !item.Name.Contains("vshost"))
                            files.Add(item.Path);
                    }
                }
                progressBar1.BeginInvoke(
                    new Action(() =>
                    {
                        progressBar1.Minimum = 0;
                        progressBar1.Step = 1;
                        progressBar1.Maximum = files.Count();
                    }
                ));

                foreach (string filePath in files)
                {

                    lblFile.BeginInvoke(
                       new Action(() =>
                       {
                           lblFile.Text = filePath;
                       }
                    ));
                    using (var stream = new MemoryStream())
                    {
                        if (!string.IsNullOrEmpty(filePath) && client.Write(new SvnUriTarget(_appUrl + filePath), stream))
                        {
                            stream.Position = 0;
                            using (var reader = new StreamReader(stream))
                            {
                                using (Stream s = File.Create(AppDomain.CurrentDomain.BaseDirectory + filePath))
                                {

                                    stream.CopyTo(s);
                                }
                            }
                        }

                    }
                    progressBar1.BeginInvoke(
                        new Action(() =>
                        {
                            progressBar1.PerformStep();
                        }
                    ));
                }
            }
            btnAtualizarAplicacao.BeginInvoke(
                   new Action(() =>
                   {
                       btnAtualizarAplicacao.Enabled = true;
                   }
               ));
            btnCanonico.BeginInvoke(
               new Action(() =>
               {
                   btnCanonico.Enabled = true;
               }
           ));
            btnAtualizarTemplates.BeginInvoke(
           new Action(() =>
           {
               btnAtualizarTemplates.Enabled = true;
           }
        ));
            progressBar1.BeginInvoke(
                new Action(() =>
            {
                progressBar1.Value = 0;
            }
            ));
            lblFile.BeginInvoke(
                new Action(() =>
               {
                   lblFile.Text = "";
               }
            ));
            MessageBox.Show("Arquivos da aplicação atualizados com sucesso.");
            _runingThread = false;
        }

        private void btnAtualizarAplicacao_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_runingThread)
                {
                    Thread t = new Thread(GetApplication);
                    t.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _runingThread = false;
            }
        }


        private void CloseApp()
        {
            if (!_runingThread)
            {
                Process app = new Process();
                app.StartInfo.FileName = AppDomain.CurrentDomain.BaseDirectory + "FSI.Exposition.Forms.exe";
                app.Start();
                this.Dispose();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseApp();
        }

        private void Updater_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_runingThread)
                CloseApp();
            else
                e.Cancel = true;

        }
        private void getCanonical()
        {
            _runingThread = true;
            btnAtualizarAplicacao.BeginInvoke(
                   new Action(() =>
                   {
                       btnAtualizarAplicacao.Enabled = false;
                   }
               ));
            btnCanonico.BeginInvoke(
               new Action(() =>
               {
                   btnCanonico.Enabled = false;
               }
           ));
            btnAtualizarTemplates.BeginInvoke(
           new Action(() =>
           {
               btnAtualizarTemplates.Enabled = false;
           }
        ));

            List<string> files = new List<string>();

            using (SvnClient client = new SvnClient())
            {
                client.Progress += new EventHandler<SvnProgressEventArgs>(svn_Progress);
                client.Authentication.UserNamePasswordHandlers
                   += delegate (object obj, SharpSvn.Security.SvnUserNamePasswordEventArgs args)
                   {
                       args.UserName = _svnUser;
                       args.Password = _svnPassword;
                       args.Save = true;
                   };
                if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "telefonica-sb\\"))
                {

                    client.CheckOut(new SvnUriTarget(_canonicalUrl), AppDomain.CurrentDomain.BaseDirectory + "telefonica-sb\\");
                }
                else
                {
                    client.CleanUp(AppDomain.CurrentDomain.BaseDirectory + "telefonica-sb\\");
                    client.Update(AppDomain.CurrentDomain.BaseDirectory + "telefonica-sb\\");
                }

            }

            _runingThread = false;
            progressBar1.BeginInvoke(
                new Action(() =>
                {
                    progressBar1.Value = 0;
                }
            ));
            btnAtualizarAplicacao.BeginInvoke(
                   new Action(() =>
                   {
                       btnAtualizarAplicacao.Enabled = true;
                   }
               ));
            btnCanonico.BeginInvoke(
               new Action(() =>
               {
                   btnCanonico.Enabled = true;
               }
           ));
            btnAtualizarTemplates.BeginInvoke(
           new Action(() =>
           {
               btnAtualizarTemplates.Enabled = true;
           }
        ));
            MessageBox.Show("Arquivos canônicos atualizados com sucesso.");
        }



        private void svn_Progress(object sender, SvnProgressEventArgs e)
        {
            if (e.Progress > e.TotalProgress)
            {
                progressBar1.BeginInvoke(
                   new Action(() =>
                   {
                       progressBar1.Maximum = (int)e.Progress + 1;
                   }
               ));

            }
            progressBar1.BeginInvoke(
                   new Action(() =>
                   {
                       progressBar1.Value = (int)e.Progress;
                   }
               ));

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                if (!_runingThread)
                {
                    Thread t = new Thread(getCanonical);
                    t.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _runingThread = false;
            }
        }

        private void btnAtualizarTemplates_Click(object sender, EventArgs e)
        {

            try
            {
                if (!_runingThread)
                {
                    Thread t = new Thread(getTemplates);
                    t.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _runingThread = false;
            }
        }

        private void getTemplates()
        {
            {
                _runingThread = true;
                btnAtualizarAplicacao.BeginInvoke(
                       new Action(() =>
                       {
                           btnAtualizarAplicacao.Enabled = false;
                       }
                   ));
                btnCanonico.BeginInvoke(
                   new Action(() =>
                   {
                       btnCanonico.Enabled = false;
                   }
               ));
                btnAtualizarTemplates.BeginInvoke(
               new Action(() =>
               {
                   btnAtualizarTemplates.Enabled = false;
               }
            ));
                Thread.Sleep(50);
                bool gotList;
                List<string> files = new List<string>();

                using (SvnClient client = new SvnClient())
                {
                    client.Authentication.UserNamePasswordHandlers
                       += delegate (object obj, SharpSvn.Security.SvnUserNamePasswordEventArgs args)
                       {
                           args.UserName = _svnUser;
                           args.Password = _svnPassword;
                           args.Save = true;
                       };
                    Collection<SvnListEventArgs> list;

                    gotList = client.GetList(_templatesUrl, out list);

                    if (gotList)
                    {
                        foreach (SvnListEventArgs item in list)
                        {
                            if (item.Name.EndsWith(".exe") || item.Name.EndsWith(".dll") || !item.Name.Contains("vshost"))
                                files.Add(item.Path);
                        }
                    }
                    progressBar1.BeginInvoke(
                        new Action(() =>
                        {
                            progressBar1.Minimum = 0;
                            progressBar1.Step = 1;
                            progressBar1.Maximum = files.Count();
                        }
                    ));


                    foreach (string filePath in files)
                    {
                        using (var stream = new MemoryStream())
                        {
                            if (!string.IsNullOrEmpty(filePath) && client.Write(new SvnUriTarget(_templatesUrl + filePath), stream))
                            {
                                stream.Position = 0;
                                using (var reader = new StreamReader(stream))
                                {
                                    using (Stream s = File.Create(AppDomain.CurrentDomain.BaseDirectory + "\\Templates\\" + filePath))
                                    {

                                        stream.CopyTo(s);
                                    }
                                }
                            }
                            lblFile.BeginInvoke(
                               new Action(() =>
                               {
                                   lblFile.Text = filePath;
                               }
                            ));
                        }
                        progressBar1.BeginInvoke(
                            new Action(() =>
                            {
                                progressBar1.PerformStep();
                            }
                        ));
                    }
                }
                btnAtualizarAplicacao.BeginInvoke(
                       new Action(() =>
                       {
                           btnAtualizarAplicacao.Enabled = true;
                       }
                   ));
                btnCanonico.BeginInvoke(
                   new Action(() =>
                   {
                       btnCanonico.Enabled = true;
                   }
               ));
                btnAtualizarTemplates.BeginInvoke(
               new Action(() =>
               {
                   btnAtualizarTemplates.Enabled = true;
               }
            ));
                progressBar1.BeginInvoke(
                    new Action(() =>
                    {
                        progressBar1.Value = 0;
                    }
                ));
                lblFile.BeginInvoke(
                    new Action(() =>
                    {
                        lblFile.Text = "";
                    }
                ));
                MessageBox.Show("Arquivos da aplicação atualizados com sucesso.");
                _runingThread = false;
            }
        }
    }
}
