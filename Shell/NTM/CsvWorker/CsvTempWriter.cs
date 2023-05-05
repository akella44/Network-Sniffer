using NTM.Event_Args;
using NTM.Objects;
using NTM;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using System.Threading;
using System.Windows.Markup;

namespace Shell.NTM.Statistics
{
    public class CsvTempWriter<T, H> : IDisposable where T : class
    {
        public string FileName { get; private set; }
        public CsvTempWriter()
        {
            FileName = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".csv";
        }

        public void InitTempFile()
        {
            using (var StreamWriter = new StreamWriter(File.Open(FileName, FileMode.Append)))
            {
                using (var CsvWriter = new CsvWriter(StreamWriter, CultureInfo.InvariantCulture))
                {
                    CsvWriter.WriteHeader<T>();
                    CsvWriter.NextRecord();
                }
            }
        }
        public void AddObjToTempCsvFile(object sender, H e)
        {
            try
            {
                using (var StreamWriter = new StreamWriter(File.Open(FileName, FileMode.Append)))
                {
                    using (var CsvWriter = new CsvWriter(StreamWriter, CultureInfo.InvariantCulture))
                    {
                        CsvWriter.WriteRecord(e);
                        CsvWriter.NextRecord();
                    }
                }
            }
            catch (Exception ex)
            {
                Thread.Sleep(10);
            }
        }

        public void Dispose()
        {
            System.IO.File.Delete(FileName);
        }
    }
}
