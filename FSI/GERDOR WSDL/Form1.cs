using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Configuration;
using System.Text;
using System.Windows.Forms;

namespace GERDOR_WSDL
{

    public partial class GeradorContratos : Form
    {


        public GeradorContratos()
        {
            InitializeComponent();

        }

        private void wsdlButton_Click(object sender, EventArgs e)
        {
            ContractGenerator CG = new ContractGenerator();
            CG.GerarWSDL(@"C:\Users\lgarciat\Desktop\TesteWSDL\GERDOR WSDL\Info.xlsx");


        }

        private void xsdButton_Click(object sender, EventArgs e)
        {
            ContractGenerator CG = new ContractGenerator();
            CG.GerarXsd(@"C:\Users\lgarciat\Desktop\TesteWSDL\GERDOR WSDL\Info.xlsx");


        }
    }


}
