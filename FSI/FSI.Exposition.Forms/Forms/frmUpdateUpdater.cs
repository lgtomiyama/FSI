using SharpSvn;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FSI.Exposition.Forms
{
    public partial class frmUpdateUpdater : Form
    {
        public frmUpdateUpdater()
        {
            InitializeComponent();
        }

        private void frmUpdateUpdater_Load(object sender, EventArgs e)
        {
            _svnUser = "";//usuario
            _svnPassword = "";//senha
            _appUrl = "";//repo


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
        public string _svnUser;
        public string _svnPassword;
        public string _appUrl;
        bool _runingThread = false;
        private void GetApplication()
        {
            _runingThread = true;

            Thread.Sleep(50);
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


                files.Add("FSI.Setup.Update.exe");

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
                        if (filePath != "" && client.Write(new SvnUriTarget(_appUrl + "/" + filePath), stream))
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
                        label1.BeginInvoke(
                           new Action(() =>
                           {
                               label1.Text = filePath;
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

            progressBar1.BeginInvoke(
                new Action(() =>
                {
                    progressBar1.Value = 0;
                }
            ));
            label1.BeginInvoke(
                new Action(() =>
                {
                    label1.Text = "";
                }
            ));
            MessageBox.Show("Arquivos da aplicação atualizados com sucesso.");

            _runingThread = false;

            this.BeginInvoke(
                new Action(() =>
                {
                    this.Close();
                }
            ));

        }
    }
}
