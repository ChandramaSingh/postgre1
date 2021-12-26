using postgre1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace postgre1.DataAccess
{
    public interface IDataAccessProvider
    {
        List<Patient> GetPatientRecords();
        void AddPatientRecord(Patient patient);
        void UpdatePatientRecord(Patient patient);
        void DeletePatientRecord(object id);
        Patient GetPatientSingleRecord(object id);
        
        
    }

}
