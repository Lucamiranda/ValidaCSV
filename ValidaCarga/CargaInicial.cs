using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidaCarga
{
    internal class CargaInicial
    {
        public List<Modelo> csv;

        public List<int> Filiais()
        {
            var filiais = from pedidos in csv orderby pedidos.codigoFilialOrigem ascending select pedidos.codigoFilialOrigem;  
            var listaFiliais = filiais.Distinct().ToList();

            return listaFiliais.ToList();
        }
        public List<Modelo> Planilha(string strFilePath)
        {
            csv = new List<Modelo>();
            using (StreamReader sr = new StreamReader(strFilePath, Encoding.Default))
            {
                sr.ReadLine().Skip(1);
                while (!sr.EndOfStream)
                {
                    var campos = sr.ReadLine().Split(';');

                    csv.Add(new Modelo(
                    campos[0].Trim(),
                    campos[1].Trim(),
                    campos[2].Trim(),
                    campos[3].Trim(),
                    campos[4].Trim(),
                    campos[5].Trim(),
                    campos[6].Trim(),
                    campos[7].Trim(),
                    campos[8].Trim(),
                    campos[9].Trim(),
                    campos[10].Trim(),
                    campos[11].Trim(),
                    campos[12].Trim(),
                    campos[13].Trim().Replace(".", "").ToString(),
                    campos[14].Trim(),
                    campos[15].Trim(),
                    campos[16].Trim(),
                    campos[17].Trim(),
                    campos[18].Trim(),
                    campos[19].Trim(),
                    campos[20].Trim(),
                    campos[21].Trim(),
                    campos[22].Trim(),
                    campos[23].Trim(),
                    campos[24].Trim(),
                    campos[25].Trim(),
                    campos[26].Trim(),
                    campos[27].Trim(),
                    campos[28].Trim(),
                    campos[29].Trim(),
                    campos[30].Trim(),
                    campos[31].Trim(),
                    campos[32].Trim(),
                    campos[33].Trim(),
                    campos[34].Trim(),
                    campos[35].Trim(),
                    campos[36].Trim(),
                    campos[37].Trim(),
                    Convert.ToDouble(campos[38].Trim()),
                    campos[39].Trim(),
                    campos[40].Trim(),
                    campos[41].Trim(),
                    campos[42].Trim(),
                    campos[43].Trim(),
                    campos[44].Trim(),
                    /*Convert.ToDouble(campos[40].Trim()),
                    Convert.ToDouble(campos[41].Trim()),
                    Convert.ToDouble(campos[42].Trim()),
                    Convert.ToDouble(campos[43].Trim()),
                    Convert.ToDouble(campos[44].Trim()),*/
                    campos[45].Trim(),
                    campos[46].Trim(),
                    campos[47].Trim(),
                    campos[48].Trim().Replace(".", "").ToString(),
                    campos[49].Trim(),
                    campos[50].Trim(),
                    campos[51].Trim(),
                    campos[52].Trim(),
                    campos[53].Trim(),
                    campos[54].Trim(),
                    campos[55].Trim(),
                    campos[56].Trim(),
                    campos[57].Trim(),
                    campos[58].Trim(),
                    campos[59].Trim()));
                }
            }
            return csv;
        }
    }
}
