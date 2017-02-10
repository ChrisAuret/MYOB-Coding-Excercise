using System.Collections.Generic;

namespace myob.domain.Interfaces
{
    public interface IDataImporter
    {
        List<EmployeeDetail> Import(string filepath);
    }
}