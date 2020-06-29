using Microsoft.Reporting.WebForms;

namespace Reports
{
    public abstract class BaseReports
    {
        protected LocalReport Relatorio;

        public string MimeType { get; private set; }
        public byte[] Bytes { get; private set; }

        protected BaseReports()
        {
            Relatorio = new LocalReport();
        }

        public void Gerar()
        {
            ExecutarCore();

            Bytes = Renderizar();
        }

        protected abstract void ExecutarCore();

        private byte[] Renderizar()
        {            
            const string reportType = "PDF";
            string mimeType;
            string encoding;
            string fileNameExtension;

            const string deviceInfo = "<DeviceInfo>" +
                                      " <OutputFormat>PDF</OutputFormat>" +
                                      " <PageWidth>15in</PageWidth>" +
                                      " <PageHeight>11in</PageHeight>" +
                                      " <MarginTop>0.7in</MarginTop>" +
                                      " <MarginLeft>2in</MarginLeft>" +
                                      " <MarginRight>2in</MarginRight>" +
                                      " <MarginBottom>0.7in</MarginBottom>" +
                                      "</DeviceInfo>";

            Warning[] warnings;
            string[] streams;

            //Renderiza o relatório em bytes
            var bytes = Relatorio.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings);

            //Response.AddHeader("content-disposition", "attachment; filename=PEDIDO." + fileNameExtension);
            MimeType = mimeType;

            return bytes;
        }
    }
}
