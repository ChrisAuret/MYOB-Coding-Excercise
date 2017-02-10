using System.Collections.Generic;

namespace myob.domain.Interfaces
{
    public interface IDataImporter
    {
        /// <summary>
        /// Import records from CSV file
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        List<EmployeeDetail> Import(string filepath);
    }
}