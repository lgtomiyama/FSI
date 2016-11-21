using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GERDOR_WSDL.Forms
{
    //Criardor: Lucas Garcia Tomiyama
    public partial class CarregarPlanilhas : Form
    {
        public CarregarPlanilhas()
        {
            InitializeComponent();

            gdvPlanilhasAdicionadas.DataSource = bsArquivosAdicionados;


            txtBuscaArquivos.ADDRecursos(lstArquivos, bsArquivos);
            lstArquivos.DataSource = bsArquivos;
            txtBuscaArquivos.filtro.Add("[Name]");


            txtBuscaPlanilhaAdicionadas.filtro.Add("[Name]");
            txtBuscaPlanilhaAdicionadas.ADDRecursos(gdvPlanilhasAdicionadas, bsArquivosAdicionados);

        }
        BindingSource bsArquivos = new BindingSource();
        BindingSource bsArquivosAdicionados = new BindingSource();
        List<FileInfo> fileListAdicionados = new List<FileInfo>();
        private void btnDiretorio_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            folderDialog.ShowDialog();
            string diretorioReferencias = folderDialog.SelectedPath;

            List<FileInfo> fileList = new DirectoryInfo(diretorioReferencias).GetFiles("*.xls", SearchOption.AllDirectories).ToList();
            bsArquivos.DataSource = ToDataTable<FileInfo>(fileList);

            lstArquivos.DisplayMember = "Name";
            lstArquivos.ValueMember = "FullName";

        }


        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (lstArquivos.SelectedItems.Count > 0)
            {
                FileInfo file = new FileInfo(lstArquivos.SelectedValue.ToString());
                fileListAdicionados.Add(file);
                bsArquivosAdicionados.DataSource = ToDataTable<FileInfo>(fileListAdicionados);
            }

        }

        //http://stackoverflow.com/questions/18100783/how-to-convert-a-list-into-data-table
        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);


            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {

                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {

                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }

            return dataTable;
        }

        private void btnGerarDocumento_Click(object sender, EventArgs e)
        {
            if(gdvPlanilhasAdicionadas.Rows.Count > 0)
            { 
                progressProcessamentoArquivos.Minimum = 0;
                progressProcessamentoArquivos.Maximum = gdvPlanilhasAdicionadas.RowCount;
                progressProcessamentoArquivos.Value = 1;

                progressProcessamentoArquivos.Step = 1;
                foreach (DataGridViewRow item in gdvPlanilhasAdicionadas.Rows)
                {
                    ContractGenerator CG = new ContractGenerator();
                    CG.GerarWSDL(item.Cells[6].Value.ToString());
                    CG.GerarXsd(item.Cells[6].Value.ToString());
                    progressProcessamentoArquivos.PerformStep();
                    Application.DoEvents();   
                }
                progressProcessamentoArquivos.Value = 0;
                MessageBox.Show("Contratos Gerados!");
            }
        }
    }
}
