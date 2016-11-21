using System;
using FSI.Model.ServiceIntegration;
using System.Collections.Generic;
using System.Data;

namespace FSI.Transformation.ExcelModel
{
    public class ExcelTransformationExtension
    {
        public void ToData(List<IntegrationScope> integrationScope)
        {
            throw new NotImplementedException();
        }
        public List<IntegrationScope> ToModel(DataSet wb)
        {
            ExcelSampleInfo_v0 es = new ExcelSampleInfo_v0();
            return es.ToModel(wb);
        }
        private IIntegrationData GetDocumentType()
        {
            //TODO:Introduzir arquivo de configurção e reflection
            //para selecionar o objeto correto a ser consumido.
            return new ExcelSampleInfo_v0();
        }
    }
}