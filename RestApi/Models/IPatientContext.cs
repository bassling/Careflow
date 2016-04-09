using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RestApi.Models
{
    public interface IPatientContext
    {
        IDbSet<Patient> Patients { get; }
        IDbSet<Episode> Episodes { get; }
    }
}